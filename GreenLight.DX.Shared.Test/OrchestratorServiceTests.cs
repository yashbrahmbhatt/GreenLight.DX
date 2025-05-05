using GreenLight.DX.Shared.Services.Orchestrator;
using GreenLight.DX.Shared.Services.Orchestrator.GetAssets;
using GreenLight.DX.Shared.Services.Orchestrator.GetBucketFiles;
using GreenLight.DX.Shared.Services.Orchestrator.GetBuckets;
using GreenLight.DX.Shared.Services.Orchestrator.GetFolders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Shared.Test
{
    [TestClass]
    public class OrchestratorServiceIntegrationTests
    {
        private readonly string _baseUrl = "https://cloud.uipath.com/yashbdev"; // Replace with your Orchestrator URL
        private readonly string _clientId = "806c068d-1201-4137-8484-4d440593c09c";        // Replace with your Client ID
        private readonly string _clientSecret = "P%5Er45%25cWTU%3F%25lqFK";    // Replace with your Client Secret

        private OrchestratorService _orchestratorService;

        [TestInitialize]
        public void Setup()
        {
            // Ensure you have valid BaseURL, ClientId, and ClientSecret configured
            if (string.IsNullOrEmpty(_baseUrl) || string.IsNullOrEmpty(_clientId) || string.IsNullOrEmpty(_clientSecret))
            {
                Assert.Inconclusive("Orchestrator base URL, client ID, and client secret must be configured for integration tests.");
                return;
            }
            _orchestratorService = new OrchestratorService(_baseUrl, _clientId, _clientSecret);
        }

        [TestMethod]
        public async Task UpdateToken_WithCredentials_ShouldRetrieveToken()
        {
            // Arrange (done in TestInitialize)

            // Act
            await _orchestratorService.UpdateToken();

            // Assert
            Assert.IsNotNull(_orchestratorService.Token);
            Assert.AreNotEqual(string.Empty, _orchestratorService.Token);
        }

        [TestMethod]
        public async Task RefreshFolders_ShouldPopulateFoldersCollection()
        {
            // Arrange
            await _orchestratorService.UpdateToken(); // Ensure token is available

            // Act
            await _orchestratorService.RefreshFolders();

            // Assert
            Assert.IsNotNull(_orchestratorService.Folders);
            Assert.IsTrue(_orchestratorService.Folders.Count >= 0); // Could be 0 if no folders
            Assert.IsInstanceOfType(_orchestratorService.Folders, typeof(ObservableCollection<Folder>));
        }

        [TestMethod]
        public async Task RefreshAssets_ShouldPopulateAssetsCollection()
        {
            // Arrange
            await _orchestratorService.UpdateToken();
            await _orchestratorService.RefreshFolders(); // Need folders to fetch assets

            // Act
            await _orchestratorService.RefreshAssets();

            // Assert
            Assert.IsNotNull(_orchestratorService.Assets);
            // Depending on your Orchestrator setup, there might be no assets.
            // At least ensure the collection is populated for existing folders.
            if (_orchestratorService.Folders.Any())
            {
                Assert.IsTrue(_orchestratorService.Assets.Any(a => a.Key.Id == _orchestratorService.Folders.First().Id));
            }
            Assert.IsInstanceOfType(_orchestratorService.Assets, typeof(ObservableCollection<KeyValuePair<Folder, ObservableCollection<Asset>>>));
        }

        [TestMethod]
        public async Task RefreshBuckets_ShouldPopulateBucketsCollection()
        {
            // Arrange
            await _orchestratorService.UpdateToken();
            await _orchestratorService.RefreshFolders(); // Need folders to fetch buckets

            // Act
            await _orchestratorService.RefreshBuckets();

            // Assert
            Assert.IsNotNull(_orchestratorService.Buckets);
            // Similar to assets, buckets might not exist in all folders.
            if (_orchestratorService.Folders.Any())
            {
                Assert.IsTrue(_orchestratorService.Buckets.Any(b => b.Key.Id == _orchestratorService.Folders.First().Id));
            }
            Assert.IsInstanceOfType(_orchestratorService.Buckets, typeof(ObservableCollection<KeyValuePair<Folder, ObservableCollection<Bucket>>>));
        }

        [TestMethod]
        public async Task RefreshBucketFiles_ShouldPopulateBucketFilesCollection()
        {
            // Arrange
            await _orchestratorService.UpdateToken();
            await _orchestratorService.RefreshFolders();
            await _orchestratorService.RefreshBuckets(); // Need buckets to fetch files

            // Act
            await _orchestratorService.RefreshBucketFiles();

            // Assert
            Assert.IsNotNull(_orchestratorService.BucketFiles);
            // Bucket files depend on existing buckets.
            if (_orchestratorService.Buckets.Any())
            {
                Assert.IsTrue(_orchestratorService.BucketFiles.Any(bf => bf.Key.Id == _orchestratorService.Buckets.First().Key.Id));
            }
            Assert.IsInstanceOfType(_orchestratorService.BucketFiles, typeof(ObservableCollection<KeyValuePair<Bucket, ObservableCollection<BucketFile>>>));
        }

        //[TestMethod]
        //public async Task DownloadBucketFile_ShouldDownloadFileSuccessfully()
        //{
        //    // Arrange
        //    await _orchestratorService.UpdateToken();
        //    await _orchestratorService.RefreshFolders();
        //    await _orchestratorService.RefreshBuckets();
        //    await _orchestratorService.RefreshBucketFiles();

        //    // Find a bucket and a file within it (you might need to know your test data)
        //    var bucketToDownloadFrom = _orchestratorService.Buckets.FirstOrDefault(b => b.Value.Any());
        //    var bucketFileToDownload = bucketToDownloadFrom.Value.FirstOrDefault();

        //    if (bucketFileToDownload == null)
        //    {
        //        Assert.Inconclusive("No bucket or bucket file found for testing download. Ensure your Orchestrator has data.");
        //        return;
        //    }

        //    string downloadPath = FilePath.Combine(FilePath.GetTempPath(), bucketFileToDownload.Name);
        //    if (File.Exists(downloadPath)) File.Delete(downloadPath);

        //    // Act
        //    bool result = await _orchestratorService.DownloadBucketFile(bucketFileToDownload, bucketToDownloadFrom, downloadPath);

        //    // Assert
        //    Assert.IsTrue(result);
        //    Assert.IsTrue(File.Exists(downloadPath));
        //    Assert.IsTrue(new FileInfo(downloadPath).Length > 0); // Check if the file has content

        //    // Cleanup
        //    if (File.Exists(downloadPath)) File.Delete(downloadPath);
        //}
    }
}
