using Mango.Web.Models;
using Mango.Web.Service.IService;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static Mango.Web.Models.Utilities.StaticData;

namespace Mango.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _clientFactory; // this is the client that will be used to make the request

        public BaseService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<CommonResponseDto> SendAsync(RequestDto requestDto)
        {
            HttpClient client = _clientFactory.CreateClient("AlbiApi"); // this is the client that will be used to make the request
            HttpRequestMessage request = new HttpRequestMessage(); // Create a new HttpRequestMessage
            request.Headers.Add("Accept", "application/json"); // this is used to specify the type of response that we want to get from the request     
            request.RequestUri = new Uri(requestDto.Url); // this is used to create a new request message

            // Add more code here to handle the request and response
            if(requestDto.Data != null)
            {
                request.Content = new StringContent(
                    JsonSerializer.Serialize(requestDto.Data),
                    Encoding.UTF8,
                    "application/json"
                ); // this is used to serialize the data that we want to send to the server meaning that we are converting the data to json format
            }

            HttpResponseMessage? response = null; // this is used to store the response that we get from the server

            // now we will be using a switch statement instead of if else
            switch (requestDto.ApiType)
            {
                case ApiType.POST:
                    request.Method = HttpMethod.Post;
                    break;
                case ApiType.PUT:
                    request.Method = HttpMethod.Put;
                    break;
                case ApiType.DELETE:
                    request.Method = HttpMethod.Delete;
                    break;
                default:
                    request.Method = HttpMethod.Get;
                    break;

            }

            response = await client.SendAsync(request); // this is used to send the request to the server and store the response in the response variable

            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new CommonResponseDto { ErrorMessage = "Not Found", IsSuccess = false };
                    
                case HttpStatusCode.Forbidden:
                    return new CommonResponseDto { ErrorMessage = "Forbidden", IsSuccess = false };
                    
                case HttpStatusCode.Unauthorized:
                    return new CommonResponseDto { ErrorMessage = "UnAuthorized", IsSuccess = false };
                    
                case HttpStatusCode.InternalServerError:
                    return new CommonResponseDto { ErrorMessage = "Server Error", IsSuccess = false };
                    
                default:
                    var content = await response.Content.ReadAsStringAsync(); // this is used to read the content of the response when we get a response from the server
                    var apiResponseDto = JsonSerializer.Deserialize<CommonResponseDto>(content); // this is used to deserialize the content that we get from the server
                    return apiResponseDto; // this is used to return the response that we get from the server to the client
            }
        }
    }
}
