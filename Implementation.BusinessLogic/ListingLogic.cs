using Contracts.BusinessLogic;
using Implementation.BusinessLogic.Base;
using Model.Listing;
using Newtonsoft.Json;

namespace Implementation.BusinessLogic
{
    public class ListingLogic : BaseLogic, IListingLogic
    {
        private const string QUOTEREQUEST_URL = "https://jayridechallengeapi.azurewebsites.net/api/QuoteRequest";

        public async Task<List<Listing>> GetListingByNumerOfPassengers(int numberOfPassengers)
        {
            List<Listing> result = new();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var json = await httpClient.GetStringAsync(QUOTEREQUEST_URL);
                    var data = JsonConvert.DeserializeObject<ListingRoot>(json);

                    result = data.listings.FindAll(d => d.vehicleType.maxPassengers >= numberOfPassengers)
                                          .OrderBy(o => o.TotalPrice).ToList();
                }
            }
            catch (Exception ex)
            {
                // Exception log - ex.Message
            }
            return result;
        }
    }
}
