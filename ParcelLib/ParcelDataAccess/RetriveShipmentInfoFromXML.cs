using ParcelLib.Models;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ParcelLib.ParcelDataAccess
{
    public class RetriveShipmentInfoFromXML
    {
        public Shipment RetriveShipmentIinfo(string path)
        {
            Shipment shipment = new();
            string xmlContent = File.ReadAllText(path);

            XmlSerializer serializer = new XmlSerializer(typeof(Shipment));

            using (TextReader reader = new StringReader(xmlContent))
            {
                shipment = (Shipment)serializer.Deserialize(reader);
                foreach (Parcel parcel in shipment.Parcels)
                {
                    Console.WriteLine($"Parcel Weight: {parcel.Weight}");
                    Console.WriteLine($"Parcel Value: {parcel.Value}");
                    // Access other properties as needed
                }
            }
            return shipment;
        }
    }
}
