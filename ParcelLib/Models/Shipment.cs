using System.Xml.Serialization;

namespace ParcelLib.Models
{
    [XmlRoot("Container")]
    public class Shipment
    {
        public int Id { get; set; }
        public DateTime ShippingDate { get; set; }
        [XmlArray("parcels")]
        [XmlArrayItem("Parcel")]
        public List<Parcel> Parcels { get; set; }
    }
}
