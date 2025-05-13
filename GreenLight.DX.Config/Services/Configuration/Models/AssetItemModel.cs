using GreenLight.DX.Shared.Services.Orchestrator;
using GreenLight.DX.Shared.Services.Orchestrator.GetAssets;
using GreenLight.DX.Shared.Services.Orchestrator.GetFolders;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Org.BouncyCastle.Math.EC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UiPath.Studio.Activities.Api;

namespace GreenLight.DX.Config.Services.Configuration.Models
{
    [Serializable]
    [XmlType(nameof(AssetItemModel))] // For XML serialization of derived type
    public class AssetItemModel : ConfigItemModel
    {
        [JsonProperty(nameof(AssetName))]
        public string AssetName {
            get {
                return AssetObject.Name;
            }
            set
            {
                if(_orchestratorService.Assets.FirstOrDefault(kvp => kvp.Key.DisplayName == AssetFolder).Value.FirstOrDefault(a => a.Name == value) != null)
                {
                    AssetObject = _orchestratorService.Assets.FirstOrDefault(kvp => kvp.Key.DisplayName == AssetFolder).Value.FirstOrDefault(a => a.Name == value);
                }
            }
        }

        [JsonProperty(nameof(AssetFolder))]
        public string AssetFolder
        {
            get
            {
                return FolderObject.DisplayName;
            }
            set
            {
                if (_orchestratorService.Folders.FirstOrDefault(f => f.DisplayName == value) != null)
                {
                    FolderObject = _orchestratorService.Folders.FirstOrDefault(f => f.DisplayName == value);
                }
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        public Asset AssetObject { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public Folder FolderObject { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public OrchestratorService _orchestratorService;

        [JsonIgnore]
        [XmlIgnore]
        public override object Value
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

        public AssetItemModel() : base()
        {

        }

        public AssetItemModel(IServiceProvider services) : base(services)
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
