using GreenLight.DX.Config.Settings;
using GreenLight.DX.Config.Wizards;
using System;
using System.Activities.Presentation.Metadata;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UiPath.Studio.Activities.Api;

namespace GreenLight.DX.Config
{
    public class RegisterMetadata : IRegisterMetadata
    {

        public void Register()
        {
            var builder = new AttributeTableBuilder();
            MetadataStore.AddAttributeTable(builder.CreateTable());
        }

        /// <summary>
        /// This method is discovered in Studio using reflection.
        /// If found, a reference to the studio api is passed
        public void Initialize(object argument)
        {
            try
            {
                var api = argument as IWorkflowDesignApi;
                if (api == null)
                {
                    return;
                }
                if (api.HasFeature(DesignFeatureKeys.Settings))
                {
                    Setting.Create(api);
                }
                if (api.HasFeature(DesignFeatureKeys.Wizards))
                {
                    Wizard.Create(api);
                }
                //var args = new UiPath.Studio.Activities.Api.Activities.RegisterArgs(typeof(Activities.REFramework, "REFramework");

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
            }
        }
    }
}
