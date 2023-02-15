using Model.Location;

namespace Contracts.BusinessLogic
{
    public interface ILocationLogic
    {
        Task<LocationRoot> GetByIPAddress(string ipAddress);
    }
}
