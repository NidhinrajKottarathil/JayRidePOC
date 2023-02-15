using Model.Listing;

namespace Contracts.BusinessLogic
{
    public interface IListingLogic
    {
        Task<List<Listing>> GetListingByNumerOfPassengers(int numberOfPassengers);
    }
}
