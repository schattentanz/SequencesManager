using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SequencesManager.Core;
using SequencesManager.DataAccess.SqlServer;
using SequencesManager.Services;

namespace SequencesManager.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        private AsyncTaskDelegate _sequenceComputingDelegate;

        protected delegate SequenceGeneratingResultInfo AsyncTaskDelegate();

        protected void OnGenerate(object sender, EventArgs e)
        {
            var task = new PageAsyncTask(new BeginEventHandler(StartSequenceGenerating),
                new EndEventHandler(EndSequenceGenerating), null, null);
            RegisterAsyncTask(task);
        }

        private void EndSequenceGenerating(IAsyncResult ar)
        {
            var result = _sequenceComputingDelegate.EndInvoke(ar);
            if (result.SequenceGeneratingResult == SequenceGeneratingResult.Success)
            {
                var sequenceService = new SequenceService(new SqlServerSequenceInfoRepository());
                ResultsGrid.DataSource = sequenceService.GetSequencesInformation();
                ResultsGrid.DataBind();
                ErrorInfo.Text = "";
            }
            else
            {
                ErrorInfo.Text = result.ExceptionInfo;
            }
        }

        private IAsyncResult StartSequenceGenerating(object sender, EventArgs e, AsyncCallback cb, object extraData)
        {
            var sequenceType = (SequenceType)int.Parse(SequenceTypeList.SelectedValue);
            var sequenceService = new SequenceService(new SqlServerSequenceInfoRepository());
            _sequenceComputingDelegate = new AsyncTaskDelegate(() => sequenceService.AddSequenceInfo(sequenceType, int.Parse(ElementsCountField.Text)));
            return _sequenceComputingDelegate.BeginInvoke(cb, extraData);
        }


    }
}
