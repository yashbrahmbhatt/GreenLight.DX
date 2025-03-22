using GreenLight.DX.Shared.Services.Orchestrator;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UiPath.Studio.Activities.Api;

namespace GreenLight.DX.Config.Shared.Models
{
    [Serializable]
    [XmlType(nameof(AssetItem))] // For XML serialization of derived type
    public class AssetItem : ConfigItem
    {
        [JsonProperty(nameof(AssetName))]
        public string AssetName { get; set; } = "AssetName";

        [JsonProperty(nameof(AssetFolder))]
        public string AssetFolder { get; set; } = "AssetFolder";

        [JsonIgnore]
        [XmlIgnore]
        private OrchestratorService _orchestratorService;

        [JsonIgnore]
        [XmlIgnore]
        public override object? Value
        {
            get
            {
                if (_orchestratorService.Assets != null && _orchestratorService.Assets.Any())
                {
                    var asset = _orchestratorService.Assets.FirstOrDefault(a => a.Key.DisplayName == AssetFolder).Value.FirstOrDefault(a => a.Name == AssetName);
                    if (asset == null) return null;
                    return _typeParserService.Parse(asset.Value ?? "", ValueType);
                }
                return null;
            }
            set => throw new InvalidOperationException("Cannot set value for AssetItem");
        }

        public AssetItem() : base()
        {

        }

        public AssetItem(IServiceProvider services) : base(services)
        {
            InitializeServices(services);
        }

        public new void InitializeServices(IServiceProvider provider)
        {
            base.InitializeServices(provider);
            _orchestratorService = provider.GetRequiredService<OrchestratorService>();
        }

    }
}
