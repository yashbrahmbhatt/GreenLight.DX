using GreenLight.DX.Config.Activities.Helpers;
using Newtonsoft.Json;
using System;
using System.Activities;
using System.Activities.Statements;
using System.ComponentModel;
using System.Diagnostics;
using UiPath.Robot.Activities.Api;

namespace GreenLight.DX.Config.Activities
{
    public class REFramework : NativeActivity
    {
        [Browsable(false)]
        public ActivityAction<IObjectContainer> InitializeState { get; set; }

        [Browsable(false)]
        public ActivityAction<IObjectContainer> ExecuteState { get; set; }

        [Browsable(false)]
        public ActivityAction<IObjectContainer> FinalizeState { get; set; }

        public InArgument<string> Test { get; set; }

        public bool Debug { get; set; } = false; // Debug flag

        internal static string ParentContainerPropertyTag => "ScopeActivity";

        private readonly IObjectContainer _objectContainer;

        public REFramework()
        {
            _objectContainer = new ObjectContainer();
            InitializeState = new ActivityAction<IObjectContainer>
            {
                Argument = new DelegateInArgument<IObjectContainer>(ParentContainerPropertyTag),
                Handler = new Sequence { DisplayName = nameof(InitializeState) }
            };

            ExecuteState = new ActivityAction<IObjectContainer>
            {
                Argument = new DelegateInArgument<IObjectContainer>(ParentContainerPropertyTag),
                Handler = new Sequence { DisplayName = nameof(ExecuteState) }
            };

            FinalizeState = new ActivityAction<IObjectContainer>
            {
                Argument = new DelegateInArgument<IObjectContainer>(ParentContainerPropertyTag),
                Handler = new Sequence { DisplayName = nameof(FinalizeState) }
            };
        }
        public REFramework(IObjectContainer objectContainer) : this()
        {
            _objectContainer = objectContainer;
        }

        protected override void Execute(NativeActivityContext context)
        {
            Log(context, "Starting activity execution", Debug);

            if (InitializeState?.Handler != null)
            {
                Log(context, "Scheduling InitializeState", Debug);
                context.ScheduleAction(InitializeState, _objectContainer, OnInitializeCompleted);
            }
            else
            {
                ExecuteMain(context);
            }
        }

        private void OnInitializeCompleted(NativeActivityContext context, ActivityInstance completedInstance)
        {
            Log(context, "InitializeState completed", Debug);
            ExecuteMain(context);
        }

        private void ExecuteMain(NativeActivityContext context)
        {
            Log(context, "Executing main action", Debug);

            if (ExecuteState?.Handler != null)
            {
                Log(context, "Scheduling ExecuteState", Debug);
                context.ScheduleAction(ExecuteState, _objectContainer, OnExecuteCompleted);
            }
            else
            {
                FinalizeMain(context);
            }
        }

        private void OnExecuteCompleted(NativeActivityContext context, ActivityInstance completedInstance)
        {
            Log(context, "ExecuteState completed", Debug);
            FinalizeMain(context);
        }

        private void FinalizeMain(NativeActivityContext context)
        {
            Log(context, "Finalizing execution", Debug);

            if (FinalizeState?.Handler != null)
            {
                Log(context, "Scheduling FinalizeState", Debug);
                context.ScheduleAction(FinalizeState, _objectContainer, OnFinalizeCompleted);
            }
            else
            {
                Cleanup(context);
            }
        }

        private void OnFinalizeCompleted(NativeActivityContext context, ActivityInstance completedInstance)
        {
            Log(context, "FinalizeState completed", Debug);
            Cleanup(context);
        }

        private void Cleanup(NativeActivityContext context)
        {
            Log(context, "Starting cleanup", Debug);
            if (_objectContainer != null)
            {
                foreach (var obj in _objectContainer.Where(o => o is IDisposable))
                {
                    if (obj is IDisposable dispObject)
                        dispObject.Dispose();
                }
                _objectContainer.Clear();
            }

            Log(context, "Cleanup completed", Debug);
        }

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
    }
}
