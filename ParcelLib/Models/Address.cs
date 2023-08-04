using System.Xml.Serialization;

namespace ParcelLib.Models
{
    [XmlType("Address")]
    public class Address
    {
        public string Street { get; set; }           
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}
