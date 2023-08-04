using System.Xml.Serialization;

namespace ParcelLib.Models
{
    [XmlType("Parcel")]
    public class Parcel
    {
        public Sender Sender { get; set; }
        public Receipient Receipient { get; set; }
        public double Weight { get; set; }
        public double Value { get; set; }
    }
}
