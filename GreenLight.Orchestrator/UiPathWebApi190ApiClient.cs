using System.Net.Http.Headers;
using System.Text;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using OneOf;
using Microsoft.Extensions.Configuration;

// Generated using Postman2CSharp https://postman2csharp.com/Convert
namespace UiPathWebApi190
{
    public class UiPathWebApi190ApiClient : IUiPathWebApi190ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "cloud.uipath.com/yashbdev/yashbdev/orchestrator_";
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _accessTokenUrl;
        private readonly string _authUrl;
        private readonly string _scope;
        public UiPathWebApi190ApiClient(IConfiguration config)
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri($"https://{_baseUrl}/");
            }
    
            _clientId = config["Path:ToOAuthClientId"];
            _clientSecret = config["Path:ToOAuthClientSecret"];
            _accessTokenUrl = config["Path:ToAccessTokenUrl"];
            _authUrl = config["Path:ToAuthTokenUrl"];
            _scope = config["Path:ToScope"];
        }
        // You must implement this yourself
        private async Task<string> GetAccessToken()
        {
            throw new NotImplementedException();
        }
    
        // You must implement this yourself
        private async Task<string> GetRefreshToken()
        {
            throw new NotImplementedException();
        }
    
        // You must implement this yourself
        private async Task PersistAccessToken(string accessToken)
        {
            throw new NotImplementedException();
        }
    
        // You must implement this yourself
        private async Task PersistRefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }
    
        public async Task DoAuth()
        {
            var oauthQueryParameters = new OAuth2QueryParameters();
            oauthQueryParameters.ResponseType = "code";
            oauthQueryParameters.ClientId = _clientId;
            oauthQueryParameters.RedirectUrl = string.Empty;
            oauthQueryParameters.Scope = _scope;
            var queryString = QueryHelpers.AddQueryString("https://cloud.uipath.com/identity_/connect/authorize", oauthQueryParameters.ToDictionary());
            await _httpClient.GetAsync(queryString);
        }
    
        public async Task Auth(string code)
        {
            var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(_clientId + ":" + _clientSecret));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encoded);
    
            var oauthQueryParameters = new OAuth2QueryParameters();
            oauthQueryParameters.Code = code;
            oauthQueryParameters.GrantType = "authorization_code";
            oauthQueryParameters.RedirectUrl = string.Empty;
            oauthQueryParameters.Scope = _scope;
            var response = await _httpClient.PostAsync("https://cloud.uipath.com/identity_/connect/token", new FormUrlEncodedContent(oauthQueryParameters.ToDictionary()));
        }
    
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Read.
        /// Required permissions: Users.View.
        /// </summary>
        public async Task<List<GetsDirectoryPermissionsResponse>> GetsDirectoryPermissions(GetsDirectoryPermissionsParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/DirectoryService/GetDirectoryPermissions", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<List<GetsDirectoryPermissionsResponse>>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Read.
        /// Required permissions: (Users.View or Units.Edit or SubFolders.Edit).
        /// </summary>
        public async Task<List<GetsDomainsResponse>> GetsDomains()
        {
            return await _httpClient.GetFromNewtonsoftJsonAsync<List<GetsDomainsResponse>>($"api/DirectoryService/GetDomains");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Read.
        /// Required permissions: (Users.View or Units.Edit or SubFolders.Edit).
        /// </summary>
        public async Task<EmptyResponse> RchestratorUserIdBySearchingForTheDomainUserInformation(RchestratorUserIdBySearchingForTheDomainUserInformationParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/DirectoryService/GetDomainUserId", parametersDict);
            var response = await _httpClient.GetAsync(queryString);
            if (response.StatusCode is HttpStatusCode.OK or HttpStatusCode.NotFound)
            {
                return await response.ReadNewtonsoftJsonAsync<EmptyResponse>();
            }
            throw new Exception($"RchestratorUserIdBySearchingForTheDomainUserInformation: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Read.
        /// Required permissions: (Users.View or Units.Edit or SubFolders.Edit).
        /// </summary>
        public async Task<List<SearchUsersAndGroupsResponse>> SearchUsersAndGroups(SearchUsersAndGroupsParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/DirectoryService/SearchForUsersAndGroups", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<List<SearchUsersAndGroupsResponse>>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Write.
        /// Required permissions: (Units.Delete or SubFolders.Delete - Deletes any folder or only if user has SubFolders.Delete 
        /// permission on the provided folder).
        /// </summary>
        public async Task<Stream> RUserAssociationsexistInThisFolderOrAnyOfItsDescendants(RUserAssociationsexistInThisFolderOrAnyOfItsDescendantsParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/Folders/DeleteByKey", parametersDict);
            var response = await _httpClient.DeleteAsync(queryString);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<HeCurrentUserHasAccessToTheResponseWillBeAListOfFoldersResponse> HeCurrentUserHasAccessToTheResponseWillBeAListOfFolders(HeCurrentUserHasAccessToTheResponseWillBeAListOfFoldersParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/Folders/GetAllForCurrentUser", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<HeCurrentUserHasAccessToTheResponseWillBeAListOfFoldersResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Write.
        /// Required permissions: (Units.Edit or SubFolders.Edit - Edits any folder or edits only if user has SubFolders.Edit 
        /// permission on the provided folder).
        /// </summary>
        public async Task<Stream> EditsAFolder(EditsAFolderParameters queryParameters, EditsAFolderRequest request)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/Folders/PatchNameDescription", parametersDict);
            var response = await _httpClient.PatchAsNewtonsoftJsonAsync(queryString, request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth authentication is not supported.
        /// Requires authentication.
        /// </summary>
        public async Task<List<RsTheUserHasactuallyBeenAssignedToTheFoldersWillBeMarkeResponse>> RsTheUserHasactuallyBeenAssignedToTheFoldersWillBeMarke()
        {
            return await _httpClient.GetFromNewtonsoftJsonAsync<List<RsTheUserHasactuallyBeenAssignedToTheFoldersWillBeMarkeResponse>>($"api/FoldersNavigation/GetAllFoldersForCurrentUser");
        }
    
        /// <summary>
        /// OAuth authentication is not supported.
        /// Required permissions: (Units.View - Gets roles from all folders) and (SubFolders.View - Gets roles only 
        /// from folders where caller has SubFolders.View permission).
        /// </summary>
        public async Task<HeDistinctionBetweenTheFoldersAssignedDirectlyToTheUserResponse> HeDistinctionBetweenTheFoldersAssignedDirectlyToTheUser(HeDistinctionBetweenTheFoldersAssignedDirectlyToTheUserParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/FoldersNavigation/GetAllRolesForUser", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<HeDistinctionBetweenTheFoldersAssignedDirectlyToTheUserResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth authentication is not supported.
        /// Requires authentication.
        /// </summary>
        public async Task<DesignTheListOfAncestorsForTheGivenFolderIsAlsoReturnedResponse> DesignTheListOfAncestorsForTheGivenFolderIsAlsoReturned(DesignTheListOfAncestorsForTheGivenFolderIsAlsoReturnedParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/FoldersNavigation/GetFolderNavigationContextForCurrentUser", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<DesignTheListOfAncestorsForTheGivenFolderIsAlsoReturnedResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth authentication is not supported.
        /// Requires authentication.
        /// </summary>
        public async Task<RedSubsetPaginatedOfTheFoldersTheCurrentUserHasAccessToResponse> RedSubsetPaginatedOfTheFoldersTheCurrentUserHasAccessTo(RedSubsetPaginatedOfTheFoldersTheCurrentUserHasAccessToParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/FoldersNavigation/GetFoldersForCurrentUser", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<RedSubsetPaginatedOfTheFoldersTheCurrentUserHasAccessToResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Write.
        /// Required permissions: Jobs.Edit.
        /// </summary>
        /// <param name="inboxId">
        /// (Required) 
        /// </param>
        public async Task<Stream> DeliverPayloadForTriggerInboxId(string inboxId)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"api/JobTriggers/DeliverPayload/{inboxId}", headers);
            if (response.StatusCode is HttpStatusCode.Accepted or HttpStatusCode.AlreadyReported)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"DeliverPayloadForTriggerInboxId: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <param name="inboxId">
        /// (Required) 
        /// </param>
        public async Task<OneOf<GetPayloadForTriggerInboxIdOKResponse, Stream>> GetPayloadForTriggerInboxId(string inboxId)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.GetAsync($"api/JobTriggers/GetPayload/{inboxId}", headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<GetPayloadForTriggerInboxIdOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"GetPayloadForTriggerInboxId: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Administration or OR.Administration.Write.
        /// Requires authentication.
        /// </summary>
        public async Task<OneOf<AcquireLicenseUnitsOKResponse, Stream>> AcquireLicenseUnits(AcquireLicenseUnitsRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"api/Licensing/Acquire", request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<AcquireLicenseUnitsOKResponse>();
            }
            if (response.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.Conflict or HttpStatusCode.ServiceUnavailable)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"AcquireLicenseUnits: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Administration or OR.Administration.Write.
        /// Requires authentication.
        /// </summary>
        public async Task<OneOf<ReleaseAcquiredLicenseUnitsOKResponse, Stream>> ReleaseAcquiredLicenseUnits(ReleaseAcquiredLicenseUnitsRequest request)
        {
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"api/Licensing/Release", request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<ReleaseAcquiredLicenseUnitsOKResponse>();
            }
            if (response.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.Conflict or HttpStatusCode.ServiceUnavailable)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"ReleaseAcquiredLicenseUnits: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Monitoring or OR.Monitoring.Write.
        /// Required permissions: (Logs.Create).
        /// Example of jMessage parameter.
        ///             
        ///      {
        ///          "message": "TTT execution started",
        ///          "level": "Information",
        ///          "timeStamp": "2017-01-18T14:46:07.4152893+02:00",
        ///          "windowsIdentity": "DESKTOP-1L50L0P\\WindowsUser",
        ///          "agentSessionId": "00000000-0000-0000-0000-000000000000",
        ///          "processName": "TTT",
        ///          "fileName": "Main",
        ///          "jobId": "8066c309-cef8-4b47-9163-b273fc14cc43"
        ///      }
        /// DEPRECATED: 
        /// Use SubmitLogs instead
        /// Please refer to https://docs.uipath.com/orchestrator/reference
        /// </summary>
        public async Task<Stream> InsertsALogEntryWithASpecifiedMessageInJSONFormat(InsertsALogEntryWithASpecifiedMessageInJSONFormatRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"api/Logs", request);
            if (response.StatusCode is HttpStatusCode.OK or HttpStatusCode.BadRequest or HttpStatusCode.RequestTimeout)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"InsertsALogEntryWithASpecifiedMessageInJSONFormat: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Monitoring or OR.Monitoring.Write.
        /// Required permissions: Logs.Create.
        /// Example of log entry:
        ///      {
        ///          "message": "TTT execution started",
        ///          "level": "Information",
        ///          "timeStamp": "2017-01-18T14:46:07.4152893+02:00",
        ///          "windowsIdentity": "DESKTOP-1L50L0P\\WindowsUser",
        ///          "agentSessionId": "00000000-0000-0000-0000-000000000000",
        ///          "processName": "TTT",
        ///          "fileName": "Main",
        ///          "jobId": "8066c309-cef8-4b47-9163-b273fc14cc43"
        ///      }
        /// </summary>
        public async Task<Stream> InsertsACollectionOfLogEntriesEachInASpecificJSONFormat()
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"api/Logs/SubmitLogs");
            if (response.StatusCode is HttpStatusCode.OK or HttpStatusCode.BadRequest or HttpStatusCode.RequestTimeout)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"InsertsACollectionOfLogEntriesEachInASpecificJSONFormat: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Administration or OR.Administration.Write.
        /// Host only. Requires authentication.
        /// </summary>
        public async Task<Stream> EndsAMaintenanceWindow(EndsAMaintenanceWindowParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/Maintenance/End", parametersDict);
            var response = await _httpClient.PostAsync(queryString);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Administration or OR.Administration.Read.
        /// Host only. Required permissions: Audit.View.
        /// </summary>
        public async Task<GetsTheHostAdminLogsResponse> GetsTheHostAdminLogs(GetsTheHostAdminLogsParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/Maintenance/Get", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTheHostAdminLogsResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Administration or OR.Administration.Write.
        /// Host only. Requires authentication.
        /// </summary>
        public async Task<Stream> StartsAMaintenanceWindow(StartsAMaintenanceWindowParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/Maintenance/Start", parametersDict);
            var response = await _httpClient.PostAsync(queryString);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<EmptyResponse> EturnsTheFeedIdForAUserAssignedFolderHavingSpecificFeed(EturnsTheFeedIdForAUserAssignedFolderHavingSpecificFeedParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/PackageFeeds/GetFolderFeed", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<EmptyResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Write.
        /// Required permissions: (Processes.Delete).
        /// </summary>
        public async Task<Stream> ReleasesDeleteByKey(ReleasesDeleteByKeyParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/Releases/DeleteByKey", parametersDict);
            var response = await _httpClient.DeleteAsync(queryString);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Monitoring or OR.Monitoring.Read.
        /// Required permissions: License.View.
        /// </summary>
        public async Task<List<GetsTheConsumptionLicensingUsageStatisticsResponse>> GetsTheConsumptionLicensingUsageStatistics(GetsTheConsumptionLicensingUsageStatisticsParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/Stats/GetConsumptionLicenseStats", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<List<GetsTheConsumptionLicensingUsageStatisticsResponse>>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Monitoring or OR.Monitoring.Read.
        /// Requires authentication.
        /// Returns the name and the total number of entities registered in Orchestrator for a set of entities.
        /// All the counted entity types can be seen in the result below.
        ///      [
        ///            {
        ///              "title": "Processes",
        ///              "count": 1
        ///            },
        ///            {
        ///              "title": "Assets",
        ///              "count": 0
        ///            },
        ///            {
        ///              "title": "Queues",
        ///              "count": 0
        ///            },
        ///            {
        ///              "title": "Schedules",
        ///              "count": 0
        ///            }
        ///      ]
        /// </summary>
        public async Task<List<TheTotalNumberOfVariousEntitiesRegisteredInOrchestratorResponse>> TheTotalNumberOfVariousEntitiesRegisteredInOrchestrator()
        {
            return await _httpClient.GetFromNewtonsoftJsonAsync<List<TheTotalNumberOfVariousEntitiesRegisteredInOrchestratorResponse>>($"api/Stats/GetCountStats");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Monitoring or OR.Monitoring.Read.
        /// Required permissions: Jobs.View.
        /// Returns the total number of Successful, Faulted and Canceled jobs respectively.
        /// Example of returned result:
        ///     [
        ///           {
        ///             "title": "Successful",
        ///             "count": 0
        ///           },
        ///           {
        ///             "title": "Faulted",
        ///             "count": 0
        ///           },
        ///           {
        ///             "title": "Canceled",
        ///             "count": 0
        ///           }
        ///     ]
        /// </summary>
        public async Task<List<GetsTheTotalNumberOfJobsAggregatedByJobStateResponse>> GetsTheTotalNumberOfJobsAggregatedByJobState()
        {
            return await _httpClient.GetFromNewtonsoftJsonAsync<List<GetsTheTotalNumberOfJobsAggregatedByJobStateResponse>>($"api/Stats/GetJobsStats");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Monitoring or OR.Monitoring.Read.
        /// Required permissions: License.View.
        /// </summary>
        public async Task<List<GetsTheLicensingUsageStatisticsResponse>> GetsTheLicensingUsageStatistics(GetsTheLicensingUsageStatisticsParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/Stats/GetLicenseStats", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<List<GetsTheLicensingUsageStatisticsResponse>>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Monitoring or OR.Monitoring.Read.
        /// Required permissions: Robots.View.
        /// Returns the total number of Available, Busy, Disconnected and Unresponsive robots respectively.
        /// Example of returned result:
        ///     [
        ///           {
        ///             "title": "Available",
        ///             "count": 1
        ///           },
        ///           {
        ///             "title": "Busy",
        ///             "count": 0
        ///           },
        ///           {
        ///             "title": "Disconnected",
        ///             "count": 1
        ///           },
        ///           {
        ///             "title": "Unresponsive",
        ///             "count": 0
        ///           }
        ///     ]
        /// </summary>
        public async Task<List<GetsTheTotalNumberOfRobotsAggregatedByRobotStateResponse>> GetsTheTotalNumberOfRobotsAggregatedByRobotState()
        {
            return await _httpClient.GetFromNewtonsoftJsonAsync<List<GetsTheTotalNumberOfRobotsAggregatedByRobotStateResponse>>($"api/Stats/GetSessionsStats");
        }
    
        public async Task<Stream> ReturnsWhetherTheCurrentEndpointShouldBeServingTraffic()
        {
            var response = await _httpClient.GetAsync($"api/Status/Get");
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// Required permissions: Webhooks.Create or Webhooks.Edit.
        /// </summary>
        public async Task<StatusVerifyHostAvailibilityResponse> StatusVerifyHostAvailibility(StatusVerifyHostAvailibilityParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/Status/VerifyHostAvailibility", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<StatusVerifyHostAvailibilityResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSetExecutions or OR.TestSetExecutions.Write.
        /// Required permissions: TestSetExecutions.Edit.
        /// Responses:
        /// 202 Accepted
        /// 403 If the caller doesn't have permissions to cancel a test set execution
        /// </summary>
        public async Task<Stream> CancelsTheSpecifiedTestCaseExecution(CancelsTheSpecifiedTestCaseExecutionParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/TestAutomation/CancelTestCaseExecution", parametersDict);
            var response = await _httpClient.PostAsync(queryString, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSetExecutions or OR.TestSetExecutions.Write.
        /// Required permissions: TestSetExecutions.Edit.
        /// Responses:
        /// 202 Accepted
        /// 403 If the caller doesn't have permissions to cancel a test set execution
        /// </summary>
        public async Task<Stream> CancelsTheSpecifiedTestSetExecution(CancelsTheSpecifiedTestSetExecutionParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/TestAutomation/CancelTestSetExecution", parametersDict);
            var response = await _httpClient.PostAsync(queryString, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSets or OR.TestSets.Write.
        /// Required permissions: TestSets.Create.
        /// Responses:
        /// 201 Created returns test set Id
        /// 403 If the caller doesn't have permissions to create a test set
        /// </summary>
        public async Task<EmptyResponse> TypeAPIThisEndpointItIsSupposedToBeUsedByAPIIntegration(TypeAPIThisEndpointItIsSupposedToBeUsedByAPIIntegrationRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PostNewtonsoftJsonAsync<EmptyResponse>($"api/TestAutomation/CreateTestSetForReleaseVersion", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSetExecutions or OR.TestSetExecutions.Read.
        /// Required permissions: TestSetExecutions.View.
        /// Responses:
        /// 200 OK
        /// 404 If the test case assertion is not found or the screenshot storage location is not found
        /// </summary>
        public async Task<Stream> GetTheScreenshotForTheSpecifiedTestCaseAssertion(GetTheScreenshotForTheSpecifiedTestCaseAssertionParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" },
                { $"Accept", $"application/octet-stream" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/TestAutomation/GetAssertionScreenshot", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Read.
        /// Requires authentication.
        /// Responses:
        /// 200 OK
        /// 403 If the caller doesn't have permissions to retrieve packages
        /// 404 If there is no test case with the specified UniqueId
        /// </summary>
        public async Task<AgeIdentifierAndTheLatestVersionForTheSpecifiedTestCaseResponse> AgeIdentifierAndTheLatestVersionForTheSpecifiedTestCase(AgeIdentifierAndTheLatestVersionForTheSpecifiedTestCaseParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/TestAutomation/GetPackageInfoByTestCaseUniqueId", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<AgeIdentifierAndTheLatestVersionForTheSpecifiedTestCaseResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Read.
        /// Required permissions: Processes.View.
        /// Responses:
        /// 200 OK
        /// 404 If there is no release for the specified package identifier
        /// </summary>
        public async Task<List<RAndVersionCrossFolderWhenNoCurrentFolderIsSentByHeaderResponse>> RAndVersionCrossFolderWhenNoCurrentFolderIsSentByHeader(RAndVersionCrossFolderWhenNoCurrentFolderIsSentByHeaderParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/TestAutomation/GetReleasesForPackageVersion", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<List<RAndVersionCrossFolderWhenNoCurrentFolderIsSentByHeaderResponse>>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSetExecutions or OR.TestSetExecutions.Read.
        /// Required permissions: TestSetExecutions.View.
        /// Responses:
        /// 200 OK
        /// 404 If the test case execution attachment is not found or the storage location is not found
        /// </summary>
        public async Task<Stream> TheAttachmentForTheSpecifiedTestCaseExecutionAttachment(TheAttachmentForTheSpecifiedTestCaseExecutionAttachmentParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" },
                { $"Accept", $"application/octet-stream" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/TestAutomation/GetTestCaseExecutionAttachment", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSetExecutions or OR.TestSetExecutions.Write.
        /// Required permissions: TestSetExecutions.View.
        /// Responses:
        /// 200 OK
        /// 404 If there is no test case execution for the specified identifier
        /// </summary>
        public async Task<List<TestCaseExecutionAttachmentsFilteredByIdentifierAndTagsResponse>> TestCaseExecutionAttachmentsFilteredByIdentifierAndTags(TestCaseExecutionAttachmentsFilteredByIdentifierAndTagsRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PostNewtonsoftJsonAsync<List<TestCaseExecutionAttachmentsFilteredByIdentifierAndTagsResponse>>($"api/TestAutomation/GetTestCaseExecutionAttachments", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSetExecutions or OR.TestSetExecutions.Read.
        /// Required permissions: TestSetExecutions.View.
        /// Responses:
        /// 200 OK
        /// 404 If the test set execution attachment is not found or the storage location is not found
        /// </summary>
        public async Task<Stream> TTheAttachmentForTheSpecifiedTestSetExecutionAttachment(TTheAttachmentForTheSpecifiedTestSetExecutionAttachmentParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" },
                { $"Accept", $"application/octet-stream" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/TestAutomation/GetTestSetExecutionAttachment", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSetExecutions or OR.TestSetExecutions.Write.
        /// Required permissions: TestSetExecutions.View.
        /// Responses:
        /// 200 OK
        /// 404 If there is no test set execution for the specified identifier
        /// </summary>
        public async Task<List<LTestSetExecutionAttachmentsFilteredByIdentifierAndTagsResponse>> LTestSetExecutionAttachmentsFilteredByIdentifierAndTags(LTestSetExecutionAttachmentsFilteredByIdentifierAndTagsRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PostNewtonsoftJsonAsync<List<LTestSetExecutionAttachmentsFilteredByIdentifierAndTagsResponse>>($"api/TestAutomation/GetTestSetExecutionAttachments", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSetExecutions or OR.TestSetExecutions.Write.
        /// Required permissions: TestSetExecutions.Create.
        /// Responses:
        /// 200 OK
        /// 403 If the caller doesn't have permissions to execute test sets
        /// 404 If one or more test cases were not found
        /// </summary>
        public async Task<List<PecifiedTestCaseExecutionsWithinTheSameTestSetExecutionResponse>> PecifiedTestCaseExecutionsWithinTheSameTestSetExecution(PecifiedTestCaseExecutionsWithinTheSameTestSetExecutionRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PostNewtonsoftJsonAsync<List<PecifiedTestCaseExecutionsWithinTheSameTestSetExecutionResponse>>($"api/TestAutomation/ReexecuteTestCases", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSetExecutions or OR.TestSetExecutions.Write.
        /// Required permissions: TestSetExecutions.Create.
        /// Responses:
        /// 200 OK returns test set execution Id
        /// 403 If the caller doesn't have permissions to execute a test set
        /// 404 If the test set was not found
        /// </summary>
        public async Task<EmptyResponse> StartATestSetExecution(StartATestSetExecutionParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/TestAutomation/StartTestSetExecution", parametersDict);
            return await _httpClient.PostFromNewtonsoftJsonAsync<EmptyResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSetExecutions or OR.TestSetExecutions.Write.
        /// Required permissions: TestSetExecutions.Create.
        /// Responses:
        /// 200 OK returns test set execution Id
        /// 403 If the caller doesn't have permissions to execute a test set
        /// 404 If the test set was not found
        /// </summary>
        public async Task<EmptyResponse> StartATestSetExecutionWithAdditionalOptions(StartATestSetExecutionWithAdditionalOptionsParameters queryParameters, StartATestSetExecutionWithAdditionalOptionsRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/TestAutomation/StartTestSetExecutionWithOptions", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<EmptyResponse>(queryString, request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestDataQueues or OR.TestDataQueues.Write.
        /// Required permissions: TestDataQueueItems.Create.
        /// Responses:
        /// 201 Returns the added test data queue item
        /// 403 If the caller doesn't have permissions to create test data queue items
        /// 409 If the test data queue item content violates the content JSON schema set on the queue
        /// </summary>
        public async Task<AddANewTestDataQueueItemResponse> AddANewTestDataQueueItem(AddANewTestDataQueueItemRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PostNewtonsoftJsonAsync<AddANewTestDataQueueItemResponse>($"api/TestDataQueueActions/AddItem", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestDataQueues or OR.TestDataQueues.Write.
        /// Required permissions: TestDataQueueItems.Create.
        /// Responses:
        /// 200 Returns the number of items added
        /// 403 If the caller doesn't have permissions to create test data queue items
        /// 409 If the test data queue items violates the content JSON schema set on the queue
        /// </summary>
        public async Task<EmptyResponse> BulkAddsAnArrayOfDataQueueItems(BulkAddsAnArrayOfDataQueueItemsRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PostNewtonsoftJsonAsync<EmptyResponse>($"api/TestDataQueueActions/BulkAddItems", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestDataQueues or OR.TestDataQueues.Write.
        /// Required permissions: TestDataQueueItems.Delete.
        /// Responses:
        /// 202 All items from the test data queue were scheduled for deletion
        /// 403 If the caller doesn't have permissions to delete test data queue items
        /// </summary>
        public async Task<Stream> DeleteAllItemsFromATestDataQueue(DeleteAllItemsFromATestDataQueueParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/TestDataQueueActions/DeleteAllItems", parametersDict);
            var response = await _httpClient.DeleteAsync(queryString, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestDataQueues or OR.TestDataQueues.Write.
        /// Required permissions: TestDataQueueItems.Delete.
        /// Responses:
        /// 204 Deleted the test data queue items
        /// 403 If the caller doesn't have permissions to delete test data queue items
        /// </summary>
        public async Task<Stream> DeleteSpecificTestDataQueueItems()
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.DeleteAsNewtonsoftJsonAsync($"api/TestDataQueueActions/DeleteItems", headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestDataQueues or OR.TestDataQueues.Write.
        /// Required permissions: TestDataQueueItems.View.
        /// Responses:
        /// 200 Returns the next unconsumed test data queue item
        /// 204 If there are no unconsumed test data queue items in the queue
        /// 403 If the caller doesn't have permissions to view test data queue items
        /// 404 If the test data queue does not exist
        /// </summary>
        public async Task<OneOf<GetTheNextUnconsumedTestDataQueueItemOKResponse, Stream>> GetTheNextUnconsumedTestDataQueueItem(GetTheNextUnconsumedTestDataQueueItemRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"api/TestDataQueueActions/GetNextItem", request, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<GetTheNextUnconsumedTestDataQueueItemOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"GetTheNextUnconsumedTestDataQueueItem: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestDataQueues or OR.TestDataQueues.Write.
        /// Required permissions: TestDataQueueItems.Edit.
        /// Responses:
        /// 202 All items from the test data queue were scheduled for setting the IsConsumed flag
        /// 403 If the caller doesn't have permissions to edit test data queue items
        /// </summary>
        public async Task<Stream> SetTheIsConsumedFlagForAllItemsFromATestDataQueue(SetTheIsConsumedFlagForAllItemsFromATestDataQueueRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"api/TestDataQueueActions/SetAllItemsConsumed", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestDataQueues or OR.TestDataQueues.Write.
        /// Required permissions: TestDataQueueItems.Edit.
        /// Responses:
        /// 200 If the operation succeeded
        /// 403 If the caller doesn't have permissions to edit test data queue items
        /// </summary>
        public async Task<Stream> SetTheIsConsumedFlagForSpecificTestDataQueueItems(SetTheIsConsumedFlagForSpecificTestDataQueueItemsRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"api/TestDataQueueActions/SetItemsConsumed", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        public async Task<ReturnsAJsonWithTranslationResourcesResponse> ReturnsAJsonWithTranslationResources(ReturnsAJsonWithTranslationResourcesParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"api/Translations/GetTranslations", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ReturnsAJsonWithTranslationResourcesResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Required permissions: Tasks.Edit.
        /// </summary>
        public async Task<OneOf<List<BulkCompleteTheTaskByMergingFormDataAndActionTakenOKResponse>, Stream>> BulkCompleteTheTaskByMergingFormDataAndActionTaken(BulkCompleteTheTaskByMergingFormDataAndActionTakenRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"forms/TaskForms/BulkCompleteTasks", request, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<BulkCompleteTheTaskByMergingFormDataAndActionTakenOKResponse>();
            }
            if (response.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"BulkCompleteTheTaskByMergingFormDataAndActionTaken: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Required permissions: Tasks.Edit.
        /// </summary>
        public async Task<OneOf<List<BulkUpdateTaskDataByMergingDataOKResponse>, Stream>> BulkUpdateTaskDataByMergingData(BulkUpdateTaskDataByMergingDataRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"forms/TaskForms/BulkUpdateTasks", request, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<BulkUpdateTaskDataByMergingDataOKResponse>();
            }
            if (response.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"BulkUpdateTaskDataByMergingData: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Required permissions: Tasks.Edit.
        /// </summary>
        public async Task<Stream> CompleteTheTaskBySavingFormDataAndActionTaken(CompleteTheTaskBySavingFormDataAndActionTakenRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"forms/TaskForms/CompleteTask", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Required permissions: Tasks.Create.
        /// </summary>
        public async Task<CreatesANewFormTaskResponse> CreatesANewFormTask(CreatesANewFormTaskRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PostNewtonsoftJsonAsync<CreatesANewFormTaskResponse>($"forms/TaskForms/CreateFormTask", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Required permissions: Tasks.View.
        /// </summary>
        public async Task<OneOf<ReturnsTaskDataDtoOKResponse, Stream>> ReturnsTaskDataDto(ReturnsTaskDataDtoParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"forms/TaskForms/GetTaskDataById", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<ReturnsTaskDataDtoOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"ReturnsTaskDataDto: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Required permissions: Tasks.View.
        /// </summary>
        public async Task<OneOf<ReturnsFormDtoToRenderTaskFormOKResponse, Stream>> ReturnsFormDtoToRenderTaskForm(ReturnsFormDtoToRenderTaskFormParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"forms/TaskForms/GetTaskFormById", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<ReturnsFormDtoToRenderTaskFormOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"ReturnsFormDtoToRenderTaskForm: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Required permissions: Tasks.Edit.
        /// </summary>
        public async Task<Stream> ChangesDoneByTheCurrentUserAndReassignTaskToAnotherUser(ChangesDoneByTheCurrentUserAndReassignTaskToAnotherUserRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"forms/TaskForms/SaveAndReassignTask", request, headers);
            if (response.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.BadRequest or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"ChangesDoneByTheCurrentUserAndReassignTaskToAnotherUser: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Required permissions: Tasks.Edit.
        /// </summary>
        public async Task<Stream> SaveTaskData(SaveTaskDataRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"forms/TaskForms/SaveTaskData", request, headers);
            if (response.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.BadRequest or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"SaveTaskData: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Monitoring or OR.Monitoring.Read.
        /// Required permissions: Alerts.View.
        /// DEPRECATED: 
        /// Please refer to https://docs.uipath.com/orchestrator/reference
        /// </summary>
        public async Task<GetsAlertsResponse> GetsAlerts(GetsAlertsParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Alerts", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsAlertsResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Monitoring or OR.Monitoring.Read.
        /// Required permissions: Alerts.View.
        /// DEPRECATED: 
        /// Please refer to https://docs.uipath.com/orchestrator/reference
        /// </summary>
        public async Task<MberOfAlertsPerTenantThatHaventBeenReadByTheCurrentUserResponse> MberOfAlertsPerTenantThatHaventBeenReadByTheCurrentUser(MberOfAlertsPerTenantThatHaventBeenReadByTheCurrentUserParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Alerts/UiPath.Server.Configuration.OData.GetUnreadCount", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<MberOfAlertsPerTenantThatHaventBeenReadByTheCurrentUserResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Monitoring or OR.Monitoring.Write.
        /// Required permissions: Alerts.View.
        /// DEPRECATED: 
        /// Please refer to https://docs.uipath.com/orchestrator/reference
        /// </summary>
        public async Task<AsReadAndReturnsTheRemainingNumberOfUnreadNotificationsResponse> AsReadAndReturnsTheRemainingNumberOfUnreadNotifications(AsReadAndReturnsTheRemainingNumberOfUnreadNotificationsParameters queryParameters, AsReadAndReturnsTheRemainingNumberOfUnreadNotificationsRequest request)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Alerts/UiPath.Server.Configuration.OData.MarkAsRead", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<AsReadAndReturnsTheRemainingNumberOfUnreadNotificationsResponse>(queryString, request);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Monitoring or OR.Monitoring.Write.
        /// Required permissions: Alerts.Create.
        /// DEPRECATED: 
        /// Please refer to https://docs.uipath.com/orchestrator/reference
        /// </summary>
        public async Task<Stream> CreatesAProcessAlert(CreatesAProcessAlertRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Alerts/UiPath.Server.Configuration.OData.RaiseProcessAlert", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Assets or OR.Assets.Read.
        /// Required permissions: Assets.View.
        /// DEPRECATED: 
        /// Replaced by GetFiltered.
        /// Please refer to https://docs.uipath.com/orchestrator/reference
        /// </summary>
        public async Task<GetAssetsResponse> GetAssets(GetAssetsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Assets", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetAssetsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Assets or OR.Assets.Write.
        /// Required permissions: Assets.Create.
        /// </summary>
        public async Task<CreatesAnAssetResponse> CreatesAnAsset(CreatesAnAssetRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PostNewtonsoftJsonAsync<CreatesAnAssetResponse>($"odata/Assets", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Assets or OR.Assets.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<RentUserHasTheAssetsViewPermissionExceptTheOneSpecifiedResponse> RentUserHasTheAssetsViewPermissionExceptTheOneSpecified(RentUserHasTheAssetsViewPermissionExceptTheOneSpecifiedParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Assets/UiPath.Server.Configuration.OData.GetAssetsAcrossFolders", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<RentUserHasTheAssetsViewPermissionExceptTheOneSpecifiedResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Assets or OR.Assets.Read.
        /// Required permissions: Assets.View.
        /// </summary>
        public async Task<GetFilteredAssetsResponse> GetFilteredAssets(GetFilteredAssetsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Assets/UiPath.Server.Configuration.OData.GetFiltered", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetFilteredAssetsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Assets or OR.Assets.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<UntOfFoldersWhereItIsSharedIncludingUnaccessibleFoldersResponse> UntOfFoldersWhereItIsSharedIncludingUnaccessibleFolders(UntOfFoldersWhereItIsSharedIncludingUnaccessibleFoldersParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Assets/UiPath.Server.Configuration.OData.GetFoldersForAsset(id={_id})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<UntOfFoldersWhereItIsSharedIncludingUnaccessibleFoldersResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Assets or OR.Assets.Read.
        /// Required permissions: Assets.View.
        /// DEPRECATED: 
        /// Use the GetRobotAssetByNameForRobotKey endpoint. Kept for backwards compatibility.
        /// Please refer to https://docs.uipath.com/orchestrator/reference
        /// </summary>
        public async Task<OneOf<ReturnsTheNamedAssetAssociatedToTheGivenRobotKeyOKResponse, Stream>> ReturnsTheNamedAssetAssociatedToTheGivenRobotKey(ReturnsTheNamedAssetAssociatedToTheGivenRobotKeyParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Assets/UiPath.Server.Configuration.OData.GetRobotAsset(robotId='{_robotId}',assetName='{_assetName}')", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<ReturnsTheNamedAssetAssociatedToTheGivenRobotKeyOKResponse>();
            }
            if (response.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"ReturnsTheNamedAssetAssociatedToTheGivenRobotKey: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Assets or OR.Assets.Write.
        /// Required permissions: Assets.View.
        /// </summary>
        public async Task<OneOf<ReturnsTheNamedAssetAssociatedToTheGivenRobotKey2OKResponse, Stream>> ReturnsTheNamedAssetAssociatedToTheGivenRobotKey2(ReturnsTheNamedAssetAssociatedToTheGivenRobotKey2Parameters queryParameters, ReturnsTheNamedAssetAssociatedToTheGivenRobotKey2Request request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Assets/UiPath.Server.Configuration.OData.GetRobotAssetByNameForRobotKey", parametersDict);
            var response = await _httpClient.PostAsNewtonsoftJsonAsync(queryString, request, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<ReturnsTheNamedAssetAssociatedToTheGivenRobotKey2OKResponse>();
            }
            if (response.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"ReturnsTheNamedAssetAssociatedToTheGivenRobotKey2: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Assets or OR.Assets.Read.
        /// Required permissions: Assets.View.
        /// </summary>
        public async Task<OneOf<ReturnsTheNamedAssetAssociatedToTheGivenRobotIdOKResponse, Stream>> ReturnsTheNamedAssetAssociatedToTheGivenRobotId(ReturnsTheNamedAssetAssociatedToTheGivenRobotIdParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Assets/UiPath.Server.Configuration.OData.GetRobotAssetByRobotId(robotId={_robotId},assetName='{_assetName}')", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<ReturnsTheNamedAssetAssociatedToTheGivenRobotIdOKResponse>();
            }
            if (response.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"ReturnsTheNamedAssetAssociatedToTheGivenRobotId: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Assets or OR.Assets.Write.
        /// Required permissions: Assets.Edit.
        /// </summary>
        public async Task<Stream> SetTheAssetValueAssociatedToTheGivenRobotKey(SetTheAssetValueAssociatedToTheGivenRobotKeyRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Assets/UiPath.Server.Configuration.OData.SetRobotAssetByRobotKey", request, headers);
            if (response.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.BadRequest or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"SetTheAssetValueAssociatedToTheGivenRobotKey: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Assets or OR.Assets.Write.
        /// Requires authentication.
        /// </summary>
        public async Task<Stream> OvesTheAssetsFromTheFoldersSpecifiedInToRemoveFolderIds(OvesTheAssetsFromTheFoldersSpecifiedInToRemoveFolderIdsRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Assets/UiPath.Server.Configuration.OData.ShareToFolders", request, headers);
            if (response.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.NotFound or HttpStatusCode.Conflict)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"OvesTheAssetsFromTheFoldersSpecifiedInToRemoveFolderIds: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Assets or OR.Assets.Read.
        /// Required permissions: Assets.View.
        /// </summary>
        public async Task<GetsASingleAssetBasedOnItsIdResponse> GetsASingleAssetBasedOnItsId(GetsASingleAssetBasedOnItsIdParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Assets({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsASingleAssetBasedOnItsIdResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Assets or OR.Assets.Write.
        /// Required permissions: Assets.Edit.
        /// </summary>
        public async Task<Stream> EditAnAsset(EditAnAssetRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"odata/Assets({_key})", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Assets or OR.Assets.Write.
        /// Required permissions: Assets.Delete.
        /// </summary>
        public async Task<Stream> DeleteAnAsset()
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.DeleteAsync($"odata/Assets({_key})", headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Audit or OR.Audit.Read.
        /// Required permissions: Audit.View.
        /// </summary>
        public async Task<GetsAuditLogsResponse> GetsAuditLogs(GetsAuditLogsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"x-UIPATH-AuditedService", $"Orchestrator" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/AuditLogs", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsAuditLogsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Audit or OR.Audit.Write.
        /// Required permissions: Audit.View.
        /// </summary>
        public async Task<RequestsACSVExportOfFilteredItemsResponse> RequestsACSVExportOfFilteredItems(RequestsACSVExportOfFilteredItemsParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/AuditLogs/UiPath.Server.Configuration.OData.Export", parametersDict);
            return await _httpClient.PostFromNewtonsoftJsonAsync<RequestsACSVExportOfFilteredItemsResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Audit or OR.Audit.Read.
        /// Required permissions: Audit.View.
        /// </summary>
        public async Task<ReturnsAuditLogDetailsByAuditLogIdResponse> ReturnsAuditLogDetailsByAuditLogId(ReturnsAuditLogDetailsByAuditLogIdParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"x-UIPATH-AuditedService", $"Orchestrator" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/AuditLogs/UiPath.Server.Configuration.OData.GetAuditLogDetails(auditLogId={_auditLogId})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ReturnsAuditLogDetailsByAuditLogIdResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Administration or OR.Administration.Write.
        /// Required permissions: Buckets.Create.
        /// </summary>
        public async Task<CreatesAnBucketResponse> CreatesAnBucket(CreatesAnBucketRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PostNewtonsoftJsonAsync<CreatesAnBucketResponse>($"odata/Buckets", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Administration or OR.Administration.Read.
        /// Required permissions: Buckets.View.
        /// </summary>
        public async Task<GetsBucketsResponse> GetsBuckets(GetsBucketsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Buckets", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsBucketsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Administration or OR.Administration.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<EntUserHasTheBucketsViewPermissionExceptTheOneSpecifiedResponse> EntUserHasTheBucketsViewPermissionExceptTheOneSpecified(EntUserHasTheBucketsViewPermissionExceptTheOneSpecifiedParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Buckets/UiPath.Server.Configuration.OData.GetBucketsAcrossFolders", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<EntUserHasTheBucketsViewPermissionExceptTheOneSpecifiedResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Administration or OR.Administration.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<UntOfFoldersWhereItIsSharedIncludingUnaccessibleFolders2Response> UntOfFoldersWhereItIsSharedIncludingUnaccessibleFolders2(UntOfFoldersWhereItIsSharedIncludingUnaccessibleFolders2Parameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Buckets/UiPath.Server.Configuration.OData.GetFoldersForBucket(id={_id})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<UntOfFoldersWhereItIsSharedIncludingUnaccessibleFolders2Response>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Administration or OR.Administration.Write.
        /// Requires authentication.
        /// </summary>
        public async Task<Stream> VesTheBucketsFromTheFoldersSpecifiedInToRemoveFolderIds(VesTheBucketsFromTheFoldersSpecifiedInToRemoveFolderIdsRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Buckets/UiPath.Server.Configuration.OData.ShareToFolders", request, headers);
            if (response.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"VesTheBucketsFromTheFoldersSpecifiedInToRemoveFolderIds: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Administration or OR.Administration.Read.
        /// Required permissions: Buckets.View.
        /// </summary>
        public async Task<GetsASingleBucketResponse> GetsASingleBucket(GetsASingleBucketParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Buckets({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsASingleBucketResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Administration or OR.Administration.Write.
        /// Required permissions: Buckets.Delete.
        /// </summary>
        public async Task<Stream> DeleteABucket()
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.DeleteAsync($"odata/Buckets({_key})", headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Administration or OR.Administration.Write.
        /// Required permissions: Buckets.Edit.
        /// </summary>
        public async Task<UpdatesABucketResponse> UpdatesABucket(UpdatesABucketRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PutNewtonsoftJsonAsync<UpdatesABucketResponse>($"odata/Buckets({_key})", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Administration or OR.Administration.Write.
        /// Required permissions: Buckets.View and BlobFiles.Delete.
        /// </summary>
        public async Task<Stream> DeletesAFile(DeletesAFileParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Buckets({_key})/UiPath.Server.Configuration.OData.DeleteFile", parametersDict);
            var response = await _httpClient.DeleteAsync(queryString, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Administration or OR.Administration.Read.
        /// Required permissions: Buckets.View and BlobFiles.View.
        /// </summary>
        public async Task<GetsTheChildDirectoriesInADirectoryResponse> GetsTheChildDirectoriesInADirectory(GetsTheChildDirectoriesInADirectoryParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Buckets({_key})/UiPath.Server.Configuration.OData.GetDirectories", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTheChildDirectoriesInADirectoryResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Administration or OR.Administration.Read.
        /// Required permissions: Buckets.View and BlobFiles.View.
        /// </summary>
        public async Task<GetsAFileMetadataResponse> GetsAFileMetadata(GetsAFileMetadataParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Buckets({_key})/UiPath.Server.Configuration.OData.GetFile", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsAFileMetadataResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Administration or OR.Administration.Read.
        /// Required permissions: Buckets.View and BlobFiles.View.
        /// </summary>
        public async Task<OptionallyReturnsAllFilesInAllChildDirectoriesRecursiveResponse> OptionallyReturnsAllFilesInAllChildDirectoriesRecursive(OptionallyReturnsAllFilesInAllChildDirectoriesRecursiveParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Buckets({_key})/UiPath.Server.Configuration.OData.GetFiles", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<OptionallyReturnsAllFilesInAllChildDirectoriesRecursiveResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Administration or OR.Administration.Read.
        /// Required permissions: Buckets.View and BlobFiles.View.
        /// </summary>
        public async Task<GetsADirectDownloadURLForBlobFileResponse> GetsADirectDownloadURLForBlobFile(GetsADirectDownloadURLForBlobFileParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Buckets({_key})/UiPath.Server.Configuration.OData.GetReadUri", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsADirectDownloadURLForBlobFileResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Administration or OR.Administration.Read.
        /// Required permissions: Buckets.View and BlobFiles.Create.
        /// </summary>
        public async Task<GetsADirectUploadURLForBlobFileResponse> GetsADirectUploadURLForBlobFile(GetsADirectUploadURLForBlobFileParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Buckets({_key})/UiPath.Server.Configuration.OData.GetWriteUri", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsADirectUploadURLForBlobFileResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.BusinessRules or OR.BusinessRules.Read.
        /// Required permissions: (BusinessRules.View).
        /// </summary>
        public async Task<GetFilteredBusinessRulesResponse> GetFilteredBusinessRules(GetFilteredBusinessRulesParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/BusinessRules", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetFilteredBusinessRulesResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.BusinessRules or OR.BusinessRules.Write.
        /// Required permissions: (BusinessRules.Create).
        /// </summary>
        public async Task<CreateBusinessRuleResponse> CreateBusinessRule(CreateBusinessRuleMultipartFormData formData)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" },
                { $"Content-Type", $"multipart/form-data" }
            };
    
            return await _httpClient.PostFromNewtonsoftJsonAsync<CreateBusinessRuleResponse>($"odata/BusinessRules", formData.ToMultipartFormData(), headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.BusinessRules or OR.BusinessRules.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<RHasTheBusinessRulesViewPermissionExceptTheOneSpecifiedResponse> RHasTheBusinessRulesViewPermissionExceptTheOneSpecified(RHasTheBusinessRulesViewPermissionExceptTheOneSpecifiedParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/BusinessRules/UiPath.Server.Configuration.OData.GetBusinessRulesAcrossFolders", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<RHasTheBusinessRulesViewPermissionExceptTheOneSpecifiedResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.BusinessRules or OR.BusinessRules.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<UntOfFoldersWhereItIsSharedIncludingUnaccessibleFolders3Response> UntOfFoldersWhereItIsSharedIncludingUnaccessibleFolders3(UntOfFoldersWhereItIsSharedIncludingUnaccessibleFolders3Parameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/BusinessRules/UiPath.Server.Configuration.OData.GetFoldersForBusinessRule(id={_id})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<UntOfFoldersWhereItIsSharedIncludingUnaccessibleFolders3Response>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.BusinessRules or OR.BusinessRules.Read.
        /// Required permissions: (BusinessRules.View).
        /// </summary>
        public async Task<OneOf<GetReadURIByNameOKResponse, Stream>> GetReadURIByName(GetReadURIByNameParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/BusinessRules/UiPath.Server.Configuration.OData.GetReadUri(name='{_name}')", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<GetReadURIByNameOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"GetReadURIByName: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.BusinessRules or OR.BusinessRules.Read.
        /// Required permissions: (BusinessRules.View).
        /// </summary>
        public async Task<OneOf<GetVersionsOfBusinessRuleOKResponse, Stream>> GetVersionsOfBusinessRule(GetVersionsOfBusinessRuleParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/BusinessRules/UiPath.Server.Configuration.OData.GetVersionList(id={_id})", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<GetVersionsOfBusinessRuleOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"GetVersionsOfBusinessRule: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.BusinessRules or OR.BusinessRules.Write.
        /// Requires authentication.
        /// </summary>
        public async Task<Stream> MakesTheBusinessRuleVisibleInTheSpecifiedFolders(MakesTheBusinessRuleVisibleInTheSpecifiedFoldersRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/BusinessRules/UiPath.Server.Configuration.OData.ShareToFolders", request, headers);
            if (response.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"MakesTheBusinessRuleVisibleInTheSpecifiedFolders: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.BusinessRules or OR.BusinessRules.Read.
        /// Required permissions: (BusinessRules.View).
        /// </summary>
        public async Task<OneOf<GetBusinessRuleByKeyOKResponse, Stream>> GetBusinessRuleByKey(GetBusinessRuleByKeyParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/BusinessRules({_key})", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<GetBusinessRuleByKeyOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"GetBusinessRuleByKey: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.BusinessRules or OR.BusinessRules.Write.
        /// Required permissions: (BusinessRules.Edit).
        /// </summary>
        public async Task<Stream> UpdateBusinessRule(UpdateBusinessRuleMultipartFormData formData)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" },
                { $"Content-Type", $"multipart/form-data" }
            };
    
            var response = await _httpClient.PutAsync($"odata/BusinessRules({_key})", formData.ToMultipartFormData(), headers);
            if (response.StatusCode is HttpStatusCode.OK or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"UpdateBusinessRule: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.BusinessRules or OR.BusinessRules.Write.
        /// Required permissions: (BusinessRules.Delete).
        /// </summary>
        public async Task<Stream> DeleteBusinessRule()
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.DeleteAsync($"odata/BusinessRules({_key})", headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<GetsCalendarsForCurrentTenantResponse> GetsCalendarsForCurrentTenant(GetsCalendarsForCurrentTenantParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Calendars", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsCalendarsForCurrentTenantResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Write.
        /// Required permissions: (Settings.Create).
        /// </summary>
        public async Task<CreatesANewCalendarResponse> CreatesANewCalendar(CreatesANewCalendarRequest request)
        {
            return await _httpClient.PostNewtonsoftJsonAsync<CreatesANewCalendarResponse>($"odata/Calendars", request);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Write.
        /// Required permissions: (Settings.Edit).
        /// </summary>
        public async Task<ValidateCalendarNameAndCheckIfItAlreadyExistsResponse> ValidateCalendarNameAndCheckIfItAlreadyExists(ValidateCalendarNameAndCheckIfItAlreadyExistsParameters queryParameters, ValidateCalendarNameAndCheckIfItAlreadyExistsRequest request)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Calendars/UiPath.Server.Configuration.OData.CalendarExists", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<ValidateCalendarNameAndCheckIfItAlreadyExistsResponse>(queryString, request);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<GetsCalendarBasedOnItsIdResponse> GetsCalendarBasedOnItsId(GetsCalendarBasedOnItsIdParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Calendars({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsCalendarBasedOnItsIdResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Write.
        /// Required permissions: (Settings.Edit).
        /// </summary>
        public async Task<EditsACalendarResponse> EditsACalendar(EditsACalendarRequest request)
        {
            return await _httpClient.PutNewtonsoftJsonAsync<EditsACalendarResponse>($"odata/Calendars({_key})", request);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Write.
        /// Required permissions: (Settings.Delete).
        /// </summary>
        public async Task<Stream> DeletesACalendar()
        {
            var response = await _httpClient.DeleteAsync($"odata/Calendars({_key})");
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Read.
        /// Required permissions: Settings.View or Assets.Create or Assets.Edit or Assets.View or Robots.Create 
        /// or Robots.Edit or Robots.View or Buckets.Create or Buckets.Edit.
        /// </summary>
        public async Task<GetsAllCredentialStoresResponse> GetsAllCredentialStores(GetsAllCredentialStoresParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/CredentialStores", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsAllCredentialStoresResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Write.
        /// Required permissions: Settings.Create.
        /// </summary>
        public async Task<CreatesANewCredentialStoreResponse> CreatesANewCredentialStore(CreatesANewCredentialStoreRequest request)
        {
            return await _httpClient.PostNewtonsoftJsonAsync<CreatesANewCredentialStoreResponse>($"odata/CredentialStores", request);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Read.
        /// Required permissions: Settings.View.
        /// </summary>
        public async Task<GetsAvailableCredentialStoreTypesResponse> GetsAvailableCredentialStoreTypes(GetsAvailableCredentialStoreTypesParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/CredentialStores/UiPath.Server.Configuration.OData.GetAvailableCredentialStoreTypes", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsAvailableCredentialStoreTypesResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Read.
        /// Required permissions: Settings.View or Assets.Create or Assets.Edit or Assets.View or Robots.Create 
        /// or Robots.Edit or Robots.View or Buckets.Create or Buckets.Edit.
        /// </summary>
        public async Task<GetTheDefaultCredentialStoreForTheGivenResourceTypeResponse> GetTheDefaultCredentialStoreForTheGivenResourceType(GetTheDefaultCredentialStoreForTheGivenResourceTypeParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/CredentialStores/UiPath.Server.Configuration.OData.GetDefaultStoreForResourceType(resourceType='{_resourceType}')", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetTheDefaultCredentialStoreForTheGivenResourceTypeResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Read.
        /// Required permissions: Settings.View.
        /// </summary>
        public async Task<AilableResourcesRobotsAndLaterAssetsForACredentialStoreResponse> AilableResourcesRobotsAndLaterAssetsForACredentialStore(AilableResourcesRobotsAndLaterAssetsForACredentialStoreParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/CredentialStores/UiPath.Server.Configuration.OData.GetResourcesForCredentialsProxyResourceTypes(key={_key},resourceType='{_resourceType}')", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<AilableResourcesRobotsAndLaterAssetsForACredentialStoreResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Read.
        /// Required permissions: Settings.View.
        /// </summary>
        public async Task<AilableResourcesRobotsAndLaterAssetsForACredentialStore2Response> AilableResourcesRobotsAndLaterAssetsForACredentialStore2(AilableResourcesRobotsAndLaterAssetsForACredentialStore2Parameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/CredentialStores/UiPath.Server.Configuration.OData.GetResourcesForCredentialStoreTypes(key={_key},resourceType='{_resourceType}')", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<AilableResourcesRobotsAndLaterAssetsForACredentialStore2Response>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Read.
        /// Required permissions: Settings.View.
        /// </summary>
        public async Task<GetsASingleCredentialStoreByItsKeyResponse> GetsASingleCredentialStoreByItsKey(GetsASingleCredentialStoreByItsKeyParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/CredentialStores({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsASingleCredentialStoreByItsKeyResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Write.
        /// Required permissions: Settings.Edit.
        /// </summary>
        public async Task<Stream> UpdatesACredentialStore(UpdatesACredentialStoreRequest request)
        {
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"odata/CredentialStores({_key})", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Write.
        /// Required permissions: Settings.Delete.
        /// </summary>
        public async Task<Stream> DeletesACredentialStore(DeletesACredentialStoreParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/CredentialStores({_key})", parametersDict);
            var response = await _httpClient.DeleteAsync(queryString);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Write.
        /// Required permissions: Settings.Edit.
        /// </summary>
        public async Task<Stream> TsACredentialStoreAsTheDefaultForTheGivenCredentialType(TsACredentialStoreAsTheDefaultForTheGivenCredentialTypeRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/CredentialStores({_key})/UiPath.Server.Configuration.OData.SetDefaultStoreForResourceType", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Read.
        /// Required permissions: Environments.View.
        /// </summary>
        public async Task<GetsEnvironmentsResponse> GetsEnvironments(GetsEnvironmentsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Environments", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsEnvironmentsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Write.
        /// Required permissions: Environments.Create.
        /// </summary>
        public async Task<PostNewEnvironmentResponse> PostNewEnvironment(PostNewEnvironmentRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PostNewtonsoftJsonAsync<PostNewEnvironmentResponse>($"odata/Environments", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Read.
        /// Required permissions: Environments.View and Robots.View.
        /// </summary>
        public async Task<FTheRobotsAssociatedToAnEnvironmentBasedOnEnvironmentIdResponse> FTheRobotsAssociatedToAnEnvironmentBasedOnEnvironmentId(FTheRobotsAssociatedToAnEnvironmentBasedOnEnvironmentIdParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Environments/UiPath.Server.Configuration.OData.GetRobotIdsForEnvironment(key={_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<FTheRobotsAssociatedToAnEnvironmentBasedOnEnvironmentIdResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Read.
        /// Required permissions: Environments.View and Robots.View.
        /// </summary>
        public async Task<StThoseBelongingToTheEnvironmentAllowsOdataQueryOptionsResponse> StThoseBelongingToTheEnvironmentAllowsOdataQueryOptions(StThoseBelongingToTheEnvironmentAllowsOdataQueryOptionsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Environments/UiPath.Server.Configuration.OData.GetRobotsForEnvironment(key={_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<StThoseBelongingToTheEnvironmentAllowsOdataQueryOptionsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Read.
        /// Required permissions: Environments.View.
        /// </summary>
        public async Task<GetsASingleEnvironmentResponse> GetsASingleEnvironment(GetsASingleEnvironmentParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Environments({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsASingleEnvironmentResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Write.
        /// Required permissions: Environments.Edit.
        /// </summary>
        public async Task<Stream> UpdatesAnEnvironment(UpdatesAnEnvironmentRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"odata/Environments({_key})", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Write.
        /// Required permissions: Environments.Delete.
        /// </summary>
        public async Task<Stream> DeletesAnEnvironment()
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.DeleteAsync($"odata/Environments({_key})", headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Write.
        /// Required permissions: Environments.Edit.
        /// </summary>
        public async Task<Stream> AssociatesARobotWithTheGivenEnvironment(AssociatesARobotWithTheGivenEnvironmentRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Environments({_key})/UiPath.Server.Configuration.OData.AddRobot", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Write.
        /// Required permissions: Environments.Edit.
        /// </summary>
        public async Task<Stream> DissociatesARobotFromTheGivenEnvironment(DissociatesARobotFromTheGivenEnvironmentRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Environments({_key})/UiPath.Server.Configuration.OData.RemoveRobot", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Write.
        /// Required permissions: Environments.Edit.
        /// </summary>
        public async Task<Stream> DDissociatesAnotherGroupOfRobotsFromTheGivenEnvironment(DDissociatesAnotherGroupOfRobotsFromTheGivenEnvironmentRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Environments({_key})/UiPath.Server.Configuration.OData.SetRobots", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Monitoring or OR.Monitoring.Read.
        /// Required permissions: ExecutionMedia.View.
        /// </summary>
        public async Task<ExecutionMediaGetResponse> ExecutionMediaGet(ExecutionMediaGetParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/ExecutionMedia", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ExecutionMediaGetResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Monitoring or OR.Monitoring.Write.
        /// Required permissions: ExecutionMedia.Delete.
        /// </summary>
        public async Task<Stream> DeletesTheExecutionMediaForTheGivenJobKey(DeletesTheExecutionMediaForTheGivenJobKeyRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/ExecutionMedia/UiPath.Server.Configuration.OData.DeleteMediaByJobId", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Monitoring or OR.Monitoring.Read.
        /// Required permissions: ExecutionMedia.View.
        /// </summary>
        public async Task<Stream> DownloadsExecutionMediaByJobId()
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" },
                { $"Accept", $"application/octet-stream" }
            };
    
            var response = await _httpClient.GetAsync($"odata/ExecutionMedia/UiPath.Server.Configuration.OData.DownloadMediaByJobId(jobId={_jobId})", headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Monitoring or OR.Monitoring.Read.
        /// Required permissions: ExecutionMedia.View.
        /// </summary>
        public async Task<GetByIdResponse> GetById(GetByIdParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/ExecutionMedia({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetByIdResponse>(queryString, headers);
        }
    
        /// <summary>
        /// Requires authentication.
        /// </summary>
        public async Task<ExportsGetByIdResponse> ExportsGetById(ExportsGetByIdParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Exports({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ExportsGetByIdResponse>(queryString);
        }
    
        /// <summary>
        /// Requires authentication.
        /// </summary>
        public async Task<ExportsGetDownloadLinkByIdResponse> ExportsGetDownloadLinkById(ExportsGetDownloadLinkByIdParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Exports({_key})/UiPath.Server.Configuration.OData.GetDownloadLink", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ExportsGetDownloadLinkByIdResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Read.
        /// Required permissions: (Units.View or SubFolders.View - Gets all folders or only the folders where user 
        /// has SubFolders.View permission).
        /// </summary>
        public async Task<GetsFoldersResponse> GetsFolders(GetsFoldersParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Folders", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsFoldersResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Write.
        /// Required permissions: (Units.Create or SubFolders.Create - Creates root or subfolder or only subfolder 
        /// if user has SubFolders.Create permission on parent).
        /// </summary>
        public async Task<CreatesANewFolderResponse> CreatesANewFolder(CreatesANewFolderRequest request)
        {
            return await _httpClient.PostNewtonsoftJsonAsync<CreatesANewFolderResponse>($"odata/Folders", request);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Write.
        /// Required permissions: (Units.Edit or SubFolders.Edit - Assigns domain user to any folder or only if 
        /// user has SubFolders.Edit permission on all folders provided).
        /// </summary>
        public async Task<Stream> OrGroupToASetOfFoldersWithAnOptionalSetOfRolesPerFolder(OrGroupToASetOfFoldersWithAnOptionalSetOfRolesPerFolderRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Folders/UiPath.Server.Configuration.OData.AssignDomainUser", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Write.
        /// Required permissions: (Units.Edit or SubFolders.Edit - Assigns machines to any folder or only if user 
        /// has SubFolders.Edit permission on all folders provided).
        /// </summary>
        public async Task<Stream> AssignsOneOrMoreMachinesToASetOfFolders(AssignsOneOrMoreMachinesToASetOfFoldersRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Folders/UiPath.Server.Configuration.OData.AssignMachines", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Write.
        /// Required permissions: (Units.Edit or SubFolders.Edit - Assigns users to any folder or if the user has 
        /// SubFolders.Edit permission on all folders provided).
        /// </summary>
        public async Task<Stream> ReUsersToASetOfFoldersWithAnOptionalSetOfRolesPerFolder(ReUsersToASetOfFoldersWithAnOptionalSetOfRolesPerFolderRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Folders/UiPath.Server.Configuration.OData.AssignUsers", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Read.
        /// Required permissions: (Units.View or SubFolders.View - Gets roles from all folders or only from folders 
        /// where user has SubFolders.View permission).
        /// </summary>
        public async Task<HeDistinctionBetweenTheFoldersAssignedDirectlyToTheUser2Response> HeDistinctionBetweenTheFoldersAssignedDirectlyToTheUser2(HeDistinctionBetweenTheFoldersAssignedDirectlyToTheUser2Parameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Folders/UiPath.Server.Configuration.OData.GetAllRolesForUser(username='{_username}',skip={_skip},take={_take})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<HeDistinctionBetweenTheFoldersAssignedDirectlyToTheUser2Response>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Read.
        /// Required permissions: (Units.View or SubFolders.View - Gets any folder or only the folder if user has 
        /// SubFolders.View permission on it or the user is assigned to the folder.).
        /// </summary>
        public async Task<GetsASingleFolderBasedOnItsKeyResponse> GetsASingleFolderBasedOnItsKey(GetsASingleFolderBasedOnItsKeyParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Folders/UiPath.Server.Configuration.OData.GetByKey(identifier={_identifier})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsASingleFolderBasedOnItsKeyResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Read.
        /// Required permissions: (Units.View or SubFolders.View - Gets machines for any folder or only if user 
        /// has SubFolders.View permission on folder).
        /// </summary>
        public async Task<ReturnsTheMachinesAssignedToAFolderResponse> ReturnsTheMachinesAssignedToAFolder(ReturnsTheMachinesAssignedToAFolderParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Folders/UiPath.Server.Configuration.OData.GetMachinesForFolder(key={_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ReturnsTheMachinesAssignedToAFolderResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Read.
        /// Required permissions: (SubFolders.Delete - Deletes folder only if user has SubFolders.Delete permission 
        /// on it) and (Units.Create or SubFolders.Create - Creates root or subfolder or only subfolder if user 
        /// has SubFolders.Create permission on parent) and (Units.Edit or SubFolders.Edit - Edits any folder or 
        /// only if user has SubFolders.Edit permission on it).
        /// </summary>
        public async Task<GetsTheMachineChangesWhenMovingAFolderResponse> GetsTheMachineChangesWhenMovingAFolder(GetsTheMachineChangesWhenMovingAFolderParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Folders/UiPath.Server.Configuration.OData.GetMoveFolderMachinesChanges", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTheMachineChangesWhenMovingAFolderResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Read.
        /// Required permissions: (Units.View or SubFolders.View - Gets the subfolders in which the machines is 
        /// directly assigned for any folder or for subfolders only).
        /// </summary>
        public async Task<CtMachineAssignmentsForAllSubfoldersOfTheSpecificFolderResponse> CtMachineAssignmentsForAllSubfoldersOfTheSpecificFolder(CtMachineAssignmentsForAllSubfoldersOfTheSpecificFolderParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Folders/UiPath.Server.Configuration.OData.GetSubfoldersWithAssignedMachine", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<CtMachineAssignmentsForAllSubfoldersOfTheSpecificFolderResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Read.
        /// Required permissions: (Units.View or SubFolders.View or Assets.Create or Assets.Edit - Gets users for 
        /// any folder or if the user has SubFolders.View/Assets.Create/Assets.Edit permission on the provided folder).
        /// </summary>
        public async Task<RAndOptionallyTheFineGrainedRolesEachOnehasOnThatFolderResponse> RAndOptionallyTheFineGrainedRolesEachOnehasOnThatFolder(RAndOptionallyTheFineGrainedRolesEachOnehasOnThatFolderParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Folders/UiPath.Server.Configuration.OData.GetUsersForFolder(key={_key},includeInherited={_includeInherited})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<RAndOptionallyTheFineGrainedRolesEachOnehasOnThatFolderResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Write.
        /// Required permissions: (Units.Edit or SubFolders.Edit - Propagate machine to subfolders only if Units.Edit 
        /// permission is provided or only if SubFolders.Edit permission on all folders provided).
        /// </summary>
        public async Task<Stream> ToggleMachinePropagationForAFolderToAllSubfolders(ToggleMachinePropagationForAFolderToAllSubfoldersRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Folders/UiPath.Server.Configuration.OData.ToggleFolderMachineInherit", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Write.
        /// Required permissions: (Units.Edit or SubFolders.Edit - Update machines to any folder associations or 
        /// only if user has SubFolders.Edit permission on all folders provided).
        /// </summary>
        public async Task<Stream> AddAndRemoveMachineAssociationsToAFolder(AddAndRemoveMachineAssociationsToAFolderRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Folders/UiPath.Server.Configuration.OData.UpdateMachinesToFolderAssociations", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Write.
        /// Required permissions: (Units.Delete or SubFolders.Delete - Move any folder or to folder only if user 
        /// has SubFolders.Delete permission on it) and (Units.Create or SubFolders.Create - Move to any target 
        /// folder or to folder if user has SubFolders.Create permission on target) and (Units.Edit or SubFolders.Edit 
        /// - Move to any target folder or to folder if user has SubFolders.Edit permission on target).
        /// </summary>
        public async Task<Stream> MoveAFolder(MoveAFolderParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Folders({_folderId})/UiPath.Server.Configuration.OData.MoveFolder", parametersDict);
            var response = await _httpClient.PutAsync(queryString);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Read.
        /// Required permissions: (Units.View or SubFolders.View - Gets any folder or only the folder if user has 
        /// SubFolders.View permission on it or the user is assigned to the folder.).
        /// </summary>
        public async Task<GetsASingleFolderBasedOnItsIdResponse> GetsASingleFolderBasedOnItsId(GetsASingleFolderBasedOnItsIdParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Folders({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsASingleFolderBasedOnItsIdResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Write.
        /// Required permissions: (Units.Edit or SubFolders.Edit - Edits any folder or edits only if user has SubFolders.Edit 
        /// permission on the provided folder).
        /// </summary>
        public async Task<EditsAFolder2Response> EditsAFolder2(EditsAFolder2Request request)
        {
            return await _httpClient.PutNewtonsoftJsonAsync<EditsAFolder2Response>($"odata/Folders({_key})", request);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Write.
        /// Required permissions: (Units.Delete or SubFolders.Delete - Deletes any folder or only if user has SubFolders.Delete 
        /// permission on the provided folder).
        /// </summary>
        public async Task<Stream> RUserAssociationsexistInThisFolderOrAnyOfItsDescendants2()
        {
            var response = await _httpClient.DeleteAsync($"odata/Folders({_key})");
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Write.
        /// Required permissions: (Units.Edit or SubFolders.Edit - Removes machines from any folder or only if caller 
        /// has SubFolders.Edit permission the folder provided).
        /// </summary>
        public async Task<Stream> RemoveUserAssignmentFromAFolder(RemoveUserAssignmentFromAFolderRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Folders({_key})/UiPath.Server.Configuration.OData.RemoveMachinesFromFolder", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Write.
        /// Required permissions: (Units.Edit or SubFolders.Edit - Remove user from any folder or only if caller 
        /// has SubFolders.Edit permission on provided folder).
        /// </summary>
        public async Task<Stream> RemoveUserAssignmentFromAFolder2(RemoveUserAssignmentFromAFolder2Request request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Folders({_key})/UiPath.Server.Configuration.OData.RemoveUserFromFolder", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Write.
        /// Required permissions: (Units.Edit or SubFolders.Edit - Remove user from any folder or only if caller 
        /// has SubFolders.Edit permission on provided folder).
        /// </summary>
        public async Task<Stream> RemoveUserAssignmentFromAFolder3(RemoveUserAssignmentFromAFolder3Request request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Folders({_key})/UiPath.Server.Configuration.OData.RemoveUserFromFolderByKey", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Read.
        /// Required permissions: Jobs.View.
        /// </summary>
        public async Task<GetsJobsResponse> GetsJobs(GetsJobsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Jobs", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsJobsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Write.
        /// Required permissions: Jobs.View.
        /// </summary>
        public async Task<RequestsACSVExportOfFilteredItems2Response> RequestsACSVExportOfFilteredItems2(RequestsACSVExportOfFilteredItems2Parameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Jobs/UiPath.Server.Configuration.OData.Export", parametersDict);
            return await _httpClient.PostFromNewtonsoftJsonAsync<RequestsACSVExportOfFilteredItems2Response>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Write.
        /// Required permissions: Jobs.Create.
        /// </summary>
        public async Task<RestartsTheSpecifiedJobResponse> RestartsTheSpecifiedJob(RestartsTheSpecifiedJobParameters queryParameters, RestartsTheSpecifiedJobRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Jobs/UiPath.Server.Configuration.OData.RestartJob", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<RestartsTheSpecifiedJobResponse>(queryString, request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Write.
        /// Required permissions: Jobs.Edit.
        /// </summary>
        public async Task<ResumesTheSpecifiedJobResponse> ResumesTheSpecifiedJob(ResumesTheSpecifiedJobParameters queryParameters, ResumesTheSpecifiedJobRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Jobs/UiPath.Server.Configuration.OData.ResumeJob", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<ResumesTheSpecifiedJobResponse>(queryString, request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Write.
        /// Required permissions: Jobs.Create.
        /// </summary>
        public async Task<AmetersAndNotifiesTheRespectiveRobotsAboutThePendingJobResponse> AmetersAndNotifiesTheRespectiveRobotsAboutThePendingJob(AmetersAndNotifiesTheRespectiveRobotsAboutThePendingJobParameters queryParameters, AmetersAndNotifiesTheRespectiveRobotsAboutThePendingJobRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Jobs/UiPath.Server.Configuration.OData.StartJobs", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<AmetersAndNotifiesTheRespectiveRobotsAboutThePendingJobResponse>(queryString, request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Write.
        /// Required permissions: Jobs.Edit.
        /// </summary>
        public async Task<Stream> CancelsOrTerminatesTheSpecifiedJobs(CancelsOrTerminatesTheSpecifiedJobsRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Jobs/UiPath.Server.Configuration.OData.StopJobs", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Write.
        /// Required permissions: Jobs.Create.
        /// </summary>
        public async Task<ValidatesTheInputWhichWouldStartAJobResponse> ValidatesTheInputWhichWouldStartAJob(ValidatesTheInputWhichWouldStartAJobParameters queryParameters, ValidatesTheInputWhichWouldStartAJobRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Jobs/UiPath.Server.Configuration.OData.ValidateDynamicJob", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<ValidatesTheInputWhichWouldStartAJobResponse>(queryString, request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Read.
        /// Required permissions: (Jobs.View).
        /// </summary>
        public async Task<GetsASingleJobResponse> GetsASingleJob(GetsASingleJobParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Jobs({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsASingleJobResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Write.
        /// Required permissions: Jobs.Edit.
        /// </summary>
        public async Task<Stream> CancelsOrTerminatesTheSpecifiedJob(CancelsOrTerminatesTheSpecifiedJobRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Jobs({_key})/UiPath.Server.Configuration.OData.StopJob", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Write.
        /// Required permissions: (Jobs.View).
        /// </summary>
        public async Task<ValidatesAnExistingJobResponse> ValidatesAnExistingJob(ValidatesAnExistingJobParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Jobs({_key})/UiPath.Server.Configuration.OData.ValidateExistingJob", parametersDict);
            return await _httpClient.PostFromNewtonsoftJsonAsync<ValidatesAnExistingJobResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Read.
        /// Required permissions: Jobs.View.
        /// </summary>
        public async Task<GetsJobTriggersResponse> GetsJobTriggers(GetsJobTriggersParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/JobTriggers", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsJobTriggersResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Read.
        /// Required permissions: Jobs.View.
        /// </summary>
        public async Task<TsTriggerOptionForAJobInstanceAlongWithWaitEventDetailsResponse> TsTriggerOptionForAJobInstanceAlongWithWaitEventDetails(TsTriggerOptionForAJobInstanceAlongWithWaitEventDetailsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/JobTriggers/UiPath.Server.Configuration.OData.GetWithWaitEvents(jobId={_jobId})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<TsTriggerOptionForAJobInstanceAlongWithWaitEventDetailsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Read.
        /// Required permissions: Libraries.View.
        /// </summary>
        public async Task<GetsTheLibraryPackagesResponse> GetsTheLibraryPackages(GetsTheLibraryPackagesParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Libraries", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTheLibraryPackagesResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Read.
        /// Required permissions: Libraries.View.
        /// </summary>
        public async Task<Stream> DownloadsTheNupkgFileOfAPackage(DownloadsTheNupkgFileOfAPackageParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"Accept", $"application/octet-stream" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Libraries/UiPath.Server.Configuration.OData.DownloadPackage(key='{_key}')", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Read.
        /// Required permissions: Libraries.View.
        /// </summary>
        public async Task<AvailableVersionsOfAGivenPackageAllowsOdataQueryOptionsResponse> AvailableVersionsOfAGivenPackageAllowsOdataQueryOptions(AvailableVersionsOfAGivenPackageAllowsOdataQueryOptionsParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Libraries/UiPath.Server.Configuration.OData.GetVersions(packageId='{_packageId}')", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<AvailableVersionsOfAGivenPackageAllowsOdataQueryOptionsResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Write.
        /// Required permissions: Libraries.Create.
        /// </summary>
        public async Task<TOfThePackageIsSentAsANupkgFileEmbeddedInTheHTTPRequestResponse> TOfThePackageIsSentAsANupkgFileEmbeddedInTheHTTPRequest(TOfThePackageIsSentAsANupkgFileEmbeddedInTheHTTPRequestParameters queryParameters, TOfThePackageIsSentAsANupkgFileEmbeddedInTheHTTPRequestMultipartFormData formData)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"Content-Type", $"multipart/form-data" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Libraries/UiPath.Server.Configuration.OData.UploadPackage", parametersDict);
            return await _httpClient.PostFromNewtonsoftJsonAsync<TOfThePackageIsSentAsANupkgFileEmbeddedInTheHTTPRequestResponse>(queryString, formData.ToMultipartFormData(), headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Write.
        /// Required permissions: Libraries.Delete.
        /// </summary>
        public async Task<Stream> DeletesAPackage(DeletesAPackageParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Libraries('{_key}')", parametersDict);
            var response = await _httpClient.DeleteAsync(queryString);
            if (response.StatusCode is HttpStatusCode.OK or HttpStatusCode.NoContent or HttpStatusCode.BadRequest)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"DeletesAPackage: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.License or OR.License.Read.
        /// Required permissions: License.View.
        /// </summary>
        public async Task<GetsNamedUserLicensesResponse> GetsNamedUserLicenses(GetsNamedUserLicensesParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/LicensesNamedUser/UiPath.Server.Configuration.OData.GetLicensesNamedUser(robotType='{_robotType}')", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsNamedUserLicensesResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.License or OR.License.Write.
        /// Required permissions: Machines.Edit.
        /// </summary>
        public async Task<Stream> TogglesMachineLicensingOnoff(TogglesMachineLicensingOnoffRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/LicensesRuntime('{_key}')/UiPath.Server.Configuration.OData.ToggleEnabled", request);
            if (response.StatusCode is HttpStatusCode.OK or HttpStatusCode.Conflict)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"TogglesMachineLicensingOnoff: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.License or OR.License.Read.
        /// Required permissions: License.View.
        /// </summary>
        public async Task<GetsRuntimeLicensesResponse> GetsRuntimeLicenses(GetsRuntimeLicensesParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/LicensesRuntime/UiPath.Server.Configuration.OData.GetLicensesRuntime(robotType='{_robotType}')", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsRuntimeLicensesResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Machines or OR.Machines.Read.
        /// Required permissions: Machines.View.
        /// </summary>
        public async Task<GetsMachinesResponse> GetsMachines(GetsMachinesParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Machines", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsMachinesResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Machines or OR.Machines.Write.
        /// Required permissions: Machines.Create.
        /// </summary>
        public async Task<CreatesANewMachineResponse> CreatesANewMachine(CreatesANewMachineRequest request)
        {
            return await _httpClient.PostNewtonsoftJsonAsync<CreatesANewMachineResponse>($"odata/Machines", request);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Machines or OR.Machines.Write.
        /// Required permissions: Machines.Delete.
        /// </summary>
        public async Task<Stream> DeletesMultipleMachinesBasedOnTheirKeys(DeletesMultipleMachinesBasedOnTheirKeysRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Machines/UiPath.Server.Configuration.OData.DeleteBulk", request);
            if (response.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.BadRequest)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"DeletesMultipleMachinesBasedOnTheirKeys: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Machines or OR.Machines.Read.
        /// Required permissions: (Machines.View or Jobs.Create).
        /// </summary>
        public async Task<GetsMachinesAssignedToFolderAndRobotResponse> GetsMachinesAssignedToFolderAndRobot(GetsMachinesAssignedToFolderAndRobotParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Machines/UiPath.Server.Configuration.OData.GetAssignedMachines(folderId={_folderId})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsMachinesAssignedToFolderAndRobotResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Machines or OR.Machines.Read.
        /// Required permissions: (Machines.View or Jobs.Create).
        /// </summary>
        public async Task<GetsRuntimesForTheSpecifiedFolderResponse> GetsRuntimesForTheSpecifiedFolder(GetsRuntimesForTheSpecifiedFolderParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Machines/UiPath.Server.Configuration.OData.GetRuntimesForFolder(folderId={_folderId})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsRuntimesForTheSpecifiedFolderResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Machines or OR.Machines.Read.
        /// Required permissions: Machines.View.
        /// </summary>
        public async Task<GetsASingleMachineBasedOnItsIdResponse> GetsASingleMachineBasedOnItsId(GetsASingleMachineBasedOnItsIdParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Machines({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsASingleMachineBasedOnItsIdResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Machines or OR.Machines.Write.
        /// Required permissions: Machines.Edit.
        /// </summary>
        public async Task<Stream> EditsAMachineBasedOnItsKey(EditsAMachineBasedOnItsKeyRequest request)
        {
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"odata/Machines({_key})", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Machines or OR.Machines.Write.
        /// Required permissions: Machines.Edit.
        /// </summary>
        public async Task<Stream> PartiallyUpdatesAMachine(PartiallyUpdatesAMachineRequest request)
        {
            var response = await _httpClient.PatchAsNewtonsoftJsonAsync($"odata/Machines({_key})", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Machines or OR.Machines.Write.
        /// Required permissions: Machines.Delete.
        /// </summary>
        public async Task<Stream> DeletesAMachineBasedOnItsKey()
        {
            var response = await _httpClient.DeleteAsync($"odata/Machines({_key})");
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Read.
        /// Required permissions: Units.View.
        /// DEPRECATED: 
        /// Kept for backwards compatibility. Use Get from FoldersController  instead
        /// Please refer to https://docs.uipath.com/orchestrator/reference
        /// </summary>
        public async Task<GetsTheOrganizationUnitsResponse> GetsTheOrganizationUnits(GetsTheOrganizationUnitsParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/OrganizationUnits", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTheOrganizationUnitsResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Write.
        /// Required permissions: Units.Create.
        /// DEPRECATED: 
        /// Kept for backwards compatibility. Use Post from FoldersController  instead
        /// Please refer to https://docs.uipath.com/orchestrator/reference
        /// </summary>
        public async Task<OneOf<CreatesAnOrganizationUnitOKResponse, CreatesAnOrganizationUnitCreatedResponse>> CreatesAnOrganizationUnit(CreatesAnOrganizationUnitRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/OrganizationUnits", request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<CreatesAnOrganizationUnitOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return await response.ReadNewtonsoftJsonAsync<CreatesAnOrganizationUnitCreatedResponse>();
            }
            throw new Exception($"CreatesAnOrganizationUnit: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Read.
        /// Required permissions: Units.View and Users.View.
        /// DEPRECATED: 
        /// Kept for backwards compatibility.
        /// Please refer to https://docs.uipath.com/orchestrator/reference
        /// </summary>
        public async Task<IonOfAllTheIdsOfTheUsersAssociatedToAnUnitBasedOnUnitIdResponse> IonOfAllTheIdsOfTheUsersAssociatedToAnUnitBasedOnUnitId(IonOfAllTheIdsOfTheUsersAssociatedToAnUnitBasedOnUnitIdParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/OrganizationUnits/UiPath.Server.Configuration.OData.GetUserIdsForUnit(key={_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<IonOfAllTheIdsOfTheUsersAssociatedToAnUnitBasedOnUnitIdResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Read.
        /// Required permissions: Units.View and Users.View.
        /// DEPRECATED: 
        /// Kept for backwards compatibility. Use GetUsersForFolder from FoldersController  instead
        /// Please refer to https://docs.uipath.com/orchestrator/reference
        /// </summary>
        public async Task<LaceFirstThoseAssociatedToAnUnitAllowsOdataQueryOptionsResponse> LaceFirstThoseAssociatedToAnUnitAllowsOdataQueryOptions(LaceFirstThoseAssociatedToAnUnitAllowsOdataQueryOptionsParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/OrganizationUnits/UiPath.Server.Configuration.OData.GetUsersForUnit(key={_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<LaceFirstThoseAssociatedToAnUnitAllowsOdataQueryOptionsResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Read.
        /// Required permissions: Units.View.
        /// DEPRECATED: 
        /// Kept for backwards compatibility. Use Get from FoldersController  instead
        /// Please refer to https://docs.uipath.com/orchestrator/reference
        /// </summary>
        public async Task<GetsAnOrganizationUnitResponse> GetsAnOrganizationUnit(GetsAnOrganizationUnitParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/OrganizationUnits({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsAnOrganizationUnitResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Write.
        /// Required permissions: Units.Edit.
        /// DEPRECATED: 
        /// Kept for backwards compatibility. Use Put from FoldersController  instead
        /// Please refer to https://docs.uipath.com/orchestrator/reference
        /// </summary>
        public async Task<Stream> EditsAnOrganizationUnit(EditsAnOrganizationUnitRequest request)
        {
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"odata/OrganizationUnits({_key})", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Write.
        /// Required permissions: Units.Delete.
        /// DEPRECATED: 
        /// Kept for backwards compatibility. Use Delete from FoldersController  instead
        /// Please refer to https://docs.uipath.com/orchestrator/reference
        /// </summary>
        public async Task<Stream> DeletesAnOrganizationUnit()
        {
            var response = await _httpClient.DeleteAsync($"odata/OrganizationUnits({_key})");
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Write.
        /// Required permissions: Users.Edit.
        /// DEPRECATED: 
        /// Kept for backwards compatibility. Use AssignUsers from FoldersController  instead
        /// Please refer to https://docs.uipath.com/orchestrator/reference
        /// </summary>
        public async Task<Stream> RsWithAndDissociatesAnotherGroupOfUsersFromTheGivenUnit(RsWithAndDissociatesAnotherGroupOfUsersFromTheGivenUnitRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/OrganizationUnits({_key})/UiPath.Server.Configuration.OData.SetUsers", request);
            if (response.StatusCode is HttpStatusCode.OK or HttpStatusCode.NoContent)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"RsWithAndDissociatesAnotherGroupOfUsersFromTheGivenUnit: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        public async Task<GetsPermissionsResponse> GetsPermissions(GetsPermissionsParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Permissions", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsPermissionsResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Folders or OR.Folders.Read.
        /// Required permissions: Units.View.
        /// </summary>
        public async Task<GetsPersonalWorkspacesResponse> GetsPersonalWorkspaces(GetsPersonalWorkspacesParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/PersonalWorkspaces", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsPersonalWorkspacesResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth authentication is not supported.
        /// Requires authentication.
        /// </summary>
        public async Task<OneOf<GetsPersonalWorkspaceForCurrentUserOKResponse, Stream>> GetsPersonalWorkspaceForCurrentUser(GetsPersonalWorkspaceForCurrentUserParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/PersonalWorkspaces/UiPath.Server.Configuration.OData.GetPersonalWorkspace", parametersDict);
            var response = await _httpClient.GetAsync(queryString);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<GetsPersonalWorkspaceForCurrentUserOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"GetsPersonalWorkspaceForCurrentUser: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth authentication is not supported.
        /// Required permissions: Units.Edit.
        /// </summary>
        public async Task<Stream> ConvertsAPersonalWorkspaceToAStandardFolder(ConvertsAPersonalWorkspaceToAStandardFolderRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/PersonalWorkspaces({_key})/UiPath.Server.Configuration.OData.ConvertToFolder", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth authentication is not supported.
        /// Required permissions: Units.Edit and Users.View and Roles.View.
        /// </summary>
        public async Task<Stream> AssignsTheCurrentUserToExploreAPersonalWorkspace()
        {
            var response = await _httpClient.PostAsync($"odata/PersonalWorkspaces({_key})/UiPath.Server.Configuration.OData.StartExploring");
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth authentication is not supported.
        /// Required permissions: Units.Edit and Users.View and Roles.View.
        /// </summary>
        public async Task<Stream> UnassignsTheCurrentUserFromExploringAPersonalWorkspace()
        {
            var response = await _httpClient.PostAsync($"odata/PersonalWorkspaces({_key})/UiPath.Server.Configuration.OData.StopExploring");
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Read.
        /// Required permissions: (Packages.View - Lists packages in a Tenant Feed) and (FolderPackages.View - Lists 
        /// packages in a Folder Feed).
        /// </summary>
        public async Task<GetsTheProcessesResponse> GetsTheProcesses(GetsTheProcessesParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Processes", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTheProcessesResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Read.
        /// Required permissions: (Packages.View - Downloads a package from a Tenant Feed) and (FolderPackages.View 
        /// - Downloads a package from a Folder Feed).
        /// </summary>
        public async Task<Stream> DownloadsTheNupkgFileOfAPackage2(DownloadsTheNupkgFileOfAPackage2Parameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"Accept", $"application/octet-stream" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Processes/UiPath.Server.Configuration.OData.DownloadPackage(key='{_key}')", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Read.
        /// Required permissions: Packages.View.
        /// </summary>
        public async Task<GetProcessParametersResponse> GetProcessParameters(GetProcessParametersParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Processes/UiPath.Server.Configuration.OData.GetArguments(key='{_key}')", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetProcessParametersResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Read.
        /// Required permissions: (Packages.View - Lists versions of a package in a Tenant Feed) and (FolderPackages.View 
        /// - Lists versions of a package in a Folder Feed).
        /// </summary>
        public async Task<AvailableVersionsOfAGivenProcessAllowsOdataQueryOptionsResponse> AvailableVersionsOfAGivenProcessAllowsOdataQueryOptions(AvailableVersionsOfAGivenProcessAllowsOdataQueryOptionsParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Processes/UiPath.Server.Configuration.OData.GetProcessVersions(processId='{_processId}')", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<AvailableVersionsOfAGivenProcessAllowsOdataQueryOptionsResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Write.
        /// Required permissions: (Packages.Create - Uploads a package in a Tenant Feed) and (FolderPackages.Create 
        /// - Uploads a package in a Folder Feed).
        /// </summary>
        public async Task<OneOf<TOfThePackageIsSentAsANupkgFileEmbeddedInTheHTTPRequest2OKResponse, TOfThePackageIsSentAsANupkgFileEmbeddedInTheHTTPRequest2MultiStatusResponse>> TOfThePackageIsSentAsANupkgFileEmbeddedInTheHTTPRequest2(TOfThePackageIsSentAsANupkgFileEmbeddedInTheHTTPRequest2Parameters queryParameters, TOfThePackageIsSentAsANupkgFileEmbeddedInTheHTTPRequest2MultipartFormData formData)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"Content-Type", $"multipart/form-data" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Processes/UiPath.Server.Configuration.OData.UploadPackage", parametersDict);
            var response = await _httpClient.PostAsync(queryString, formData.ToMultipartFormData(), headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<TOfThePackageIsSentAsANupkgFileEmbeddedInTheHTTPRequest2OKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.MultiStatus)
            {
                return await response.ReadNewtonsoftJsonAsync<TOfThePackageIsSentAsANupkgFileEmbeddedInTheHTTPRequest2MultiStatusResponse>();
            }
            throw new Exception($"TOfThePackageIsSentAsANupkgFileEmbeddedInTheHTTPRequest2: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Write.
        /// Required permissions: (Packages.Delete - Deletes a package in a Tenant Feed) and (FolderPackages.Delete 
        /// - Deletes a package in a Folder Feed).
        /// </summary>
        public async Task<Stream> DeletesAPackage2(DeletesAPackage2Parameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Processes('{_key}')", parametersDict);
            var response = await _httpClient.DeleteAsync(queryString);
            if (response.StatusCode is HttpStatusCode.OK or HttpStatusCode.NoContent)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"DeletesAPackage2: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Read.
        /// Required permissions: Schedules.View.
        /// </summary>
        public async Task<GetsTheProcessSchedulesResponse> GetsTheProcessSchedules(GetsTheProcessSchedulesParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/ProcessSchedules", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTheProcessSchedulesResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Write.
        /// Required permissions: Schedules.Create.
        /// </summary>
        public async Task<CreatesANewProcessScheduleResponse> CreatesANewProcessSchedule(CreatesANewProcessScheduleRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PostNewtonsoftJsonAsync<CreatesANewProcessScheduleResponse>($"odata/ProcessSchedules", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Read.
        /// Required permissions: Schedules.View.
        /// </summary>
        public async Task<HeIdsOfTheRobotsAssociatedToAnScheduleBasedOnScheduleIdResponse> HeIdsOfTheRobotsAssociatedToAnScheduleBasedOnScheduleId(HeIdsOfTheRobotsAssociatedToAnScheduleBasedOnScheduleIdParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/ProcessSchedules/UiPath.Server.Configuration.OData.GetRobotIdsForSchedule(key={_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<HeIdsOfTheRobotsAssociatedToAnScheduleBasedOnScheduleIdResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Write.
        /// Required permissions: Schedules.Edit.
        /// </summary>
        public async Task<OneOf<EnablesdisablesAGroupOfSchedulesOKResponse, EnablesdisablesAGroupOfSchedulesMultiStatusResponse, EnablesdisablesAGroupOfSchedulesBadRequestResponse, EnablesdisablesAGroupOfSchedulesNotFoundResponse>> EnablesdisablesAGroupOfSchedules(EnablesdisablesAGroupOfSchedulesParameters queryParameters, EnablesdisablesAGroupOfSchedulesRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/ProcessSchedules/UiPath.Server.Configuration.OData.SetEnabled", parametersDict);
            var response = await _httpClient.PostAsNewtonsoftJsonAsync(queryString, request, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<EnablesdisablesAGroupOfSchedulesOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.MultiStatus)
            {
                return await response.ReadNewtonsoftJsonAsync<EnablesdisablesAGroupOfSchedulesMultiStatusResponse>();
            }
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return await response.ReadNewtonsoftJsonAsync<EnablesdisablesAGroupOfSchedulesBadRequestResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await response.ReadNewtonsoftJsonAsync<EnablesdisablesAGroupOfSchedulesNotFoundResponse>();
            }
            throw new Exception($"EnablesdisablesAGroupOfSchedules: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Write.
        /// Required permissions: Schedules.Create.
        /// </summary>
        public async Task<LidatesTheInputWhichWouldBeUsedToCreateAProcessScheduleResponse> LidatesTheInputWhichWouldBeUsedToCreateAProcessSchedule(LidatesTheInputWhichWouldBeUsedToCreateAProcessScheduleParameters queryParameters, LidatesTheInputWhichWouldBeUsedToCreateAProcessScheduleRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/ProcessSchedules/UiPath.Server.Configuration.OData.ValidateProcessSchedule", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<LidatesTheInputWhichWouldBeUsedToCreateAProcessScheduleResponse>(queryString, request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Read.
        /// Required permissions: Schedules.View.
        /// </summary>
        public async Task<OneOf<GetsASingleProcessScheduleBasedOnItsKeyOKResponse, Stream>> GetsASingleProcessScheduleBasedOnItsKey(GetsASingleProcessScheduleBasedOnItsKeyParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/ProcessSchedules({_key})", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<GetsASingleProcessScheduleBasedOnItsKeyOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"GetsASingleProcessScheduleBasedOnItsKey: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Write.
        /// Required permissions: Schedules.Edit.
        /// </summary>
        public async Task<Stream> EditsAProcessSchedule(EditsAProcessScheduleRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"odata/ProcessSchedules({_key})", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Write.
        /// Required permissions: Schedules.Delete.
        /// </summary>
        public async Task<Stream> DeletesAProcessSchedule()
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.DeleteAsync($"odata/ProcessSchedules({_key})", headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Jobs or OR.Jobs.Write.
        /// Required permissions: Schedules.Edit.
        /// </summary>
        public async Task<Stream> ActivatesAProcessScheduleAssociatedWithAQueue()
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsync($"odata/ProcessSchedules({_key})/UiPath.Server.Configuration.OData.Activate", headers);
            if (response.StatusCode is HttpStatusCode.OK or HttpStatusCode.NotFound or HttpStatusCode.Conflict)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"ActivatesAProcessScheduleAssociatedWithAQueue: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Read.
        /// Required permissions: Queues.View.
        /// </summary>
        public async Task<GetsTheListOfQueueDefinitionsResponse> GetsTheListOfQueueDefinitions(GetsTheListOfQueueDefinitionsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueDefinitions", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTheListOfQueueDefinitionsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Write.
        /// Required permissions: Queues.Create.
        /// </summary>
        public async Task<CreatesANewQueueResponse> CreatesANewQueue(CreatesANewQueueRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PostNewtonsoftJsonAsync<CreatesANewQueueResponse>($"odata/QueueDefinitions", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<UntOfFoldersWhereItIsSharedIncludingInaccessibleFoldersResponse> UntOfFoldersWhereItIsSharedIncludingInaccessibleFolders(UntOfFoldersWhereItIsSharedIncludingInaccessibleFoldersParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueDefinitions/UiPath.Server.Configuration.OData.GetFoldersForQueue(id={_id})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<UntOfFoldersWhereItIsSharedIncludingInaccessibleFoldersResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<TheQueuesViewPermissionExceptTheOnesInTheExcludedFolderResponse> TheQueuesViewPermissionExceptTheOnesInTheExcludedFolder(TheQueuesViewPermissionExceptTheOnesInTheExcludedFolderParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueDefinitions/UiPath.Server.Configuration.OData.GetQueuesAcrossFolders", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<TheQueuesViewPermissionExceptTheOnesInTheExcludedFolderResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Write.
        /// Requires authentication.
        /// </summary>
        public async Task<Stream> MakesTheQueueVisibleInTheSpecifiedFolders(MakesTheQueueVisibleInTheSpecifiedFoldersRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/QueueDefinitions/UiPath.Server.Configuration.OData.ShareToFolders", request, headers);
            if (response.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"MakesTheQueueVisibleInTheSpecifiedFolders: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Read.
        /// Required permissions: Queues.View.
        /// </summary>
        public async Task<GetsASingleQueueDefinitionBasedOnItsIdResponse> GetsASingleQueueDefinitionBasedOnItsId(GetsASingleQueueDefinitionBasedOnItsIdParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueDefinitions({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsASingleQueueDefinitionBasedOnItsIdResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Write.
        /// Required permissions: Queues.Edit.
        /// </summary>
        public async Task<Stream> EditsAQueue(EditsAQueueRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"odata/QueueDefinitions({_key})", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Write.
        /// Required permissions: Queues.Delete.
        /// </summary>
        public async Task<Stream> DeletesAQueueBasedOnItsKey()
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.DeleteAsync($"odata/QueueDefinitions({_key})", headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Write.
        /// Required permissions: Queues.View and Transactions.View.
        /// </summary>
        public async Task<RequestsACSVExportOfFilteredItems3Response> RequestsACSVExportOfFilteredItems3(RequestsACSVExportOfFilteredItems3Parameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueDefinitions({_key})/UiPathODataSvc.Export", parametersDict);
            return await _httpClient.PostFromNewtonsoftJsonAsync<RequestsACSVExportOfFilteredItems3Response>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Read.
        /// Required permissions: Queues.Edit.
        /// </summary>
        public async Task<Stream> NQueueItemJSONSchemaAsAJsonFileBasedOnQueueDefinitionId()
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" },
                { $"Accept", $"application/octet-stream" }
            };
    
            var response = await _httpClient.GetAsync($"odata/QueueDefinitions({_key})/UiPathODataSvc.GetJsonSchemaDefinition(jsonSchemaType='{_jsonSchemaType}')", headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Read.
        /// Required permissions: Queues.View and Transactions.View.
        /// </summary>
        public async Task<GetsTheQueueItemCommentsResponse> GetsTheQueueItemComments(GetsTheQueueItemCommentsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueItemComments", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTheQueueItemCommentsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Write.
        /// Required permissions: Queues.View and Transactions.Edit.
        /// Note: If the CreationTime is passed in in the UiPath.Orchestrator.Application.Dto.Queues.QueueItemCommentDto 
        /// it will be overriden with server UTC time.
        /// </summary>
        public async Task<CreatesAQueueItemCommentResponse> CreatesAQueueItemComment(CreatesAQueueItemCommentRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PostNewtonsoftJsonAsync<CreatesAQueueItemCommentResponse>($"odata/QueueItemComments", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Read.
        /// Required permissions: Queues.View and Transactions.View.
        /// </summary>
        public async Task<ReatedAsARetryOfAFailedQueueItemTheyAlsoShareTheSameKeyResponse> ReatedAsARetryOfAFailedQueueItemTheyAlsoShareTheSameKey(ReatedAsARetryOfAFailedQueueItemTheyAlsoShareTheSameKeyParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueItemComments/UiPath.Server.Configuration.OData.GetQueueItemCommentsHistory(queueItemId={_queueItemId})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ReatedAsARetryOfAFailedQueueItemTheyAlsoShareTheSameKeyResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Read.
        /// Required permissions: Queues.View and Transactions.View.
        /// </summary>
        public async Task<GetsAQueueItemCommentByIdResponse> GetsAQueueItemCommentById(GetsAQueueItemCommentByIdParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueItemComments({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsAQueueItemCommentByIdResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Write.
        /// Required permissions: Queues.View and Transactions.Edit.
        /// </summary>
        public async Task<Stream> UpdatesAQueueItemComment(UpdatesAQueueItemCommentRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"odata/QueueItemComments({_key})", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Write.
        /// Required permissions: Queues.View and Transactions.Edit.
        /// </summary>
        public async Task<Stream> DeletesAQueueItemComment()
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.DeleteAsync($"odata/QueueItemComments({_key})", headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Read.
        /// Required permissions: Queues.View and Transactions.View.
        /// </summary>
        public async Task<GetsTheQueueItemEventsResponse> GetsTheQueueItemEvents(GetsTheQueueItemEventsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueItemEvents", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTheQueueItemEventsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Read.
        /// Required permissions: Queues.View and Transactions.View.
        /// </summary>
        public async Task<ReatedAsARetryOfAFailedQueueItemTheyAlsoShareTheSameKey2Response> ReatedAsARetryOfAFailedQueueItemTheyAlsoShareTheSameKey2(ReatedAsARetryOfAFailedQueueItemTheyAlsoShareTheSameKey2Parameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueItemEvents/UiPath.Server.Configuration.OData.GetQueueItemEventsHistory(queueItemId={_queueItemId})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ReatedAsARetryOfAFailedQueueItemTheyAlsoShareTheSameKey2Response>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Read.
        /// Required permissions: Queues.View and Transactions.View.
        /// </summary>
        public async Task<GetsAQueueItemEventByIdResponse> GetsAQueueItemEventById(GetsAQueueItemEventByIdParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueItemEvents({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsAQueueItemEventByIdResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Read.
        /// Required permissions: Queues.View and Transactions.View.
        /// </summary>
        public async Task<GetsACollectionOfQueueItemsResponse> GetsACollectionOfQueueItems(GetsACollectionOfQueueItemsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueItems", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsACollectionOfQueueItemsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Read.
        /// Required permissions: Queues.View and Transactions.Edit.
        /// </summary>
        public async Task<ThePermissionForQueueItemsReviewAllowsOdataQueryOptionsResponse> ThePermissionForQueueItemsReviewAllowsOdataQueryOptions(ThePermissionForQueueItemsReviewAllowsOdataQueryOptionsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueItems/UiPath.Server.Configuration.OData.GetReviewers", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ThePermissionForQueueItemsReviewAllowsOdataQueryOptionsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Write.
        /// Required permissions: Queues.View and Transactions.Delete.
        /// </summary>
        public async Task<SetsTheGivenQueueItemsStatusToDeletedResponse> SetsTheGivenQueueItemsStatusToDeleted(SetsTheGivenQueueItemsStatusToDeletedParameters queryParameters, SetsTheGivenQueueItemsStatusToDeletedRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueItems/UiPathODataSvc.DeleteBulk", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<SetsTheGivenQueueItemsStatusToDeletedResponse>(queryString, request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Read.
        /// Required permissions: Queues.View and Transactions.View.
        /// </summary>
        public async Task<OneOf<ReturnsTheLastRetryOfAQueueItemByUniqueKeyOKResponse, Stream>> ReturnsTheLastRetryOfAQueueItemByUniqueKey(ReturnsTheLastRetryOfAQueueItemByUniqueKeyParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueItems/UiPathODataSvc.GetItemLastRetryByKey(key={_key})", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<ReturnsTheLastRetryOfAQueueItemByUniqueKeyOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"ReturnsTheLastRetryOfAQueueItemByUniqueKey: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Write.
        /// Required permissions: Queues.View and Transactions.Edit.
        /// </summary>
        public async Task<SetsTheReviewerForMultipleQueueItemsResponse> SetsTheReviewerForMultipleQueueItems(SetsTheReviewerForMultipleQueueItemsParameters queryParameters, SetsTheReviewerForMultipleQueueItemsRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueItems/UiPathODataSvc.SetItemReviewer", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<SetsTheReviewerForMultipleQueueItemsResponse>(queryString, request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Write.
        /// Required permissions: Queues.View and Transactions.Edit.
        /// </summary>
        public async Task<EReviewStatusOfTheSpecifiedQueueItemsToAnIndicatedStateResponse> EReviewStatusOfTheSpecifiedQueueItemsToAnIndicatedState(EReviewStatusOfTheSpecifiedQueueItemsToAnIndicatedStateParameters queryParameters, EReviewStatusOfTheSpecifiedQueueItemsToAnIndicatedStateRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueItems/UiPathODataSvc.SetItemReviewStatus", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<EReviewStatusOfTheSpecifiedQueueItemsToAnIndicatedStateResponse>(queryString, request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Write.
        /// Required permissions: Queues.View and Transactions.Edit.
        /// </summary>
        public async Task<UnsetsTheReviewerForMultipleQueueItemsResponse> UnsetsTheReviewerForMultipleQueueItems(UnsetsTheReviewerForMultipleQueueItemsParameters queryParameters, UnsetsTheReviewerForMultipleQueueItemsRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueItems/UiPathODataSvc.UnsetItemReviewer", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<UnsetsTheReviewerForMultipleQueueItemsResponse>(queryString, request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Read.
        /// Required permissions: Queues.View and Transactions.View.
        /// </summary>
        public async Task<GetsAQueueItemByIdResponse> GetsAQueueItemById(GetsAQueueItemByIdParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueItems({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsAQueueItemByIdResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Write.
        /// Required permissions: Queues.View and Transactions.Delete.
        /// </summary>
        public async Task<Stream> DeletesAQueueItemById()
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.DeleteAsync($"odata/QueueItems({_key})", headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Write.
        /// Required permissions: Queues.Edit and Transactions.Edit.
        /// Only UiPath.Orchestrator.Application.Dto.Queues.QueueItemDto.Progress, UiPath.Orchestrator.Application.Dto.Queues.QueueItemDto.Priority, 
        /// UiPath.Orchestrator.Application.Dto.Queues.QueueItemDto.DueDate, UiPath.Orchestrator.Application.Dto.Queues.QueueItemDto.DeferDate 
        /// and UiPath.Orchestrator.Application.Dto.Queues.QueueItemDto.SpecificContent will be updated from given 
        /// queueItemDto object.
        /// </summary>
        public async Task<Stream> UpdatesTheQueueItemPropertiesWithTheNewValuesProvided(UpdatesTheQueueItemPropertiesWithTheNewValuesProvidedRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"odata/QueueItems({_key})", request, headers);
            if (response.StatusCode is HttpStatusCode.OK or HttpStatusCode.NotFound or HttpStatusCode.Conflict)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"UpdatesTheQueueItemPropertiesWithTheNewValuesProvided: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Read.
        /// Required permissions: Queues.View and Transactions.View.
        /// </summary>
        public async Task<OneOf<ReturnsTheLastRetryOfAQueueItemOKResponse, Stream>> ReturnsTheLastRetryOfAQueueItem(ReturnsTheLastRetryOfAQueueItemParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueItems({_key})/UiPath.Server.Configuration.OData.GetItemLastRetry", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<ReturnsTheLastRetryOfAQueueItemOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"ReturnsTheLastRetryOfAQueueItem: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Read.
        /// Required permissions: Queues.View and Transactions.View.
        /// </summary>
        public async Task<EssingHistoryOfTheGivenQueueItemAllowsOdataQueryOptionsResponse> EssingHistoryOfTheGivenQueueItemAllowsOdataQueryOptions(EssingHistoryOfTheGivenQueueItemAllowsOdataQueryOptionsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueItems({_key})/UiPathODataSvc.GetItemProcessingHistory", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<EssingHistoryOfTheGivenQueueItemAllowsOdataQueryOptionsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Write.
        /// Required permissions: Queues.View and Transactions.Edit.
        /// </summary>
        public async Task<Stream> AtesTheProgressFieldOfAQueueItemWithTheStatusInProgress(AtesTheProgressFieldOfAQueueItemWithTheStatusInProgressRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/QueueItems({_key})/UiPathODataSvc.SetTransactionProgress", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Read.
        /// Required permissions: Queues.View and Transactions.View.
        /// </summary>
        public async Task<TedProcessingStatusForAGivenQueueInTheLastSpecifiedDaysResponse> TedProcessingStatusForAGivenQueueInTheLastSpecifiedDays(TedProcessingStatusForAGivenQueueInTheLastSpecifiedDaysParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueProcessingRecords/UiPathODataSvc.RetrieveLastDaysProcessingRecords(daysNo={_daysNo},queueDefinitionId={_queueDefinitionId})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<TedProcessingStatusForAGivenQueueInTheLastSpecifiedDaysResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Read.
        /// Required permissions: Queues.View.
        /// </summary>
        public async Task<STheProcessingStatusForAllQueuesAllowsOdataQueryOptionsResponse> STheProcessingStatusForAllQueuesAllowsOdataQueryOptions(STheProcessingStatusForAllQueuesAllowsOdataQueryOptionsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueProcessingRecords/UiPathODataSvc.RetrieveQueuesProcessingStatus", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<STheProcessingStatusForAllQueuesAllowsOdataQueryOptionsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Read.
        /// Required permissions: Queues.View.
        /// </summary>
        public async Task<QueueRetentionGetResponse> QueueRetentionGet(QueueRetentionGetParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueRetention", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<QueueRetentionGetResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Read.
        /// Required permissions: Queues.View.
        /// </summary>
        public async Task<QueueRetentionGetByIdResponse> QueueRetentionGetById(QueueRetentionGetByIdParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/QueueRetention({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<QueueRetentionGetByIdResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Write.
        /// Required permissions: Queues.Edit.
        /// </summary>
        public async Task<Stream> QueueRetentionPutById(QueueRetentionPutByIdRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"odata/QueueRetention({_key})", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Write.
        /// Required permissions: Queues.Edit.
        /// </summary>
        public async Task<Stream> QueueRetentionDeleteById()
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.DeleteAsync($"odata/QueueRetention({_key})", headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Write.
        /// Required permissions: Queues.View and Transactions.Edit.
        /// </summary>
        public async Task<Stream> SetsTheResultOfATransaction(SetsTheResultOfATransactionRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Queues({_key})/UiPathODataSvc.SetTransactionResult", request, headers);
            if (response.StatusCode is HttpStatusCode.OK or HttpStatusCode.Conflict)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"SetsTheResultOfATransaction: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Write.
        /// Required permissions: Queues.View and Transactions.Create.
        /// </summary>
        public async Task<AddsANewQueueItemResponse> AddsANewQueueItem(AddsANewQueueItemParameters queryParameters, AddsANewQueueItemRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Queues/UiPathODataSvc.AddQueueItem", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<AddsANewQueueItemResponse>(queryString, request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Write.
        /// Required permissions: Queues.View and Transactions.Create.
        /// </summary>
        public async Task<BulkAddsQueueItemsResponse> BulkAddsQueueItems(BulkAddsQueueItemsParameters queryParameters, BulkAddsQueueItemsRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Queues/UiPathODataSvc.BulkAddQueueItems", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<BulkAddsQueueItemsResponse>(queryString, request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Queues or OR.Queues.Write.
        /// Required permissions: Queues.View and Transactions.View and Transactions.Create and Transactions.Edit.
        /// </summary>
        public async Task<OneOf<StartsATransactionOKResponse, Stream>> StartsATransaction(StartsATransactionParameters queryParameters, StartsATransactionRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Queues/UiPathODataSvc.StartTransaction", parametersDict);
            var response = await _httpClient.PostAsNewtonsoftJsonAsync(queryString, request, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<StartsATransactionOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"StartsATransaction: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Read.
        /// Required permissions: Processes.View.
        /// </summary>
        public async Task<ReleaseRetentionGetResponse> ReleaseRetentionGet(ReleaseRetentionGetParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/ReleaseRetention", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ReleaseRetentionGetResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Read.
        /// Required permissions: Processes.View.
        /// </summary>
        public async Task<ReleaseRetentionGetByIdResponse> ReleaseRetentionGetById(ReleaseRetentionGetByIdParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/ReleaseRetention({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ReleaseRetentionGetByIdResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Write.
        /// Required permissions: Processes.Edit.
        /// </summary>
        public async Task<Stream> ReleaseRetentionPutById(ReleaseRetentionPutByIdRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"odata/ReleaseRetention({_key})", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Write.
        /// Required permissions: Processes.Edit.
        /// </summary>
        public async Task<Stream> ReleaseRetentionDeleteById()
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.DeleteAsync($"odata/ReleaseRetention({_key})", headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Read.
        /// Required permissions: Processes.View.
        /// </summary>
        public async Task<GetsMultipleReleasesResponse> GetsMultipleReleases(GetsMultipleReleasesParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Releases", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsMultipleReleasesResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Write.
        /// Required permissions: (Processes.Create) and (RemoteControl.Create - Required when creating a process 
        /// with live streaming enabled.).
        /// </summary>
        public async Task<OneOf<CreatesANewReleaseCreatedResponse, Stream>> CreatesANewRelease(CreatesANewReleaseRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Releases", request, headers);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return await response.ReadNewtonsoftJsonAsync<CreatesANewReleaseCreatedResponse>();
            }
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"CreatesANewRelease: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Write.
        /// Required permissions: Processes.Edit.
        /// </summary>
        public async Task<Stream> UpdatesThePackageEntryPointForTheGivenRelease(UpdatesThePackageEntryPointForTheGivenReleaseRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Releases/UiPath.Server.Configuration.OData.UpdateByKey", request, headers);
            if (response.StatusCode is HttpStatusCode.OK or HttpStatusCode.BadRequest)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"UpdatesThePackageEntryPointForTheGivenRelease: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Write.
        /// Required permissions: Processes.Edit.
        /// </summary>
        public async Task<EPackageVersionsForTheGivenReleasesToTheLatestAvailableResponse> EPackageVersionsForTheGivenReleasesToTheLatestAvailable(EPackageVersionsForTheGivenReleasesToTheLatestAvailableParameters queryParameters, EPackageVersionsForTheGivenReleasesToTheLatestAvailableRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Releases/UiPath.Server.Configuration.OData.UpdateToLatestPackageVersionBulk", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<EPackageVersionsForTheGivenReleasesToTheLatestAvailableResponse>(queryString, request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Read.
        /// Required permissions: Processes.View.
        /// </summary>
        public async Task<GetsAReleaseByIdResponse> GetsAReleaseById(GetsAReleaseByIdParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Releases({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsAReleaseByIdResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Write.
        /// Required permissions: (Processes.Edit) and (RemoteControl.Create - Required when changing the live streaming 
        /// configuration.).
        /// </summary>
        public async Task<Stream> PartiallyUpdatesARelease(PartiallyUpdatesAReleaseRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PatchAsNewtonsoftJsonAsync($"odata/Releases({_key})", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Write.
        /// Required permissions: (Processes.Edit) and (RemoteControl.Create - Required when changing the live streaming 
        /// configuration.).
        /// </summary>
        public async Task<Stream> EditsARelease(EditsAReleaseRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"odata/Releases({_key})", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Write.
        /// Required permissions: Processes.Delete.
        /// </summary>
        public async Task<Stream> DeletesARelease()
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.DeleteAsync($"odata/Releases({_key})", headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Write.
        /// Required permissions: Processes.Edit.
        /// </summary>
        public async Task<TheGivenReleaseToTheLastVersionItHadBeforeTheCurrentOneResponse> TheGivenReleaseToTheLastVersionItHadBeforeTheCurrentOne(TheGivenReleaseToTheLastVersionItHadBeforeTheCurrentOneParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Releases({_key})/UiPath.Server.Configuration.OData.RollbackToPreviousReleaseVersion", parametersDict);
            return await _httpClient.PostFromNewtonsoftJsonAsync<TheGivenReleaseToTheLastVersionItHadBeforeTheCurrentOneResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Write.
        /// Required permissions: Processes.Edit.
        /// </summary>
        public async Task<ThePackageVersionForTheGivenReleaseToTheLatestAvailableResponse> ThePackageVersionForTheGivenReleaseToTheLatestAvailable(ThePackageVersionForTheGivenReleaseToTheLatestAvailableParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Releases({_key})/UiPath.Server.Configuration.OData.UpdateToLatestPackageVersion", parametersDict);
            return await _httpClient.PostFromNewtonsoftJsonAsync<ThePackageVersionForTheGivenReleaseToTheLatestAvailableResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Write.
        /// Required permissions: Processes.Edit.
        /// </summary>
        public async Task<UpdatesThePackageVersionForTheGivenReleaseResponse> UpdatesThePackageVersionForTheGivenRelease(UpdatesThePackageVersionForTheGivenReleaseParameters queryParameters, UpdatesThePackageVersionForTheGivenReleaseRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Releases({_key})/UiPath.Server.Configuration.OData.UpdateToSpecificPackageVersion", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<UpdatesThePackageVersionForTheGivenReleaseResponse>(queryString, request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Monitoring or OR.Monitoring.Read.
        /// Required permissions: Logs.View.
        /// </summary>
        public async Task<GetsTheRobotLogsResponse> GetsTheRobotLogs(GetsTheRobotLogsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/RobotLogs", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTheRobotLogsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Monitoring or OR.Monitoring.Write.
        /// Required permissions: Logs.View.
        /// </summary>
        public async Task<RequestsACSVExportOfFilteredItems4Response> RequestsACSVExportOfFilteredItems4(RequestsACSVExportOfFilteredItems4Parameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/RobotLogs/UiPath.Server.Configuration.OData.Export", parametersDict);
            return await _httpClient.PostFromNewtonsoftJsonAsync<RequestsACSVExportOfFilteredItems4Response>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Monitoring or OR.Monitoring.Read.
        /// Required permissions: Logs.View.
        /// </summary>
        public async Task<EdByTheMaxResultWindowParameterForAnElasticsearchSourceResponse> EdByTheMaxResultWindowParameterForAnElasticsearchSource(EdByTheMaxResultWindowParameterForAnElasticsearchSourceParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/RobotLogs/UiPath.Server.Configuration.OData.GetTotalCount", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<EdByTheMaxResultWindowParameterForAnElasticsearchSourceResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Read.
        /// Required permissions: Robots.View.
        /// </summary>
        public async Task<GetsRobotsResponse> GetsRobots(GetsRobotsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Robots", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsRobotsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Write.
        /// Required permissions: (Robots.Create - Floating Robot) and (Robots.Create and Machines.View - Standard 
        /// Robot).
        /// </summary>
        public async Task<CreatesANewRobotResponse> CreatesANewRobot(CreatesANewRobotRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PostNewtonsoftJsonAsync<CreatesANewRobotResponse>($"odata/Robots", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Write.
        /// Required permissions: Robots.Edit.
        /// </summary>
        public async Task<Stream> ConvertAStandardAttendedRobotToAFloatingRobot(ConvertAStandardAttendedRobotToAFloatingRobotRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Robots/UiPath.Server.Configuration.OData.ConvertToFloating", request, headers);
            if (response.StatusCode is HttpStatusCode.OK or HttpStatusCode.BadRequest or HttpStatusCode.Conflict)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"ConvertAStandardAttendedRobotToAFloatingRobot: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Write.
        /// Required permissions: Robots.Delete.
        /// </summary>
        public async Task<Stream> DeletesMultipleRobotsBasedOnTheirKeys(DeletesMultipleRobotsBasedOnTheirKeysRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Robots/UiPath.Server.Configuration.OData.DeleteBulk", request, headers);
            if (response.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.BadRequest)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"DeletesMultipleRobotsBasedOnTheirKeys: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Read.
        /// Required permissions: Robots.View or Users.View or Machines.Create or Machines.Edit.
        /// </summary>
        public async Task<GetRobotsAcrossAllAccessibleFoldersResponse> GetRobotsAcrossAllAccessibleFolders(GetRobotsAcrossAllAccessibleFoldersParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Robots/UiPath.Server.Configuration.OData.FindAllAcrossFolders", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetRobotsAcrossAllAccessibleFoldersResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Read.
        /// Required permissions: (Users.View - Required only when the robot's user is expanded) and (Robots.View).
        /// </summary>
        public async Task<GetsRobotsAutoprovisionedFromUsersResponse> GetsRobotsAutoprovisionedFromUsers(GetsRobotsAutoprovisionedFromUsersParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Robots/UiPath.Server.Configuration.OData.GetConfiguredRobots", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsRobotsAutoprovisionedFromUsersResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Read.
        /// Required permissions: (SubFolders.View or Units.View or Jobs.Create).
        /// </summary>
        public async Task<GetFolderRobotsResponse> GetFolderRobots(GetFolderRobotsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Robots/UiPath.Server.Configuration.OData.GetFolderRobots(folderId={_folderId},machineId={_machineId})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetFolderRobotsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Read.
        /// Required permissions: Robots.Create and Machines.View.
        /// </summary>
        public async Task<GetsMachineNameToLicenseKeyMappingResponse> GetsMachineNameToLicenseKeyMapping(GetsMachineNameToLicenseKeyMappingParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Robots/UiPath.Server.Configuration.OData.GetMachineNameToLicenseKeyMappings", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsMachineNameToLicenseKeyMappingResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Read.
        /// Required permissions: Robots.View and Environments.View and Processes.View.
        /// </summary>
        public async Task<IonOfAllRobotsThatCanExecuteTheProcessWithTheProvidedIdResponse> IonOfAllRobotsThatCanExecuteTheProcessWithTheProvidedId(IonOfAllRobotsThatCanExecuteTheProcessWithTheProvidedIdParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Robots/UiPath.Server.Configuration.OData.GetRobotsForProcess(processId='{_processId}')", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<IonOfAllRobotsThatCanExecuteTheProcessWithTheProvidedIdResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Read.
        /// Required permissions: (SubFolders.View or Units.View or Jobs.Create or Users.View).
        /// </summary>
        public async Task<GetsAllRobotsFromAFolderResponse> GetsAllRobotsFromAFolder(GetsAllRobotsFromAFolderParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Robots/UiPath.Server.Configuration.OData.GetRobotsFromFolder(folderId={_folderId})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsAllRobotsFromAFolderResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Read.
        /// Required permissions: Robots.View.
        /// </summary>
        public async Task<GetsUsernamesResponse> GetsUsernames(GetsUsernamesParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Robots/UiPath.Server.Configuration.OData.GetUsernames", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsUsernamesResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Write.
        /// Required permissions: Robots.Edit.
        /// </summary>
        public async Task<Stream> TogglesTheStatusOfTheRobotsEnableddisabled(TogglesTheStatusOfTheRobotsEnableddisabledRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Robots/UiPath.Server.Configuration.OData.ToggleEnabledStatus", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Read.
        /// Required permissions: Robots.View.
        /// </summary>
        public async Task<GetsASingleRobotBasedOnItsKeyResponse> GetsASingleRobotBasedOnItsKey(GetsASingleRobotBasedOnItsKeyParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Robots({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsASingleRobotBasedOnItsKeyResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Write.
        /// Required permissions: Robots.Edit.
        /// </summary>
        public async Task<Stream> EditsARobotBasedOnItsKey(EditsARobotBasedOnItsKeyRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"odata/Robots({_key})", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Write.
        /// Required permissions: Robots.Edit.
        /// </summary>
        public async Task<Stream> PartiallyUpdatesARobot(PartiallyUpdatesARobotRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PatchAsNewtonsoftJsonAsync($"odata/Robots({_key})", request, headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Write.
        /// Required permissions: Robots.Delete.
        /// </summary>
        public async Task<Stream> DeletesARobotBasedOnItsKey()
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.DeleteAsync($"odata/Robots({_key})", headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Read.
        /// Required permissions: Roles.View or Units.Edit or SubFolders.Edit.
        /// </summary>
        public async Task<GetsRolesResponse> GetsRoles(GetsRolesParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Roles", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsRolesResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Write.
        /// Required permissions: Roles.Create.
        /// </summary>
        public async Task<EatesANewRoleCreatingMixedRolesWillNotBeSupportedIn2110Response> EatesANewRoleCreatingMixedRolesWillNotBeSupportedIn2110(EatesANewRoleCreatingMixedRolesWillNotBeSupportedIn2110Request request)
        {
            return await _httpClient.PostNewtonsoftJsonAsync<EatesANewRoleCreatingMixedRolesWillNotBeSupportedIn2110Response>($"odata/Roles", request);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Read.
        /// Required permissions: Roles.View or Users.View.
        /// </summary>
        public async Task<TionOfAllTheIdsOfTheUsersAssociatedToARoleBasedOnRoleIdResponse> TionOfAllTheIdsOfTheUsersAssociatedToARoleBasedOnRoleId(TionOfAllTheIdsOfTheUsersAssociatedToARoleBasedOnRoleIdParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Roles/UiPath.Server.Configuration.OData.GetUserIdsForRole(key={_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<TionOfAllTheIdsOfTheUsersAssociatedToARoleBasedOnRoleIdResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Read.
        /// Required permissions: Roles.View and Users.View.
        /// </summary>
        public async Task<PlaceFirstThoseAssociatedToARoleAllowsOdataQueryOptionsResponse> PlaceFirstThoseAssociatedToARoleAllowsOdataQueryOptions(PlaceFirstThoseAssociatedToARoleAllowsOdataQueryOptionsParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Roles/UiPath.Server.Configuration.OData.GetUsersForRole(key={_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<PlaceFirstThoseAssociatedToARoleAllowsOdataQueryOptionsResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Read.
        /// Required permissions: Roles.View.
        /// </summary>
        public async Task<GetsRoleBasedOnItsIdResponse> GetsRoleBasedOnItsId(GetsRoleBasedOnItsIdParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Roles({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsRoleBasedOnItsIdResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Write.
        /// Required permissions: Roles.Edit.
        /// </summary>
        public async Task<Stream> EditsARole(EditsARoleRequest request)
        {
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"odata/Roles({_key})", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Write.
        /// Required permissions: Roles.Delete.
        /// </summary>
        public async Task<Stream> DeletesARole()
        {
            var response = await _httpClient.DeleteAsync($"odata/Roles({_key})");
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Write.
        /// Required permissions: Roles.Edit and Users.View.
        /// </summary>
        public async Task<Stream> RsWithAndDissociatesAnotherGroupOfUsersFromTheGivenRole(RsWithAndDissociatesAnotherGroupOfUsersFromTheGivenRoleRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Roles({_key})/UiPath.Server.Configuration.OData.SetUsers", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Read.
        /// Required permissions: Robots.View.
        /// </summary>
        public async Task<GetsTheSessionsForTheCurrentFolderResponse> GetsTheSessionsForTheCurrentFolder(GetsTheSessionsForTheCurrentFolderParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Sessions", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTheSessionsForTheCurrentFolderResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Write.
        /// Required permissions: Robots.Delete.
        /// </summary>
        public async Task<Stream> DeletesDisconnectedOrUnresponsiveSessions(DeletesDisconnectedOrUnresponsiveSessionsRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Sessions/UiPath.Server.Configuration.OData.DeleteInactiveUnattendedSessions", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Read.
        /// Required permissions: (Robots.View and Users.View - Classic and modern robot sessions are returned.) 
        /// and (Users.View or Machines.Create or Machines.Edit - Modern robot sessions are returned. Users.View 
        /// is required only when the robot is expanded) and (Robots.View - Classic robot sessions are returned. 
        /// Users.View is required only when the robot is expanded).
        /// </summary>
        public async Task<GetsAllTheTenantSessionsResponse> GetsAllTheTenantSessions(GetsAllTheTenantSessionsParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Sessions/UiPath.Server.Configuration.OData.GetGlobalSessions", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsAllTheTenantSessionsResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Read.
        /// Required permissions: Machines.View.
        /// </summary>
        public async Task<GetsMachineRuntimeSessionsResponse> GetsMachineRuntimeSessions(GetsMachineRuntimeSessionsParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Sessions/UiPath.Server.Configuration.OData.GetMachineSessionRuntimes", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsMachineRuntimeSessionsResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Read.
        /// Required permissions: (Machines.View or Jobs.Create).
        /// </summary>
        public async Task<GetsMachineRuntimeSessionsByFolderIdResponse> GetsMachineRuntimeSessionsByFolderId(GetsMachineRuntimeSessionsByFolderIdParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Sessions/UiPath.Server.Configuration.OData.GetMachineSessionRuntimesByFolderId(folderId={_folderId})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsMachineRuntimeSessionsByFolderIdResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Read.
        /// Required permissions: Machines.View.
        /// </summary>
        public async Task<GetSessionsForAMachineResponse> GetSessionsForAMachine(GetSessionsForAMachineParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Sessions/UiPath.Server.Configuration.OData.GetMachineSessions(key={_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetSessionsForAMachineResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Read.
        /// Required permissions: Robots.View or Users.View.
        /// </summary>
        public async Task<GetsUsernames2Response> GetsUsernames2(GetsUsernames2Parameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Sessions/UiPath.Server.Configuration.OData.GetUsernames", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsUsernames2Response>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Write.
        /// Required permissions: Robots.Edit.
        /// </summary>
        public async Task<Stream> SetsTheExecutionCapabilitiesForASpecifiedHost(SetsTheExecutionCapabilitiesForASpecifiedHostRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Sessions/UiPath.Server.Configuration.OData.SetMaintenanceMode", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Robots or OR.Robots.Write.
        /// Required permissions: Robots.Edit.
        /// </summary>
        public async Task<Stream> TogglesTheDebugModeForTheSpecifiedMachineSession(TogglesTheDebugModeForTheSpecifiedMachineSessionRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Sessions({_key})/UiPath.Server.Configuration.OData.ToggleMachineSessionDebugMode", request);
            if (response.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.BadRequest)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"TogglesTheDebugModeForTheSpecifiedMachineSession: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Read.
        /// Required permissions: Settings.View.
        /// </summary>
        public async Task<GetsTheSettingsResponse> GetsTheSettings(GetsTheSettingsParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Settings", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTheSettingsResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Write.
        /// Required permissions: Settings.Delete.
        /// </summary>
        public async Task<Stream> DeletesValuesForTheSpecifiedSettingsInTheTenantScope(DeletesValuesForTheSpecifiedSettingsInTheTenantScopeRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Settings/UiPath.Server.Configuration.OData.DeleteBulk", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<ReturnsOrchestratorSettingsUsedByActivitiesResponse> ReturnsOrchestratorSettingsUsedByActivities(ReturnsOrchestratorSettingsUsedByActivitiesParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Settings/UiPath.Server.Configuration.OData.GetActivitySettings", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ReturnsOrchestratorSettingsUsedByActivitiesResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Read.
        /// </summary>
        public async Task<GetsTheAuthenticationSettingsResponse> GetsTheAuthenticationSettings(GetsTheAuthenticationSettingsParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Settings/UiPath.Server.Configuration.OData.GetAuthenticationSettings", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTheAuthenticationSettingsResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Read.
        /// Required permissions: Settings.View.
        /// DEPRECATED: 
        /// This API is deprecated. Please do not use it any longer. Use /odata/Calendars instead.
        /// Please refer to https://docs.uipath.com/orchestrator/reference
        /// </summary>
        public async Task<EtsCustomCalendarWithExcludedDatesInUTCForCurrentTenantResponse> EtsCustomCalendarWithExcludedDatesInUTCForCurrentTenant(EtsCustomCalendarWithExcludedDatesInUTCForCurrentTenantParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Settings/UiPath.Server.Configuration.OData.GetCalendar", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<EtsCustomCalendarWithExcludedDatesInUTCForCurrentTenantResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Read.
        /// Required permissions: Settings.Edit or Robots.Create or Robots.Edit.
        /// </summary>
        public async Task<LtValuesWillBeTheActualValuesSetGloballyegResolutionWidResponse> LtValuesWillBeTheActualValuesSetGloballyegResolutionWid(LtValuesWillBeTheActualValuesSetGloballyegResolutionWidParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Settings/UiPath.Server.Configuration.OData.GetExecutionSettingsConfiguration(scope={_scope})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<LtValuesWillBeTheActualValuesSetGloballyegResolutionWidResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Read.
        /// </summary>
        public async Task<GetsSupportedLanguagesResponse> GetsSupportedLanguages(GetsSupportedLanguagesParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Settings/UiPath.Server.Configuration.OData.GetLanguages", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsSupportedLanguagesResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<RetrievesTheCurrentLicenseInformationResponse> RetrievesTheCurrentLicenseInformation(RetrievesTheCurrentLicenseInformationParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Settings/UiPath.Server.Configuration.OData.GetLicense", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<RetrievesTheCurrentLicenseInformationResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Read.
        /// Required permissions: Settings.View.
        /// </summary>
        public async Task<GetsTheConfigurationFormatForASecureStoreResponse> GetsTheConfigurationFormatForASecureStore(GetsTheConfigurationFormatForASecureStoreParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Settings/UiPath.Server.Configuration.OData.GetSecureStoreConfiguration(storeTypeName='{_storeTypeName}')", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTheConfigurationFormatForASecureStoreResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Read.
        /// </summary>
        public async Task<GetsTimezonesResponse> GetsTimezones(GetsTimezonesParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Settings/UiPath.Server.Configuration.OData.GetTimezones", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTimezonesResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Read.
        /// </summary>
        public async Task<GetsTheUpdateSettingsResponse> GetsTheUpdateSettings(GetsTheUpdateSettingsParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Settings/UiPath.Server.Configuration.OData.GetUpdateSettings", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTheUpdateSettingsResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<LuePairsRepresentingSettingsUsedByOrchestratorWebClientResponse> LuePairsRepresentingSettingsUsedByOrchestratorWebClient(LuePairsRepresentingSettingsUsedByOrchestratorWebClientParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Settings/UiPath.Server.Configuration.OData.GetWebSettings", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<LuePairsRepresentingSettingsUsedByOrchestratorWebClientResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Write.
        /// Required permissions: Settings.Edit.
        /// DEPRECATED: 
        /// This API is deprecated. Please do not use it any longer. Use /odata/Calendars instead.
        /// Please refer to https://docs.uipath.com/orchestrator/reference
        /// </summary>
        public async Task<Stream> EtsCustomCalendarWithExcludedDatesInUTCForCurrentTenant2(EtsCustomCalendarWithExcludedDatesInUTCForCurrentTenant2Request request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Settings/UiPath.Server.Configuration.OData.SetCalendar", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Write.
        /// Required permissions: Settings.Edit.
        /// </summary>
        public async Task<Stream> UpdatesTheCurrentSettings(UpdatesTheCurrentSettingsRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Settings/UiPath.Server.Configuration.OData.UpdateBulk", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Write.
        /// Requires authentication.
        /// </summary>
        public async Task<Stream> EditsAUserSetting(EditsAUserSettingRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Settings/UiPath.Server.Configuration.OData.UpdateUserSetting", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Write.
        /// Required permissions: Settings.Edit.
        /// </summary>
        public async Task<Stream> SMTPSettingsAreCorrectOrNotBySendingAnEmailToARecipient(SMTPSettingsAreCorrectOrNotBySendingAnEmailToARecipientRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Settings/UiPath.Server.Configuration.OData.VerifySmtpSetting", request);
            if (response.StatusCode is HttpStatusCode.OK or HttpStatusCode.BadRequest)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"SMTPSettingsAreCorrectOrNotBySendingAnEmailToARecipient: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Read.
        /// Required permissions: Settings.View.
        /// </summary>
        public async Task<GetsASettingsValueBasedOnItsKeyResponse> GetsASettingsValueBasedOnItsKey(GetsASettingsValueBasedOnItsKeyParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Settings('{_key}')", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsASettingsValueBasedOnItsKeyResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Settings or OR.Settings.Write.
        /// Required permissions: Settings.Edit.
        /// </summary>
        public async Task<Stream> EditsASetting(EditsASettingRequest request)
        {
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"odata/Settings('{_key}')", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Required permissions: Tasks.View.
        /// </summary>
        public async Task<GetsTaskActivitiesForATaskResponse> GetsTaskActivitiesForATask(GetsTaskActivitiesForATaskParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TaskActivities/UiPath.Server.Configuration.OData.GetByTaskId(taskId={_taskId})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTaskActivitiesForATaskResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Required permissions: TaskCatalogs.View.
        /// </summary>
        public async Task<GetsTaskCatalogObjectsWithTheGivenODataQueriesResponse> GetsTaskCatalogObjectsWithTheGivenODataQueries(GetsTaskCatalogObjectsWithTheGivenODataQueriesParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TaskCatalogs", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTaskCatalogObjectsWithTheGivenODataQueriesResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Required permissions: TaskCatalogs.Create.
        /// </summary>
        public async Task<CreatesANewTaskCatalogResponse> CreatesANewTaskCatalog(CreatesANewTaskCatalogParameters queryParameters, CreatesANewTaskCatalogRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TaskCatalogs/UiPath.Server.Configuration.OData.CreateTaskCatalog", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<CreatesANewTaskCatalogResponse>(queryString, request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<UntOfFoldersWhereItIsSharedIncludingUnaccessibleFolders4Response> UntOfFoldersWhereItIsSharedIncludingUnaccessibleFolders4(UntOfFoldersWhereItIsSharedIncludingUnaccessibleFolders4Parameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TaskCatalogs/UiPath.Server.Configuration.OData.GetFoldersForTaskCatalog(id={_id})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<UntOfFoldersWhereItIsSharedIncludingUnaccessibleFolders4Response>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<OneOf<ValidatesTaskCatalogDeletionRequestOKResponse, Stream>> ValidatesTaskCatalogDeletionRequest(ValidatesTaskCatalogDeletionRequestParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TaskCatalogs/UiPath.Server.Configuration.OData.GetTaskCatalogExtendedDetails(taskCatalogId={_taskCatalogId})", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<ValidatesTaskCatalogDeletionRequestOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"ValidatesTaskCatalogDeletionRequest: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<OssFoldersHavingGivenPermissionWithTheGivenODataQueriesResponse> OssFoldersHavingGivenPermissionWithTheGivenODataQueries(OssFoldersHavingGivenPermissionWithTheGivenODataQueriesParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TaskCatalogs/UiPath.Server.Configuration.OData.GetTaskCatalogsFromFoldersWithPermissions", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<OssFoldersHavingGivenPermissionWithTheGivenODataQueriesResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Requires authentication.
        /// </summary>
        public async Task<Stream> MakesTheTaskCatalogsVisibleInTheSpecifiedFolders(MakesTheTaskCatalogsVisibleInTheSpecifiedFoldersRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/TaskCatalogs/UiPath.Server.Configuration.OData.ShareToFolders", request, headers);
            if (response.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"MakesTheTaskCatalogsVisibleInTheSpecifiedFolders: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Required permissions: TaskCatalogs.View.
        /// </summary>
        public async Task<OneOf<GetsATaskCatalogItemByIdOKResponse, Stream>> GetsATaskCatalogItemById(GetsATaskCatalogItemByIdParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TaskCatalogs({_key})", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<GetsATaskCatalogItemByIdOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"GetsATaskCatalogItemById: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Required permissions: TaskCatalogs.Delete.
        /// </summary>
        public async Task<Stream> DeletesTaskCatalog()
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.DeleteAsync($"odata/TaskCatalogs({_key})", headers);
            if (response.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.BadRequest or HttpStatusCode.Conflict)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"DeletesTaskCatalog: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Required permissions: TaskCatalogs.Edit.
        /// </summary>
        public async Task<Stream> UpdatesTaskCatalog(UpdatesTaskCatalogRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/TaskCatalogs({_key})/UiPath.Server.Configuration.OData.UpdateTaskCatalog", request, headers);
            if (response.StatusCode is HttpStatusCode.OK or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"UpdatesTaskCatalog: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Required permissions: ActionDesign.View.
        /// </summary>
        public async Task<GetsTaskDefinitionObjectsWithTheGivenODataQueriesResponse> GetsTaskDefinitionObjectsWithTheGivenODataQueries(GetsTaskDefinitionObjectsWithTheGivenODataQueriesParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TaskDefinitions", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTaskDefinitionObjectsWithTheGivenODataQueriesResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Required permissions: ActionDesign.Create.
        /// </summary>
        public async Task<CreatesANewTaskDefinitionResponse> CreatesANewTaskDefinition(CreatesANewTaskDefinitionParameters queryParameters, CreatesANewTaskDefinitionRequest request)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TaskDefinitions/UiPath.Server.Configuration.OData.CreateTaskDefinition", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<CreatesANewTaskDefinitionResponse>(queryString, request);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Required permissions: ActionDesign.View.
        /// </summary>
        public async Task<OneOf<GetAllVersionsOfTaskDefinitionOKResponse, Stream>> GetAllVersionsOfTaskDefinition(GetAllVersionsOfTaskDefinitionParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TaskDefinitions/UiPath.Server.Configuration.OData.GetTaskDefinitionVersions(id={_id})", parametersDict);
            var response = await _httpClient.GetAsync(queryString);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<GetAllVersionsOfTaskDefinitionOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"GetAllVersionsOfTaskDefinition: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Required permissions: ActionDesign.View.
        /// </summary>
        public async Task<OneOf<GetsATaskDefinitionItemByIdOKResponse, Stream>> GetsATaskDefinitionItemById(GetsATaskDefinitionItemByIdParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TaskDefinitions({_key})", parametersDict);
            var response = await _httpClient.GetAsync(queryString);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<GetsATaskDefinitionItemByIdOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"GetsATaskDefinitionItemById: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Required permissions: ActionDesign.Delete.
        /// </summary>
        public async Task<Stream> DeletesTaskDefintionVersion(DeletesTaskDefintionVersionParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TaskDefinitions({_key})", parametersDict);
            var response = await _httpClient.DeleteAsync(queryString);
            if (response.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.NotFound or HttpStatusCode.Conflict)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"DeletesTaskDefintionVersion: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Required permissions: ActionDesign.Edit.
        /// </summary>
        public async Task<Stream> UpdatesTaskDefinition(UpdatesTaskDefinitionRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/TaskDefinitions({_key})/UiPath.Server.Configuration.OData.UpdateTaskDefinition", request);
            if (response.StatusCode is HttpStatusCode.OK or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"UpdatesTaskDefinition: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Required permissions: Tasks.Edit.
        /// </summary>
        public async Task<AddsATaskNoteResponse> AddsATaskNote(AddsATaskNoteParameters queryParameters, AddsATaskNoteRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TaskNotes/UiPath.Server.Configuration.OData.CreateTaskNote", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<AddsATaskNoteResponse>(queryString, request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Required permissions: Tasks.View.
        /// </summary>
        public async Task<GetsTaskNotesForATaskResponse> GetsTaskNotesForATask(GetsTaskNotesForATaskParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TaskNotes/UiPath.Server.Configuration.OData.GetByTaskId(taskId={_taskId})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTaskNotesForATaskResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Read.
        /// Required permissions: TaskCatalogs.View.
        /// </summary>
        public async Task<TaskRetentionGetResponse> TaskRetentionGet(TaskRetentionGetParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TaskRetention", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<TaskRetentionGetResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Read.
        /// Required permissions: TaskCatalogs.View.
        /// </summary>
        public async Task<OneOf<TaskRetentionGetByIdOKResponse, Stream>> TaskRetentionGetById(TaskRetentionGetByIdParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TaskRetention({_key})", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<TaskRetentionGetByIdOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"TaskRetentionGetById: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Write.
        /// Required permissions: TaskCatalogs.Edit.
        /// </summary>
        public async Task<Stream> TaskRetentionPutById(TaskRetentionPutByIdRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"odata/TaskRetention({_key})", request, headers);
            if (response.StatusCode is HttpStatusCode.OK or HttpStatusCode.BadRequest or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"TaskRetentionPutById: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Execution or OR.Execution.Write.
        /// Required permissions: TaskCatalogs.Delete.
        /// </summary>
        public async Task<Stream> TaskRetentionDeleteById()
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.DeleteAsync($"odata/TaskRetention({_key})", headers);
            if (response.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"TaskRetentionDeleteById: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<TsTaskObjectsFromClassicFoldersWithTheGivenODataQueriesResponse> TsTaskObjectsFromClassicFoldersWithTheGivenODataQueries(TsTaskObjectsFromClassicFoldersWithTheGivenODataQueriesParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Tasks", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<TsTaskObjectsFromClassicFoldersWithTheGivenODataQueriesResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Requires authentication.
        /// </summary>
        public async Task<AssignsTheTasksToGivenUsersResponse> AssignsTheTasksToGivenUsers(AssignsTheTasksToGivenUsersParameters queryParameters, AssignsTheTasksToGivenUsersRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Tasks/UiPath.Server.Configuration.OData.AssignTasks", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<AssignsTheTasksToGivenUsersResponse>(queryString, request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Requires authentication.
        /// </summary>
        public async Task<DeletesTheTasksResponse> DeletesTheTasks(DeletesTheTasksParameters queryParameters, DeletesTheTasksRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Tasks/UiPath.Server.Configuration.OData.DeleteTasks", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<DeletesTheTasksResponse>(queryString, request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Requires authentication.
        /// </summary>
        public async Task<Stream> EditsTheMetadataOfATask(EditsTheMetadataOfATaskRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Tasks/UiPath.Server.Configuration.OData.EditTaskMetadata", request, headers);
            if (response.StatusCode is HttpStatusCode.OK or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"EditsTheMetadataOfATask: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<OneOf<GetsATaskWithTheGivenGuidOKResponse, Stream>> GetsATaskWithTheGivenGuid(GetsATaskWithTheGivenGuidParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Tasks/UiPath.Server.Configuration.OData.GetByKey(identifier={_identifier})", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<GetsATaskWithTheGivenGuidOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"GetsATaskWithTheGivenGuid: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<ElatedPermissionsForTheLoggedInUserOnTheFolderInSessionResponse> ElatedPermissionsForTheLoggedInUserOnTheFolderInSession(ElatedPermissionsForTheLoggedInUserOnTheFolderInSessionParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Tasks/UiPath.Server.Configuration.OData.GetTaskPermissions", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ElatedPermissionsForTheLoggedInUserOnTheFolderInSessionResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<SsFoldersIncludingModernFoldersWithTheGivenODataQueriesResponse> SsFoldersIncludingModernFoldersWithTheGivenODataQueries(SsFoldersIncludingModernFoldersWithTheGivenODataQueriesParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Tasks/UiPath.Server.Configuration.OData.GetTasksAcrossFolders", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<SsFoldersIncludingModernFoldersWithTheGivenODataQueriesResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<SerHasTaskAdminPermissionsWithTheGivenODataQueryOptionsResponse> SerHasTaskAdminPermissionsWithTheGivenODataQueryOptions(SerHasTaskAdminPermissionsWithTheGivenODataQueryOptionsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Tasks/UiPath.Server.Configuration.OData.GetTasksAcrossFoldersForAdmin", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<SerHasTaskAdminPermissionsWithTheGivenODataQueryOptionsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Required permissions: Tasks.View and Tasks.Edit.
        /// </summary>
        public async Task<OrganizationUnitWhoHaveTasksViewAndTasksEditPermissionsResponse> OrganizationUnitWhoHaveTasksViewAndTasksEditPermissions(OrganizationUnitWhoHaveTasksViewAndTasksEditPermissionsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Tasks/UiPath.Server.Configuration.OData.GetTaskUsers(organizationUnitId={_organizationUnitId})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<OrganizationUnitWhoHaveTasksViewAndTasksEditPermissionsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Requires authentication.
        /// </summary>
        public async Task<ReassignsTheTasksToGivenUsersResponse> ReassignsTheTasksToGivenUsers(ReassignsTheTasksToGivenUsersParameters queryParameters, ReassignsTheTasksToGivenUsersRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Tasks/UiPath.Server.Configuration.OData.ReassignTasks", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<ReassignsTheTasksToGivenUsersResponse>(queryString, request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Requires authentication.
        /// </summary>
        public async Task<UnassignsTheTasksFromTheUsersResponse> UnassignsTheTasksFromTheUsers(UnassignsTheTasksFromTheUsersParameters queryParameters, UnassignsTheTasksFromTheUsersRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Tasks/UiPath.Server.Configuration.OData.UnassignTasks", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<UnassignsTheTasksFromTheUsersResponse>(queryString, request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<OneOf<GetsATaskWithTheGivenPrimaryKeyOKResponse, Stream>> GetsATaskWithTheGivenPrimaryKey(GetsATaskWithTheGivenPrimaryKeyParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Tasks({_key})", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<GetsATaskWithTheGivenPrimaryKeyOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"GetsATaskWithTheGivenPrimaryKey: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Administration or OR.Administration.Read.
        /// Host only. Requires authentication.
        /// </summary>
        public async Task<GetsTenantsResponse> GetsTenants(GetsTenantsParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Tenants", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTenantsResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Administration or OR.Administration.Read.
        /// Host only. Requires authentication.
        /// </summary>
        public async Task<GetsASingleTenantBasedOnItsIdResponse> GetsASingleTenantBasedOnItsId(GetsASingleTenantBasedOnItsIdParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Tenants({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsASingleTenantBasedOnItsIdResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSets or OR.TestSets.Read.
        /// Required permissions: TestSets.View.
        /// Responses:
        /// 200 Returns a list of Test Case Definitions filtered with queryOptions
        /// 403 If the caller doesn't have permissions to view Test Case Definitions
        /// </summary>
        public async Task<ReturnsAListOfTestCaseDefinitionsResponse> ReturnsAListOfTestCaseDefinitions(ReturnsAListOfTestCaseDefinitionsParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TestCaseDefinitions", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ReturnsAListOfTestCaseDefinitionsResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSetExecutions or OR.TestSetExecutions.Read.
        /// Required permissions: TestSetExecutions.View.
        /// Responses:
        /// 200 Return a specific Test Case Execution identified by key
        /// 403 If the caller doesn't have permissions to view Test Set Executions
        /// </summary>
        public async Task<ReturnsAListOfTestCaseExecutionsResponse> ReturnsAListOfTestCaseExecutions(ReturnsAListOfTestCaseExecutionsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TestCaseExecutions", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ReturnsAListOfTestCaseExecutionsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSetExecutions or OR.TestSetExecutions.Read.
        /// Required permissions: TestSetExecutions.View.
        /// Responses:
        /// 200 Return a specific Test Case Execution identified by key
        /// 403 If the caller doesn't have permissions to view Test Set Executions
        /// 404 If the test case execution is not found
        /// </summary>
        public async Task<ReturnASpecificTestCaseExecutionIdentifiedByKeyResponse> ReturnASpecificTestCaseExecutionIdentifiedByKey(ReturnASpecificTestCaseExecutionIdentifiedByKeyParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TestCaseExecutions({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ReturnASpecificTestCaseExecutionIdentifiedByKeyResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestDataQueues or OR.TestDataQueues.Read.
        /// Required permissions: TestDataQueueItems.View.
        /// Responses:
        /// 200 Returns a list of test data queue items filtered with queryOptions
        /// 403 If the caller doesn't have permissions to view test data queue items
        /// </summary>
        public async Task<ReturnAListOfTestDataQueueItemsResponse> ReturnAListOfTestDataQueueItems(ReturnAListOfTestDataQueueItemsParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TestDataQueueItems", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ReturnAListOfTestDataQueueItemsResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestDataQueues or OR.TestDataQueues.Read.
        /// Required permissions: TestDataQueueItems.View.
        /// Responses:
        /// 200 Returns a specific test data queue item identified by key
        /// 403 If the caller doesn't have permissions to view test data queue items
        /// 404 If the test data queue item is not found
        /// </summary>
        public async Task<ReturnASpecificTestDataQueueItemIdentifiedByKeyResponse> ReturnASpecificTestDataQueueItemIdentifiedByKey(ReturnASpecificTestDataQueueItemIdentifiedByKeyParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TestDataQueueItems({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ReturnASpecificTestDataQueueItemIdentifiedByKeyResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestDataQueues or OR.TestDataQueues.Read.
        /// Required permissions: TestDataQueues.View.
        /// Responses:
        /// 200 Returns a list of test data queues filtered with queryOptions
        /// 403 If the caller doesn't have permissions to view test data queues
        /// </summary>
        public async Task<ReturnAListOfTestDataQueuesResponse> ReturnAListOfTestDataQueues(ReturnAListOfTestDataQueuesParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TestDataQueues", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ReturnAListOfTestDataQueuesResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestDataQueues or OR.TestDataQueues.Write.
        /// Required permissions: TestDataQueues.Create.
        /// Responses:
        /// 201 Returns the newly created test data queue
        /// 403 If the caller doesn't have permissions to create test data queues
        /// 409 If a queue with the same name already exists
        /// </summary>
        public async Task<CreateANewTestDataQueueResponse> CreateANewTestDataQueue(CreateANewTestDataQueueRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PostNewtonsoftJsonAsync<CreateANewTestDataQueueResponse>($"odata/TestDataQueues", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestDataQueues or OR.TestDataQueues.Read.
        /// Required permissions: TestDataQueues.View.
        /// Responses:
        /// 200 Returns a specific test data queue identified by key
        /// 403 If the caller doesn't have permissions to view test data queues
        /// 404 If the test data queue is not found
        /// </summary>
        public async Task<ReturnASpecificTestDataQueueIdentifiedByKeyResponse> ReturnASpecificTestDataQueueIdentifiedByKey(ReturnASpecificTestDataQueueIdentifiedByKeyParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TestDataQueues({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ReturnASpecificTestDataQueueIdentifiedByKeyResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestDataQueues or OR.TestDataQueues.Write.
        /// Required permissions: TestDataQueues.Edit.
        /// Responses:
        /// 200 Returns the updated test data queue
        /// 403 If the caller doesn't have permissions to update test data queues
        /// 409 If trying to change the queue name
        /// </summary>
        public async Task<UpdateAnExistingTestDataQueueResponse> UpdateAnExistingTestDataQueue(UpdateAnExistingTestDataQueueRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PutNewtonsoftJsonAsync<UpdateAnExistingTestDataQueueResponse>($"odata/TestDataQueues({_key})", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestDataQueues or OR.TestDataQueues.Write.
        /// Required permissions: TestDataQueues.Delete.
        /// Responses:
        /// 204 The test data queue was deleted
        /// 403 If the caller doesn't have permissions to delete test data queues
        /// </summary>
        public async Task<Stream> DeleteAnExistingTestDataQueue()
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.DeleteAsync($"odata/TestDataQueues({_key})", headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSetExecutions or OR.TestSetExecutions.Read.
        /// Required permissions: TestSetExecutions.View.
        /// Responses:
        /// 200 Returns a list of Test Set Executions filtered with queryOptions
        /// 403 If the caller doesn't have permissions to view Test Set Executions
        /// </summary>
        public async Task<AsTestSetExecutionsViewIfThereIsNoneWillReturnForbiddenResponse> AsTestSetExecutionsViewIfThereIsNoneWillReturnForbidden(AsTestSetExecutionsViewIfThereIsNoneWillReturnForbiddenParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TestSetExecutions", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<AsTestSetExecutionsViewIfThereIsNoneWillReturnForbiddenResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSetExecutions or OR.TestSetExecutions.Read.
        /// Required permissions: TestSetExecutions.View.
        /// Responses:
        /// 200 Return a specific Test Set Execution identified by key
        /// 403 If the caller doesn't have permissions to view Test Set Executions
        /// 404 It the test set execution is not found
        /// </summary>
        public async Task<ReturnASpecificTestSetExecutionIdentifiedByKeyResponse> ReturnASpecificTestSetExecutionIdentifiedByKey(ReturnASpecificTestSetExecutionIdentifiedByKeyParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TestSetExecutions({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ReturnASpecificTestSetExecutionIdentifiedByKeyResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSets or OR.TestSets.Read.
        /// Required permissions: TestSets.View.
        /// Responses:
        /// 200 Returns a list of Test Sets filtered with queryOptions
        /// 403 If the caller doesn't have permissions to view Test Sets
        /// </summary>
        public async Task<RentUserHasTestSetsViewIfThereIsNoneWillReturnForbiddenResponse> RentUserHasTestSetsViewIfThereIsNoneWillReturnForbidden(RentUserHasTestSetsViewIfThereIsNoneWillReturnForbiddenParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TestSets", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<RentUserHasTestSetsViewIfThereIsNoneWillReturnForbiddenResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSets or OR.TestSets.Write.
        /// Required permissions: TestSets.Create.
        /// Responses:
        /// 201 Returns the newly created Test Set
        /// 403 If the caller doesn't have permissions to create Test Sets
        /// </summary>
        public async Task<CreatesANewTestSetResponse> CreatesANewTestSet(CreatesANewTestSetRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PostNewtonsoftJsonAsync<CreatesANewTestSetResponse>($"odata/TestSets", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSets or OR.TestSets.Read.
        /// Required permissions: TestSets.View.
        /// Responses:
        /// 200 Return a specific Test Set identified by key
        /// 403 If the caller doesn't have permissions to view Test Sets
        /// 404 If the Test Set is not found
        /// </summary>
        public async Task<ReturnASpecificTestSetIdentifiedByKeyResponse> ReturnASpecificTestSetIdentifiedByKey(ReturnASpecificTestSetIdentifiedByKeyParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TestSets({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ReturnASpecificTestSetIdentifiedByKeyResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSets or OR.TestSets.Write.
        /// Required permissions: TestSets.Edit.
        /// Responses:
        /// 200 Returns the updated Test Set
        /// 403 If the caller doesn't have permissions to update Test Sets
        /// </summary>
        public async Task<UpdateAnExistingTestSetResponse> UpdateAnExistingTestSet(UpdateAnExistingTestSetRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PutNewtonsoftJsonAsync<UpdateAnExistingTestSetResponse>($"odata/TestSets({_key})", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSets or OR.TestSets.Write.
        /// Required permissions: TestSets.Delete.
        /// Responses:
        /// 204 The Test Set was deleted
        /// 403 If the caller doesn't have permissions to delete Test Sets
        /// </summary>
        public async Task<Stream> DeleteATestSet()
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.DeleteAsync($"odata/TestSets({_key})", headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSetSchedules or OR.TestSetSchedules.Read.
        /// Required permissions: TestSetSchedules.View.
        /// Responses:
        /// 200 Returns a list of test set execution schedules filtered with queryOptions
        /// 403 If the caller doesn't have permissions to view test set execution schedules
        /// </summary>
        public async Task<ReturnsAListOfTestSetExecutionSchedulesResponse> ReturnsAListOfTestSetExecutionSchedules(ReturnsAListOfTestSetExecutionSchedulesParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TestSetSchedules", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ReturnsAListOfTestSetExecutionSchedulesResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSetSchedules or OR.TestSetSchedules.Write.
        /// Required permissions: TestSetSchedules.Create.
        /// Responses:
        /// 201 Returns the newly created test set execution schedule
        /// 403 If the caller doesn't have permissions to create test set execution schedules
        /// </summary>
        public async Task<CreatesANewTestSetExecutionScheduleResponse> CreatesANewTestSetExecutionSchedule(CreatesANewTestSetExecutionScheduleRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PostNewtonsoftJsonAsync<CreatesANewTestSetExecutionScheduleResponse>($"odata/TestSetSchedules", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSetSchedules or OR.TestSetSchedules.Write.
        /// Required permissions: TestSetSchedules.Edit.
        /// </summary>
        public async Task<EnablesDisablesAListOfTestSetExecutionSchedulesResponse> EnablesDisablesAListOfTestSetExecutionSchedules(EnablesDisablesAListOfTestSetExecutionSchedulesParameters queryParameters, EnablesDisablesAListOfTestSetExecutionSchedulesRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TestSetSchedules/UiPath.Server.Configuration.OData.SetEnabled", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<EnablesDisablesAListOfTestSetExecutionSchedulesResponse>(queryString, request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSetSchedules or OR.TestSetSchedules.Read.
        /// Required permissions: TestSetSchedules.View.
        /// Responses:
        /// 200 Return a specific test set execution schedule identified by key
        /// 403 If the caller doesn't have permissions to view test set execution schedules
        /// 404 It the test set execution schedule is not found
        /// </summary>
        public async Task<ReturnASpecificTestSetExecutionScheduleIdentifiedByKeyResponse> ReturnASpecificTestSetExecutionScheduleIdentifiedByKey(ReturnASpecificTestSetExecutionScheduleIdentifiedByKeyParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/TestSetSchedules({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ReturnASpecificTestSetExecutionScheduleIdentifiedByKeyResponse>(queryString, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSetSchedules or OR.TestSetSchedules.Write.
        /// Required permissions: TestSetSchedules.Edit.
        /// Responses:
        /// 201 Returns the updated test set execution schedule
        /// 403 If the caller doesn't have permissions to update test set execution schedules
        /// </summary>
        public async Task<UpdateAnExistingTestSetExecutionScheduleResponse> UpdateAnExistingTestSetExecutionSchedule(UpdateAnExistingTestSetExecutionScheduleRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PutNewtonsoftJsonAsync<UpdateAnExistingTestSetExecutionScheduleResponse>($"odata/TestSetSchedules({_key})", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.TestSetSchedules or OR.TestSetSchedules.Write.
        /// Required permissions: TestSetSchedules.Delete.
        /// Responses:
        /// 204 The test set execution schedule was deleted
        /// 403 If the caller doesn't have permissions to delete test set execution schedules
        /// </summary>
        public async Task<Stream> DeleteAnExistingTestSetExecutionSchedule()
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.DeleteAsync($"odata/TestSetSchedules({_key})", headers);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Read.
        /// Required permissions: Users.View.
        /// </summary>
        public async Task<GetsUsersResponse> GetsUsers(GetsUsersParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Users", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsUsersResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Write.
        /// Required permissions: Users.Create.
        /// </summary>
        public async Task<CreatesANewUserResponse> CreatesANewUser(CreatesANewUserRequest request)
        {
            return await _httpClient.PostNewtonsoftJsonAsync<CreatesANewUserResponse>($"odata/Users", request);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Write.
        /// Requires authentication.
        /// </summary>
        public async Task<Stream> ChangesTheCultureForTheCurrentUser(ChangesTheCultureForTheCurrentUserRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Users/UiPath.Server.Configuration.OData.ChangeCulture", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<OneOf<TainingDataAboutTheCurrentUserAndAllThePermissionsItHasOKResponse, Stream>> TainingDataAboutTheCurrentUserAndAllThePermissionsItHas(TainingDataAboutTheCurrentUserAndAllThePermissionsItHasParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Users/UiPath.Server.Configuration.OData.GetCurrentPermissions", parametersDict);
            var response = await _httpClient.GetAsync(queryString);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<TainingDataAboutTheCurrentUserAndAllThePermissionsItHasOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"TainingDataAboutTheCurrentUserAndAllThePermissionsItHas: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Read.
        /// </summary>
        public async Task<OneOf<TurnsDetailsAboutTheUserCurrentlyLoggedIntoOrchestratorOKResponse, Stream>> TurnsDetailsAboutTheUserCurrentlyLoggedIntoOrchestrator(TurnsDetailsAboutTheUserCurrentlyLoggedIntoOrchestratorParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Users/UiPath.Server.Configuration.OData.GetCurrentUser", parametersDict);
            var response = await _httpClient.GetAsync(queryString);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<TurnsDetailsAboutTheUserCurrentlyLoggedIntoOrchestratorOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"TurnsDetailsAboutTheUserCurrentlyLoggedIntoOrchestrator: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Read.
        /// Required permissions: Users.View.
        /// </summary>
        public async Task<ValidatesIfTheRobotsForTheGivenUsersAreBusyResponse> ValidatesIfTheRobotsForTheGivenUsersAreBusy(ValidatesIfTheRobotsForTheGivenUsersAreBusyParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Users/UiPath.Server.Configuration.OData.Validate(userIds=[{_userIds}])", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ValidatesIfTheRobotsForTheGivenUsersAreBusyResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Read.
        /// Requires authentication.
        /// </summary>
        public async Task<GetsAUserBasedOnItsIdResponse> GetsAUserBasedOnItsId(GetsAUserBasedOnItsIdParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Users({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsAUserBasedOnItsIdResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Write.
        /// Required permissions: Users.Edit or Robots.Create or Robots.Edit or Robots.Delete.
        /// </summary>
        public async Task<Stream> EditsAUser(EditsAUserRequest request)
        {
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"odata/Users({_key})", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Write.
        /// Requires authentication.
        /// </summary>
        public async Task<Stream> UserCannotUpdateRolesOrOrganizationUnitsViaThisEndpoint(UserCannotUpdateRolesOrOrganizationUnitsViaThisEndpointRequest request)
        {
            var response = await _httpClient.PatchAsNewtonsoftJsonAsync($"odata/Users({_key})", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Write.
        /// Required permissions: Users.Delete.
        /// </summary>
        public async Task<Stream> DeletesAUser()
        {
            var response = await _httpClient.DeleteAsync($"odata/Users({_key})");
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Write.
        /// Required permissions: Users.Edit or Users.Create.
        /// </summary>
        public async Task<Stream> UsersAssignRolesById(UsersAssignRolesByIdRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Users({_key})/UiPath.Server.Configuration.OData.AssignRoles", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Write.
        /// Required permissions: Users.Edit.
        /// </summary>
        public async Task<Stream> ChangesTheCultureForTheSpecifiedUser(ChangesTheCultureForTheSpecifiedUserRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Users({_key})/UiPath.Server.Configuration.OData.ChangeUserCulture", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Write.
        /// Required permissions: Users.Edit.
        /// DEPRECATED: 
        /// This API is deprecated. Please do not use it any longer.
        /// Please refer to https://docs.uipath.com/orchestrator/reference
        /// </summary>
        public async Task<Stream> ActivateOrDeactivateAUser(ActivateOrDeactivateAUserRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Users({_key})/UiPath.Server.Configuration.OData.SetActive", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Users or OR.Users.Write.
        /// Required permissions: Users.Edit.
        /// </summary>
        public async Task<Stream> SociatesTheGivenUserWithfromARoleBasedOnToggleParameter(SociatesTheGivenUserWithfromARoleBasedOnToggleParameterRequest request)
        {
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"odata/Users({_key})/UiPath.Server.Configuration.OData.ToggleRole", request);
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Webhooks or OR.Webhooks.Read.
        /// Required permissions: Webhooks.View.
        /// </summary>
        public async Task<ListWebhooksResponse> ListWebhooks(ListWebhooksParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Webhooks", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<ListWebhooksResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Webhooks or OR.Webhooks.Write.
        /// Required permissions: Webhooks.Create.
        /// </summary>
        public async Task<CreateANewWebhookSubscriptionResponse> CreateANewWebhookSubscription(CreateANewWebhookSubscriptionRequest request)
        {
            return await _httpClient.PostNewtonsoftJsonAsync<CreateANewWebhookSubscriptionResponse>($"odata/Webhooks", request);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Webhooks or OR.Webhooks.Read.
        /// Required permissions: Webhooks.View.
        /// </summary>
        public async Task<GetsTheListOfEventTypesAWebhookCanSubscribeToResponse> GetsTheListOfEventTypesAWebhookCanSubscribeTo(GetsTheListOfEventTypesAWebhookCanSubscribeToParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Webhooks/UiPath.Server.Configuration.OData.GetEventTypes", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsTheListOfEventTypesAWebhookCanSubscribeToResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Webhooks or OR.Webhooks.Write.
        /// Required permissions: Webhooks.View.
        /// </summary>
        public async Task<TriggersAnEventOfTypeCustomResponse> TriggersAnEventOfTypeCustom(TriggersAnEventOfTypeCustomParameters queryParameters, TriggersAnEventOfTypeCustomRequest request)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Webhooks/UiPath.Server.Configuration.OData.TriggerCustom", parametersDict);
            return await _httpClient.PostNewtonsoftJsonAsync<TriggersAnEventOfTypeCustomResponse>(queryString, request);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Webhooks or OR.Webhooks.Read.
        /// Required permissions: Webhooks.View.
        /// </summary>
        public async Task<GetsASingleWebhookResponse> GetsASingleWebhook(GetsASingleWebhookParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Webhooks({_key})", parametersDict);
            return await _httpClient.GetFromNewtonsoftJsonAsync<GetsASingleWebhookResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Webhooks or OR.Webhooks.Write.
        /// Required permissions: Webhooks.Edit.
        /// </summary>
        public async Task<UpdateAnExistingWebhookSubscriptionResponse> UpdateAnExistingWebhookSubscription(UpdateAnExistingWebhookSubscriptionRequest request)
        {
            return await _httpClient.PutNewtonsoftJsonAsync<UpdateAnExistingWebhookSubscriptionResponse>($"odata/Webhooks({_key})", request);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Webhooks or OR.Webhooks.Write.
        /// Required permissions: Webhooks.Edit.
        /// </summary>
        public async Task<PatchesAWebhookResponse> PatchesAWebhook(PatchesAWebhookRequest request)
        {
            return await _httpClient.PatchNewtonsoftJsonAsync<PatchesAWebhookResponse>($"odata/Webhooks({_key})", request);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Webhooks or OR.Webhooks.Write.
        /// Required permissions: Webhooks.Delete.
        /// </summary>
        public async Task<Stream> DeleteAWebhookSubscription()
        {
            var response = await _httpClient.DeleteAsync($"odata/Webhooks({_key})");
            return await response.Content.ReadAsStreamAsync();
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Webhooks or OR.Webhooks.Write.
        /// Required permissions: Webhooks.View.
        /// </summary>
        public async Task<IntUsedForTestingConnectivityAndAvailabilityOfTargetURLResponse> IntUsedForTestingConnectivityAndAvailabilityOfTargetURL(IntUsedForTestingConnectivityAndAvailabilityOfTargetURLParameters queryParameters)
        {
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"odata/Webhooks({_key})/UiPath.Server.Configuration.OData.Ping", parametersDict);
            return await _httpClient.PostFromNewtonsoftJsonAsync<IntUsedForTestingConnectivityAndAvailabilityOfTargetURLResponse>(queryString);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Required permissions: Tasks.Edit.
        /// </summary>
        public async Task<Stream> CompleteTheTaskBySavingAppTaskDataAndActionTaken(CompleteTheTaskBySavingAppTaskDataAndActionTakenRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"tasks/AppTasks/CompleteAppTask", request, headers);
            if (response.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.BadRequest or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"CompleteTheTaskBySavingAppTaskDataAndActionTaken: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: ((JamJamApi or JamJamApi.Write) and (RCS.FolderAuthorization or RCS.FolderAuthorization.Write)) 
        /// and (OR.Tasks or OR.Tasks.Write).
        /// Required permissions: Tasks.Create.
        /// </summary>
        public async Task<OneOf<CreatesANewAppTaskCreatedResponse, Stream>> CreatesANewAppTask(CreatesANewAppTaskRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"tasks/AppTasks/CreateAppTask", request, headers);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return await response.ReadNewtonsoftJsonAsync<CreatesANewAppTaskCreatedResponse>();
            }
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"CreatesANewAppTask: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Required permissions: Tasks.View.
        /// </summary>
        public async Task<OneOf<ReturnsDtoToRenderAppTaskOKResponse, Stream>> ReturnsDtoToRenderAppTask(ReturnsDtoToRenderAppTaskParameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"tasks/AppTasks/GetAppTaskById", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<ReturnsDtoToRenderAppTaskOKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"ReturnsDtoToRenderAppTask: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: ((JamJamApi or JamJamApi.Read) and (RCS.FolderAuthorization or RCS.FolderAuthorization.Read)) 
        /// and (OR.Tasks or OR.Tasks.Read).
        /// Required permissions: Tasks.View.
        /// </summary>
        public async Task<OneOf<ReturnsDtoToRenderAppTask2OKResponse, Stream>> ReturnsDtoToRenderAppTask2(ReturnsDtoToRenderAppTask2Parameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"tasks/AppTasks/GetAppTaskByKey", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<ReturnsDtoToRenderAppTask2OKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"ReturnsDtoToRenderAppTask2: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Required permissions: Tasks.Edit.
        /// </summary>
        public async Task<Stream> ChangesDoneByTheCurrentUserAndReassignTaskToAnotherUser2(ChangesDoneByTheCurrentUserAndReassignTaskToAnotherUser2Request request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"tasks/AppTasks/SaveAndReassignAppTasks", request, headers);
            if (response.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.BadRequest or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"ChangesDoneByTheCurrentUserAndReassignTaskToAnotherUser2: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Required permissions: Tasks.Edit.
        /// </summary>
        public async Task<Stream> SaveTaskData2(SaveTaskData2Request request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"tasks/AppTasks/SaveAppTasksData", request, headers);
            if (response.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.BadRequest or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"SaveTaskData2: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Required permissions: Tasks.Edit.
        /// </summary>
        public async Task<Stream> CompleteTheTaskBySavingTaskDataAndActionTaken(CompleteTheTaskBySavingTaskDataAndActionTakenRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"tasks/GenericTasks/CompleteTask", request, headers);
            if (response.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.BadRequest or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"CompleteTheTaskBySavingTaskDataAndActionTaken: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Required permissions: Tasks.Create.
        /// </summary>
        public async Task<CreatesANewGenericTaskResponse> CreatesANewGenericTask(CreatesANewGenericTaskRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            return await _httpClient.PostNewtonsoftJsonAsync<CreatesANewGenericTaskResponse>($"tasks/GenericTasks/CreateTask", request, headers);
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Required permissions: Tasks.View.
        /// </summary>
        public async Task<OneOf<ReturnsTaskDataDto2OKResponse, Stream>> ReturnsTaskDataDto2(ReturnsTaskDataDto2Parameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"tasks/GenericTasks/GetTaskDataById", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<ReturnsTaskDataDto2OKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"ReturnsTaskDataDto2: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Read.
        /// Required permissions: Tasks.View.
        /// </summary>
        public async Task<OneOf<ReturnsTaskDataDto3OKResponse, Stream>> ReturnsTaskDataDto3(ReturnsTaskDataDto3Parameters queryParameters)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var parametersDict = queryParameters.ToDictionary();
            var queryString = QueryHelpers.AddQueryString($"tasks/GenericTasks/GetTaskDataByKey", parametersDict);
            var response = await _httpClient.GetAsync(queryString, headers);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.ReadNewtonsoftJsonAsync<ReturnsTaskDataDto3OKResponse>();
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"ReturnsTaskDataDto3: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Required permissions: Tasks.Edit.
        /// </summary>
        public async Task<Stream> ChangesDoneByTheCurrentUserAndReassignTaskToAnotherUser3(ChangesDoneByTheCurrentUserAndReassignTaskToAnotherUser3Request request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PostAsNewtonsoftJsonAsync($"tasks/GenericTasks/SaveAndReassignTask", request, headers);
            if (response.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.BadRequest or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"ChangesDoneByTheCurrentUserAndReassignTaskToAnotherUser3: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Required permissions: Tasks.Edit.
        /// </summary>
        public async Task<Stream> SaveTaskData3(SaveTaskData3Request request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"tasks/GenericTasks/SaveTaskData", request, headers);
            if (response.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.BadRequest or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"SaveTaskData3: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    
        /// <summary>
        /// OAuth required scopes: OR.Tasks or OR.Tasks.Write.
        /// Required permissions: Tasks.Edit.
        /// </summary>
        public async Task<Stream> SaveTagsForATask(SaveTagsForATaskRequest request)
        {
            var headers = new Dictionary<string, string>()
            {
                { $"X-UIPATH-OrganizationUnitId", $"<long>" }
            };
    
            var response = await _httpClient.PutAsNewtonsoftJsonAsync($"tasks/GenericTasks/SaveTaskTags", request, headers);
            if (response.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.BadRequest or HttpStatusCode.NotFound)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            throw new Exception($"SaveTagsForATask: Unexpected response. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
        }
    }
}