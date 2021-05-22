using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ARHome.GenericSubDomain.Common;

namespace ARHome.GenericSubDomain.HttpClient
{
    public static class HttpContentSerializer
    {
        public static HttpContent ToHttpContent<T>(this T value, IJsonSerializer serializer)
        {
            var httpContent = new StringContent(
                serializer.Serialize(value),
                Encoding.UTF8,
                "application/json");

            return httpContent;
        }

        public static async Task<T> DeserializeAsync<T>(
            this HttpContent httpContent,
            IJsonSerializer serializer)
        {
            var stringValue = await httpContent
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            var value = serializer.Deserialize<T>(stringValue);
            return value;
        }
    }
}