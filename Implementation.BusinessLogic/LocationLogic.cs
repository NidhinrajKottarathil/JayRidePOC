using Contracts.BusinessLogic;
using Implementation.BusinessLogic.Base;
using Model.Location;
using Newtonsoft.Json;

namespace Implementation.BusinessLogic
{
    public class LocationLogic : BaseLogic, ILocationLogic
    {
        private string IPSTACK_ACCESS_KEY = "fc3adf0250d581a94f34ba20bcbc72e1";

        private readonly HttpClient _httpClient;

        public LocationLogic()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// GetByIPAddress
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public async Task<LocationRoot> GetByIPAddress(string ipAddress)
        {
            LocationRoot result = new();
            try
            {
                var url = $"http://api.ipstack.com/{ipAddress}?access_key={IPSTACK_ACCESS_KEY}";
                var json = await _httpClient.GetStringAsync(url);
                result = JsonConvert.DeserializeObject<LocationRoot>(json);
            }
            catch (Exception ex)
            {
                //logg error
            }

            return result;
        }
    }
}
