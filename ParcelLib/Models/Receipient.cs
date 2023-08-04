using System.Xml.Serialization;

namespace ParcelLib.Models
{
    [XmlType("Receipient")]
    public class Receipient
    {
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}
