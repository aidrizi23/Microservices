using static Mango.Web.Models.Utilities.StaticData;

namespace Mango.Web.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; }
        public string Url { get; set; }
        public object? Data { get; set; }

        public string AccessToken { get; set; } // we will not be using this for now
    }
}
