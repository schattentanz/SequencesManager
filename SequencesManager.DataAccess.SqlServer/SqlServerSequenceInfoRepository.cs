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
                const string query = "SELECT * FROM Sequences";
                return connection.Query<SequenceInfo>(query);
            }
        }

        public void AddSequenceInformation(SequenceInfo sequenceInformation)
        {
            var connectionProvider = new ConnectionProvider();
            using (IDbConnection connection = connectionProvider.GetOpenedConnection())
            {
                const string query =
                  "INSERT INTO Sequences(SequenceType, SequenceLength, MaxElement, Average) " +
                  "VALUES (@SequenceType, @SequenceLength, @MaxElement, @Average)";
                connection.Execute(query, sequenceInformation);
            }
        }
    }
}
