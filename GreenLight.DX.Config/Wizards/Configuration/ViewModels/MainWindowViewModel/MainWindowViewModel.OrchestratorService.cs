using GreenLight.DX.Shared.Services.Orchestrator;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Studio.Activities.Api;

namespace GreenLight.DX.Config.Wizards.Configuration.ViewModels
{
    public partial class MainWindowViewModel
    {
        private OrchestratorService _orchestratorService;


        public void InitializeOrchestratorService()
        {
            _orchestratorService = _services.GetRequiredService<OrchestratorService>();
            Debug($"Initialized Orchestrator Service:\n{JsonConvert.SerializeObject(_orchestratorService, Formatting.Indented)}", nameof(InitializeOrchestratorService));
            LoadAssets();
        }

        public void LoadAssets()
        {
            Debug("Loading assets", nameof(LoadAssets));
            var foldersResponse = _orchestratorService.RefreshFolders();
            var assetsResponses = _orchestratorService.RefreshAssets();
            Debug($"{JsonConvert.SerializeObject(foldersResponse.Content, Formatting.Indented)}", nameof(foldersResponse));
            Debug($"{JsonConvert.SerializeObject(assetsResponses.Select(r => r.Content), Formatting.Indented)}", nameof(assetsResponses));
            Debug($"{_orchestratorService.Assets.Count} folders and {_orchestratorService.Assets.Aggregate(0, (agg, kvp) => agg + kvp.Value.Count)} assets loaded", nameof(LoadAssets));
            //if (_workflowDesignApi == null) return;
            //try
            //{
            //    var busy = await _workflowDesignApi.BusyService.Begin("Loading assets...");
            //    Debug("Loading assets started.", context: "LoadAssets");

            //    var folders = (await _workflowDesignApi.OrchestratorApiService.AssetApiService.GetAssetFolders(100)).ToList();
            //    await busy.SetStatus($"{folders.Count} folders found");

            //    AssetsMap.Clear();
            //    for (var i = 0; i < folders.Count; i++)
            //    {
            //        var folder = folders[i];
            //        await busy.SetStatus($"Loading assets in '{folder}' ({i + 1}/{folders.Count}). Total Assets Loaded: {AssetsMap.Aggregate(0, (acc, curr) => acc + curr.Value.Count())}");
            //        var assets = await _workflowDesignApi.OrchestratorApiService.AssetApiService.GetAssets(new AssetRequestParameters() { }, folder);
            //        AssetsMap.Add(new KeyValuePair<string, IEnumerable<string>>(folder, assets));
            //    }
            //    OnPropertyChanged(nameof(AssetsMap));
            //    await busy.DisposeAsync();
            //    Debug($"{AssetsMap.Aggregate(0, (acc, curr) => acc + curr.Value.Count())} assets loaded.", context: "LoadAssets");

            //}
            //catch (Exception ex)
            //{
            //    Error($"Error loading assets: {ex.Message}", context: "LoadAssets");
            //}
        }
    }
}
