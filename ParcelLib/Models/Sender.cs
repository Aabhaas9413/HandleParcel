using System.Xml.Serialization;

namespace ParcelLib.Models
{
    [XmlType("Sender")]
    [XmlInclude(typeof(Company))]
    public class Sender
    {
        public string Name { get; set; }
        public Address Address { get; set; }
    }
    
}
