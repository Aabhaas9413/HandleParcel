using ParcelLib.Models;

namespace ParcelLib.Services.IServices
{
    public interface IHandleParcelService
    {
        Tuple<string, bool> ParcelHandler(Parcel parcel);
    }
}