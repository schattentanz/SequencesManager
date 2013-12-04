using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SequencesManager.Core;
using Dapper;

namespace SequencesManager.DataAccess.SqlServer
{
    public class SqlServerSequenceInfoRepository : ISequenceInfoRepository
    {
        public IEnumerable<SequenceInfo> GetSequencesInformation()
        {
            var connectionProvider = new ConnectionProvider();
            using (IDbConnection connection = connectionProvider.GetOpenedConnection())
            {
                const string query = @"SELECT s.RunNumber, s.SequenceType, e.MaxElement, e.Average, e.SequenceLength 
                    FROM Sequences s INNER JOIN 
                    (SELECT el.RunNumber, MAX(el.Element) MaxElement, 
                    COUNT(el.Element) SequenceLength, avg(Cast(el.Element as Float)) Average FROM SequenceElements el GROUP BY el.RunNumber) e
                    ON s.RunNumber = e.RunNumber ORDER BY s.RunNumber";
                return connection.Query<SequenceInfo>(query);
            }
        }

        public void AddSequenceInformation(SequenceInfo sequenceInformation, IEnumerable<long> sequenceElements)
        {
            var connectionProvider = new ConnectionProvider();
            using (IDbConnection connection = connectionProvider.GetOpenedConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    const string sequencesInfoQuery =
                      "INSERT INTO Sequences(SequenceType) " +
                      "VALUES (@SequenceType);SELECT CAST(SCOPE_IDENTITY() as int)";
                    var runNumber = connection.Query<int>(sequencesInfoQuery, sequenceInformation, transaction: transaction).Single();

                    const string sequencesElementsQuery =
                      "INSERT INTO SequenceElements(RunNumber, Element) " +
                      "VALUES (@RunNumber, @Element)";
                    connection.Execute(sequencesElementsQuery, 
                        sequenceElements.Select(x => new { RunNumber = runNumber, Element = x }), transaction: transaction);
                    transaction.Commit();
                }
            }
        }
    }
}
