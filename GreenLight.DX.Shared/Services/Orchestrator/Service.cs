using GreenLight.DX.Shared.Services.Orchestrator.GetAssets;
using GreenLight.DX.Shared.Services.Orchestrator.GetBucketFileReadUri;
using GreenLight.DX.Shared.Services.Orchestrator.GetBucketFiles;
using GreenLight.DX.Shared.Services.Orchestrator.GetBuckets;
using GreenLight.DX.Shared.Services.Orchestrator.GetFolders;
using GreenLight.DX.Shared.Services.Orchestrator.GetToken;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Studio.Activities.Api;

namespace GreenLight.DX.Shared.Services.Orchestrator
{
    public class OrchestratorService
    {
        private readonly IWorkflowDesignApi _workflowDesignApi;
        private readonly RestClient _client = new RestClient();

        public string BaseURL { get; set; } = "";
        public string Token { get; set; } = "";
        public string ClientId { get; set; } = "";
        public string ClientSecret { get; set; } = "";
        public string[] Scopes { get; set; } = new string[] { "OR.Assets.Read", "OR.Folders.Read" };

        public ObservableCollection<Folder> Folders { get; set; } = new ObservableCollection<Folder>();
        public ObservableCollection<KeyValuePair<Folder, ObservableCollection<Asset>>> Assets { get; set; } = new ObservableCollection<KeyValuePair<Folder, ObservableCollection<Asset>>>();
        public ObservableCollection<KeyValuePair<Folder, ObservableCollection<Bucket>>> Buckets { get; set; } = new ObservableCollection<KeyValuePair<Folder, ObservableCollection<Bucket>>>();
        public ObservableCollection<KeyValuePair<Bucket, ObservableCollection<BucketFile>>> BucketFiles { get; set; } = new ObservableCollection<KeyValuePair<Bucket, ObservableCollection<BucketFile>>>();

        public OrchestratorService(IServiceProvider services)
        {
            _workflowDesignApi = services.GetRequiredService<IWorkflowDesignApi>();
            BaseURL = _workflowDesignApi.AccessProvider.GetResourceUrl("OR.Assets.Read OR.Folders.Read").Result.TrimEnd('/');
        }

        public OrchestratorService(string baseUrl, string clientId, string clientSecret)
        {
            BaseURL = baseUrl;
            ClientId = clientId;
            ClientSecret = clientSecret;
        }
        public async Task UpdateToken(bool force = false)
        {
            if (_workflowDesignApi == null)
            {
                var url = $"{BaseURL}/identity_/connect/token";
                var request = new RestRequest(url, Method.Post);
                request.AddParameter("client_id", ClientId);
                request.AddParameter("client_secret", ClientSecret);
                request.AddParameter("grant_type", "client_credentials");
                request.AddParameter("scope", string.Join(" ", Scopes));
                var response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    var token = Newtonsoft.Json.JsonConvert.DeserializeObject<GetTokenResponse>(response.Content ?? throw new Exception("API Response Error"));
                    Token = token?.AccessToken ?? throw new Exception("Token not found in response");
                } else
                {
                    throw new Exception("Failed to get token");
                }
            }
            else
            {
                Token = await _workflowDesignApi.AccessProvider.GetAccessToken("OR.Assets.Read OR.Folders.Read", force);
            }
        }

        public async Task RefreshAssets()
        {
            Assets.Clear();
            foreach (var folder in Folders)
            {
                var url = $"{BaseURL}/odata/Assets";
                var request = new RestRequest(url, Method.Get);
                await UpdateToken();
                request.AddHeader("Authorization", $"Bearer {Token}");
                request.AddHeader("X-UIPATH-OrganizationUnitId", folder.Id?.ToString() ?? throw new Exception("Folder has no id"));
                var response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    var assets = Newtonsoft.Json.JsonConvert.DeserializeObject<GetAssetsResponse>(response.Content ?? throw new Exception("API Response Error"));
                    var assetsCollection = new ObservableCollection<Asset>(assets?.Assets ?? new List<Asset>());
                    Assets.Add(new KeyValuePair<Folder, ObservableCollection<Asset>>(folder, assetsCollection));
                }

            }
        }

        public async Task RefreshFolders()
        {
            var url = $"{BaseURL}/odata/Folders";
            var request = new RestRequest(url, Method.Get);
            await UpdateToken();
            request.AddHeader("Authorization", $"Bearer {Token}");
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                Folders.Clear();
                var folders = Newtonsoft.Json.JsonConvert.DeserializeObject<GetFoldersResponse>(response.Content ?? throw new Exception("API Response Error"));
                var folderCollection = new ObservableCollection<Folder>(folders?.Folders ?? new List<Folder>());
                foreach (var folder in folderCollection)
                {
                    Folders.Add(folder);
                }
            }
        }

        public async Task RefreshBuckets()
        {
            var url = $"{BaseURL}/odata/Buckets";
            await UpdateToken();
            Buckets.Clear();
            foreach (var folder in Folders)
            {
                var request = new RestRequest(url, Method.Get);
                request.AddHeader("Authorization", $"Bearer {Token}");
                request.AddHeader("X-UIPATH-OrganizationUnitId", folder.Id?.ToString() ?? throw new Exception("Folder has no id"));
                var response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    var buckets = Newtonsoft.Json.JsonConvert.DeserializeObject<GetBucketsResponse>(response.Content ?? throw new Exception("API Response Error"));
                    var bucketCollection = new ObservableCollection<Bucket>(buckets?.Buckets ?? new List<Bucket>());
                    Buckets.Add(new KeyValuePair<Folder, ObservableCollection<Bucket>>(folder, bucketCollection));
                }

            }
        }

        public async Task RefreshBucketFiles()
        {
            await UpdateToken();
            BucketFiles.Clear();
            foreach (var folder in Folders)
            {
                var buckets = Buckets.Where(b => b.Key.Id == folder.Id).Select(b => b.Value).FirstOrDefault();
                if (buckets == null) continue;
                foreach (var bucket in buckets)
                {
                    var url = $"{BaseURL}/odata/Buckets({bucket.Id})/UiPath.Server.Configuration.OData.GetFiles?directory=/&recursive=true";
                    var request = new RestRequest(url, Method.Get);
                    request.AddHeader("Authorization", $"Bearer {Token}");
                    var response = await _client.ExecuteAsync(request);
                    if (response.IsSuccessful)
                    {
                        var bucketFiles = Newtonsoft.Json.JsonConvert.DeserializeObject<GetBucketFilesResponse>(response.Content ?? throw new Exception("API Response Error"));
                        var bucketCollection = new ObservableCollection<BucketFile>(bucketFiles?.BucketFiles ?? new List<BucketFile>());
                        BucketFiles.Add(new KeyValuePair<Bucket, ObservableCollection<BucketFile>>(bucket, bucketCollection));
                    }
                }
            }
        }

        public async Task<bool> DownloadBucketFile(Bucket bucket, BucketFile bucketFile, string downloadPath)
        {
            await UpdateToken(); // Ensure token is up-to-date

            var url = $"{BaseURL}/odata/Buckets({bucket.Id})/UiPath.Server.Configuration.OData.GetReadUri?path={bucketFile.FullPath}";
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Authorization", $"Bearer {Token}");

            var response = await _client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                var res = JsonConvert.DeserializeObject<GetBucketFileReadUriResponse>(response.Content ?? throw new Exception("API Response Error"));
                if (res == null || string.IsNullOrEmpty(res.Uri)) return false;

                var downloadReq = new RestRequest(res.Uri, Method.Get);
                var downloadResponse = await _client.DownloadDataAsync(downloadReq); // Use DownloadDataAsync

                if (downloadResponse != null)
                {
                    try
                    {
                        // Ensure the directory exists
                        string directory = Path.GetDirectoryName(downloadPath) ?? throw new Exception("Could not determine download directory");
                        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        // Write the downloaded data to the file
                        await File.WriteAllBytesAsync(downloadPath, downloadResponse);
                        return true; // Download successful
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error saving downloaded file: {ex.Message}");
                        return false; // Download failed
                    }
                }
                else
                {
                    Console.WriteLine("Download response was null.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"Error retrieving download URL: {response.ErrorMessage}");
                return false;
            }
        }
    }
}
