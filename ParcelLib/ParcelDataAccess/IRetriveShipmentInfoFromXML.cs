using ParcelLib.Models;

namespace ParcelLib.ParcelDataAccess
{
    public interface IRetriveShipmentInfoFromXML
    {
        Shipment RetriveShipmentIinfo(string path);
    }
}