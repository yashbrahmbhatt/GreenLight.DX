using GreenLight.DX.Config.Activities.Helpers;
using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Excel;
using UiPath.Excel.Activities;
using UiPath.Platform.ResourceHandling;
using UiPath.Robot.Activities.Api;

namespace GreenLight.DX.Config.Activities
{
    public class LoadConfig : NativeActivity
    {
        public InArgument<IResource> ConfigPath { get; set; }
        public InArgument<string> Configuration { get; set; }
        public OutArgument ConfigurationObject { get; set; }
        public bool Debug { get; set; } = false;
        private void Log(NativeActivityContext context, string message, bool isDebug, TraceEventType eventType = TraceEventType.Verbose)
        {
            if (isDebug)
            {
                context.GetExecutorRuntime().LogMessage(new LogMessage
                {
                    EventType = eventType,
                    Message = message
                });
            }
        }
        protected override void Execute(NativeActivityContext context)
        {
            Log(context, "Starting activity execution", Debug);
        }
    }
}
