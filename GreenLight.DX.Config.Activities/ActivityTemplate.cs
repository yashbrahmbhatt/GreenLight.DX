using GreenLight.DX.Config.Activities.Helpers;
using Newtonsoft.Json;
using System.Activities;
using System.Diagnostics;
using UiPath.Excel.Activities.API;
using UiPath.Robot.Activities.Api;

namespace GreenLight.DX.Config.Activities
{
    public class ActivityTemplate : CodeActivity // This base class exposes an OutArgument named Result
    {
        /*
         * The returned value will be used to set the value of the Result argument
         */

        public ActivityAction<string> InitializeState { get; set; }
        public ActivityAction<string> ExecuteState { get; set; }
        public ActivityAction<string> FinalizeState { get; set; }

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
        }
        protected override void Execute(CodeActivityContext context)
        {
            
            context.GetExecutorRuntime().LogMessage(new LogMessage()
            {
                EventType = TraceEventType.Information,
                Message = JsonConvert.SerializeObject(context, Formatting.Indented, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                })
            });

            InitializeState.Handler

            //ExecuteInternal();
        }

        public void ExecuteInternal()
        {
            // use this to automatically attach the debugger to the process
            //Debugger.Launch();
            throw new NotImplementedException();
        }
    }
}
