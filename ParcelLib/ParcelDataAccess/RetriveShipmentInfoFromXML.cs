using ParcelLib.Models;
using System.Xml.Serialization;

namespace ParcelLib.ParcelDataAccess
{
    public class RetriveShipmentInfoFromXML : IRetriveShipmentInfoFromXML
    {
        public Shipment RetriveShipmentIinfo(string path)
        {
            Shipment shipment = new();
            string xmlContent = File.ReadAllText(path);

            XmlSerializer serializer = new XmlSerializer(typeof(Shipment));

            using (TextReader reader = new StringReader(xmlContent))
            {
                shipment = (Shipment)serializer.Deserialize(reader);
            }
            return shipment;
        }
    }
}
