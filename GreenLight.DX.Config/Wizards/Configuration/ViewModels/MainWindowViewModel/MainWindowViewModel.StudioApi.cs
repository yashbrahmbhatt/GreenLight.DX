using GreenLight.DX.Shared.Services.Orchestrator;
using Microsoft.Extensions.DependencyInjection;
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
        private IWorkflowDesignApi? _workflowDesignApi;
        private OrchestratorService _orchestratorService;


        public void InitializeStudioApis()
        {
            _workflowDesignApi = _services.GetRequiredService<IWorkflowDesignApi>();
            LoadAssets().Await();
        }

        public async Task LoadAssets()
        {
            await _orchestratorService.RefreshAssets();
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
