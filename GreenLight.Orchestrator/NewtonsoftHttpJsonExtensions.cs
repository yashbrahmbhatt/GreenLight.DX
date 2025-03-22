using System.Net;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UiPathWebApi190
{
    /// <summary>
    /// Extension methods for working with JSON APIs.
    /// </summary>
    public static class NewtonsoftHttpClientJsonExtensions
    {
        private static readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings();
    
        /// <summary>
        /// Sends a GET request to the specified URI, and parses the JSON response body
        /// to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public static Task<T> GetNewtonsoftJsonAsync<T>(this HttpClient httpClient, string requestUri, object content,
            Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default,
            JsonSerializerSettings serializerSettings = null)
            => httpClient.SendNewtonsoftJsonAsync<T>(HttpMethod.Get, requestUri, content, headers, cancellationToken,
                serializerSettings);
    
    
        /// <summary>
        /// Sends a POST request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public static Task<T> PatchNewtonsoftJsonAsync<T>(this HttpClient httpClient, string requestUri, object content,
            Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default,
            JsonSerializerSettings serializerSettings = null)
            => httpClient.SendNewtonsoftJsonAsync<T>(HttpMethod.Patch, requestUri, content, headers, cancellationToken,
                serializerSettings);
    
        /// <summary>
        /// Sends a POST request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public static Task<T> DeleteNewtonsoftJsonAsync<T>(this HttpClient httpClient, string requestUri,
            object content, Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default,
            JsonSerializerSettings serializerSettings = null)
            => httpClient.SendNewtonsoftJsonAsync<T>(HttpMethod.Delete, requestUri, content, headers, cancellationToken,
                serializerSettings);
    
        /// <summary>
        /// Sends a POST request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public static Task<T> PostNewtonsoftJsonAsync<T>(this HttpClient httpClient, string requestUri, object content,
            Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default,
            JsonSerializerSettings serializerSettings = null)
            => httpClient.SendNewtonsoftJsonAsync<T>(HttpMethod.Post, requestUri, content, headers, cancellationToken,
                serializerSettings);
    
        /// <summary>
        /// Sends a PUT request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public static Task<T> PutNewtonsoftJsonAsync<T>(this HttpClient httpClient, string requestUri, object content,
            Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default,
            JsonSerializerSettings serializerSettings = null)
            => httpClient.SendNewtonsoftJsonAsync<T>(HttpMethod.Put, requestUri, content, headers, cancellationToken,
                serializerSettings);
    
        public static Task<T> HeadNewtonsoftJsonAsync<T>(this HttpClient httpClient, string requestUri, object content,
            Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default,
            JsonSerializerSettings serializerSettings = null)
            => httpClient.SendNewtonsoftJsonAsync<T>(HttpMethod.Head, requestUri, content, headers, cancellationToken,
                serializerSettings);
    
        public static Task<T> OptionsNewtonsoftJsonAsync<T>(this HttpClient httpClient, string requestUri, object content,
            Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default,
            JsonSerializerSettings serializerSettings = null)
            => httpClient.SendNewtonsoftJsonAsync<T>(HttpMethod.Options, requestUri, content, headers, cancellationToken,
                serializerSettings);
    
        /// <summary>
        /// Sends an HTTP request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="method">The HTTP method.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public static async Task<T> SendNewtonsoftJsonAsync<T>(this HttpClient httpClient, HttpMethod method,
            string requestUri, object content, Dictionary<string, string>? headers, CancellationToken cancellationToken,
            JsonSerializerSettings serializerSettings)
        {
            var requestJson = JsonConvert.SerializeObject(content, serializerSettings ?? _jsonSerializerSettings);
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
            };
            AddHeadersToRequest(request, headers);
            var response = await httpClient.SendAsync(request, cancellationToken);
    
            if (typeof(T) == typeof(IgnoreResponse))
            {
                return default!;
            }
            else
            {
                return await response.ReadNewtonsoftJsonAsync<T>(serializerSettings, cancellationToken: cancellationToken);
            }
        }
    
    
        public static Task<HttpResponseMessage> GetAsNewtonsoftJsonAsync(this HttpClient httpClient, string requestUri,
            object content, Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default,
            JsonSerializerSettings serializerSettings = null)
            => httpClient.SendAsNewtonsoftJsonAsync(HttpMethod.Get, requestUri, content, headers, cancellationToken,
                serializerSettings);
    
        public static Task<HttpResponseMessage> DeleteAsNewtonsoftJsonAsync(this HttpClient httpClient,
            string requestUri,
            object content, Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default,
            JsonSerializerSettings serializerSettings = null)
            => httpClient.SendAsNewtonsoftJsonAsync(HttpMethod.Delete, requestUri, content, headers, cancellationToken,
                serializerSettings);
    
        public static Task<HttpResponseMessage> PostAsNewtonsoftJsonAsync(this HttpClient httpClient, string requestUri,
            object content, Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default,
            JsonSerializerSettings serializerSettings = null)
            => httpClient.SendAsNewtonsoftJsonAsync(HttpMethod.Post, requestUri, content, headers, cancellationToken,
                serializerSettings);
    
        public static Task<HttpResponseMessage> PutAsNewtonsoftJsonAsync(this HttpClient httpClient, string requestUri,
            object content, Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default,
            JsonSerializerSettings serializerSettings = null)
            => httpClient.SendAsNewtonsoftJsonAsync(HttpMethod.Put, requestUri, content, headers, cancellationToken,
                serializerSettings);
    
        public static Task<HttpResponseMessage> PatchAsNewtonsoftJsonAsync(this HttpClient httpClient,
            string requestUri,
            object content, Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default,
            JsonSerializerSettings serializerSettings = null)
            => httpClient.SendAsNewtonsoftJsonAsync(HttpMethod.Patch, requestUri, content, headers, cancellationToken,
                serializerSettings);
    
        public static Task<HttpResponseMessage> HeadAsNewtonsoftJsonAsync(this HttpClient httpClient,
            string requestUri,
            object content, Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default,
            JsonSerializerSettings serializerSettings = null)
            => httpClient.SendAsNewtonsoftJsonAsync(HttpMethod.Head, requestUri, content, headers, cancellationToken,
                serializerSettings);
    
        public static Task<HttpResponseMessage> OptionsAsNewtonsoftJsonAsync(this HttpClient httpClient,
            string requestUri,
            object content, Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default,
            JsonSerializerSettings serializerSettings = null)
            => httpClient.SendAsNewtonsoftJsonAsync(HttpMethod.Options, requestUri, content, headers, cancellationToken,
                serializerSettings);
    
        private static async Task<HttpResponseMessage> SendAsNewtonsoftJsonAsync(this HttpClient httpClient,
            HttpMethod method, string requestUri, object content, Dictionary<string, string>? headers,
            CancellationToken cancellationToken, JsonSerializerSettings serializerSettings)
        {
            var requestJson = JsonConvert.SerializeObject(content, serializerSettings ?? _jsonSerializerSettings);
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
            };
            AddHeadersToRequest(request, headers);
            var response = await httpClient.SendAsync(request, cancellationToken);
    
            return response;
        }
    
    
        public static Task<T> GetFromNewtonsoftJsonAsync<T>(this HttpClient httpClient, string requestUri,
            HttpContent httpContent, Dictionary<string, string>? headers = null,
            CancellationToken cancellationToken = default, JsonSerializerSettings serializerSettings = null)
            => httpClient.SendFromNewtonsoftJsonAsync<T>(HttpMethod.Get, requestUri, httpContent, headers,
                cancellationToken, serializerSettings);
    
        public static Task<T> DeleteFromNewtonsoftJsonAsync<T>(this HttpClient httpClient, string requestUri,
            HttpContent httpContent, Dictionary<string, string>? headers = null,
            CancellationToken cancellationToken = default, JsonSerializerSettings serializerSettings = null)
            => httpClient.SendFromNewtonsoftJsonAsync<T>(HttpMethod.Delete, requestUri, httpContent, headers,
                cancellationToken, serializerSettings);
    
        public static Task<T> PostFromNewtonsoftJsonAsync<T>(this HttpClient httpClient, string requestUri,
            HttpContent httpContent, Dictionary<string, string>? headers = null,
            CancellationToken cancellationToken = default, JsonSerializerSettings serializerSettings = null)
            => httpClient.SendFromNewtonsoftJsonAsync<T>(HttpMethod.Post, requestUri, httpContent, headers,
                cancellationToken, serializerSettings);
    
        public static Task<T> PutFromNewtonsoftJsonAsync<T>(this HttpClient httpClient, string requestUri,
            HttpContent httpContent, Dictionary<string, string>? headers = null,
            CancellationToken cancellationToken = default, JsonSerializerSettings serializerSettings = null)
            => httpClient.SendFromNewtonsoftJsonAsync<T>(HttpMethod.Put, requestUri, httpContent, headers,
                cancellationToken, serializerSettings);
    
        public static Task<T> PatchFromNewtonsoftJsonAsync<T>(this HttpClient httpClient, string requestUri,
            HttpContent httpContent, Dictionary<string, string>? headers = null,
            CancellationToken cancellationToken = default, JsonSerializerSettings serializerSettings = null)
            => httpClient.SendFromNewtonsoftJsonAsync<T>(HttpMethod.Patch, requestUri, httpContent, headers,
                cancellationToken, serializerSettings);
    
        public static Task<T> HeadFromNewtonsoftJsonAsync<T>(this HttpClient httpClient, string requestUri,
            HttpContent httpContent, Dictionary<string, string>? headers = null,
            CancellationToken cancellationToken = default, JsonSerializerSettings serializerSettings = null)
            => httpClient.SendFromNewtonsoftJsonAsync<T>(HttpMethod.Head, requestUri, httpContent, headers,
                cancellationToken, serializerSettings);
    
        public static Task<T> OptionsFromNewtonsoftJsonAsync<T>(this HttpClient httpClient, string requestUri,
            HttpContent httpContent, Dictionary<string, string>? headers = null,
            CancellationToken cancellationToken = default, JsonSerializerSettings serializerSettings = null)
            => httpClient.SendFromNewtonsoftJsonAsync<T>(HttpMethod.Options, requestUri, httpContent, headers,
                cancellationToken, serializerSettings);
    
        private static async Task<T> SendFromNewtonsoftJsonAsync<T>(this HttpClient httpClient, HttpMethod method,
            string requestUri, HttpContent content, Dictionary<string, string>? headers,
            CancellationToken cancellationToken, JsonSerializerSettings serializerSettings)
        {
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = content
            };
            AddHeadersToRequest(request, headers);
            var response = await httpClient.SendAsync(request, cancellationToken);
    
            return await response.ReadNewtonsoftJsonAsync<T>(serializerSettings, cancellationToken: cancellationToken);
        }
    
    
        public static Task<T> GetFromNewtonsoftJsonAsync<T>(this HttpClient httpClient, string requestUri,
            Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default,
            JsonSerializerSettings serializerSettings = null)
            => httpClient.SendFromNewtonsoftJsonAsync<T>(HttpMethod.Get, requestUri, headers, cancellationToken,
                serializerSettings);
    
        public static Task<T> DeleteFromNewtonsoftJsonAsync<T>(this HttpClient httpClient, string requestUri,
            Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default,
            JsonSerializerSettings serializerSettings = null)
            => httpClient.SendFromNewtonsoftJsonAsync<T>(HttpMethod.Delete, requestUri, headers, cancellationToken,
                serializerSettings);
    
        public static Task<T> PostFromNewtonsoftJsonAsync<T>(this HttpClient httpClient, string requestUri,
            Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default,
            JsonSerializerSettings serializerSettings = null)
            => httpClient.SendFromNewtonsoftJsonAsync<T>(HttpMethod.Post, requestUri, headers, cancellationToken,
                serializerSettings);
    
        public static Task<T> PutFromNewtonsoftJsonAsync<T>(this HttpClient httpClient, string requestUri,
            Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default,
            JsonSerializerSettings serializerSettings = null)
            => httpClient.SendFromNewtonsoftJsonAsync<T>(HttpMethod.Put, requestUri, headers, cancellationToken,
                serializerSettings);
    
        public static Task<T> PatchFromNewtonsoftJsonAsync<T>(this HttpClient httpClient, string requestUri,
            Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default,
            JsonSerializerSettings serializerSettings = null)
            => httpClient.SendFromNewtonsoftJsonAsync<T>(HttpMethod.Patch, requestUri, headers, cancellationToken,
                serializerSettings);
    
        public static Task<T> HeadFromNewtonsoftJsonAsync<T>(this HttpClient httpClient, string requestUri,
            Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default,
            JsonSerializerSettings serializerSettings = null)
            => httpClient.SendFromNewtonsoftJsonAsync<T>(HttpMethod.Head, requestUri, headers, cancellationToken,
                serializerSettings);
    
        public static Task<T> OptionsFromNewtonsoftJsonAsync<T>(this HttpClient httpClient, string requestUri,
            Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default,
            JsonSerializerSettings serializerSettings = null)
            => httpClient.SendFromNewtonsoftJsonAsync<T>(HttpMethod.Options, requestUri, headers, cancellationToken,
                serializerSettings);
    
        private static async Task<T> SendFromNewtonsoftJsonAsync<T>(this HttpClient httpClient, HttpMethod method,
            string requestUri, Dictionary<string, string>? headers, CancellationToken cancellationToken,
            JsonSerializerSettings serializerSettings)
        {
            var request = new HttpRequestMessage(method, requestUri);
            AddHeadersToRequest(request, headers);
            var response = await httpClient.SendAsync(request, cancellationToken);
    
            return await response.ReadNewtonsoftJsonAsync<T>(serializerSettings, cancellationToken: cancellationToken);
        }
    
    
        public static Task<HttpResponseMessage> GetAsync(this HttpClient httpClient, string requestUri,
            HttpContent httpContent, Dictionary<string, string>? headers = null,
            CancellationToken cancellationToken = default)
            => httpClient.SendAsync(HttpMethod.Get, requestUri, httpContent, headers, cancellationToken);
    
        public static Task<HttpResponseMessage> PostAsync(this HttpClient httpClient, string requestUri,
            HttpContent httpContent, Dictionary<string, string>? headers = null,
            CancellationToken cancellationToken = default)
            => httpClient.SendAsync(HttpMethod.Post, requestUri, httpContent, headers, cancellationToken);
    
        public static Task<HttpResponseMessage> PutAsync(this HttpClient httpClient, string requestUri,
            HttpContent httpContent, Dictionary<string, string>? headers = null,
            CancellationToken cancellationToken = default)
            => httpClient.SendAsync(HttpMethod.Put, requestUri, httpContent, headers, cancellationToken);
    
        public static Task<HttpResponseMessage> PatchAsync(this HttpClient httpClient, string requestUri,
            HttpContent httpContent, Dictionary<string, string>? headers = null,
            CancellationToken cancellationToken = default)
            => httpClient.SendAsync(HttpMethod.Patch, requestUri, httpContent, headers, cancellationToken);
    
        public static Task<HttpResponseMessage> DeleteAsync(this HttpClient httpClient, string requestUri,
            HttpContent httpContent, Dictionary<string, string>? headers = null,
            CancellationToken cancellationToken = default)
            => httpClient.SendAsync(HttpMethod.Delete, requestUri, httpContent, headers, cancellationToken);
    
        public static Task<HttpResponseMessage> HeadAsync(this HttpClient httpClient, string requestUri,
            HttpContent httpContent, Dictionary<string, string>? headers = null,
            CancellationToken cancellationToken = default)
            => httpClient.SendAsync(HttpMethod.Head, requestUri, httpContent, headers, cancellationToken);
    
        public static Task<HttpResponseMessage> OptionsAsync(this HttpClient httpClient, string requestUri,
            HttpContent httpContent, Dictionary<string, string>? headers = null,
            CancellationToken cancellationToken = default)
            => httpClient.SendAsync(HttpMethod.Options, requestUri, httpContent, headers, cancellationToken);
    
        private static async Task<HttpResponseMessage> SendAsync(this HttpClient httpClient, HttpMethod method,
            string requestUri, HttpContent httpContent, Dictionary<string, string>? headers,
            CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = httpContent
            };
            AddHeadersToRequest(request, headers);
            var response = await httpClient.SendAsync(request, cancellationToken);
    
            return response;
        }
    
    
        public static Task<HttpResponseMessage> GetAsync(this HttpClient httpClient, string requestUri,
            Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default)
            => httpClient.SendAsync(HttpMethod.Get, requestUri, headers, cancellationToken);
    
        public static Task<HttpResponseMessage> PostAsync(this HttpClient httpClient, string requestUri,
            Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default)
            => httpClient.SendAsync(HttpMethod.Post, requestUri, headers, cancellationToken);
    
        public static Task<HttpResponseMessage> PutAsync(this HttpClient httpClient, string requestUri,
            Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default)
            => httpClient.SendAsync(HttpMethod.Put, requestUri, headers, cancellationToken);
    
        public static Task<HttpResponseMessage> PatchAsync(this HttpClient httpClient, string requestUri,
            Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default)
            => httpClient.SendAsync(HttpMethod.Patch, requestUri, headers, cancellationToken);
    
        public static Task<HttpResponseMessage> DeleteAsync(this HttpClient httpClient, string requestUri,
            Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default)
            => httpClient.SendAsync(HttpMethod.Delete, requestUri, headers, cancellationToken);
    
        public static Task<HttpResponseMessage> HeadAsync(this HttpClient httpClient, string requestUri,
            Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default)
            => httpClient.SendAsync(HttpMethod.Head, requestUri, headers, cancellationToken);
    
        public static Task<HttpResponseMessage> OptionsAsync(this HttpClient httpClient, string requestUri,
            Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default)
            => httpClient.SendAsync(HttpMethod.Options, requestUri, headers, cancellationToken);
    
        private static async Task<HttpResponseMessage> SendAsync(this HttpClient httpClient, HttpMethod method,
            string requestUri, Dictionary<string, string>? headers, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(method, requestUri);
            AddHeadersToRequest(request, headers);
            var response = await httpClient.SendAsync(request, cancellationToken);
    
            response.EnsureSuccessStatusCode();
            return response;
        }
    
        public static async Task<T> ReadNewtonsoftJsonAsync<T>(this HttpResponseMessage response,
            JsonSerializerSettings? serializerSettings = null, CancellationToken cancellationToken = default)
        {
            var stringContent = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonConvert.DeserializeObject<T>(stringContent, serializerSettings ?? _jsonSerializerSettings)!;
        }
    
        private static void AddHeadersToRequest(HttpRequestMessage request, Dictionary<string, string>? headers)
        {
            if (headers != null)
            {
                foreach (var (key, value) in headers)
                {
                    request.Headers.TryAddWithoutValidation(key, value);
                }
            }
        }
        class IgnoreResponse { }
    }
    public class EmptyRequest { }
    public class EmptyResponse { }
    // modify to suit your needs
    public class UnexpectedStatusCodeResponse
    {
        public HttpStatusCode StatusCode { get; init; }
        public Dictionary<string, string> Headers { get; init; }
        public string? Body { get; init; }
    
        public UnexpectedStatusCodeResponse(HttpResponseMessage response)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));
    
            StatusCode = response.StatusCode;
            Headers = new Dictionary<string, string>();
    
            foreach (var header in response.Headers)
            {
                Headers[header.Key] = string.Join("", "", header.Value);
            }
    
            if (response.Content != null!)
            {
                Body = response.Content.ReadAsStringAsync().Result; // Consider async handling
            }
        }
    }
}