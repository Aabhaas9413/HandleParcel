using ParcelLib.Models;

namespace ParcelLibTest.Builder
{
    public class ParcelBuilder
    {
        private Sender _sender;
        private Receipient _receipient;
        private double _value;
        private double _weight;
        public ParcelBuilder(Sender sender, Receipient receipient)
        {
            _receipient = receipient;
            _sender = sender;
        }

        public ParcelBuilder SetWeight(double weight)
        {
            _weight= weight;
            return this;
        }
        public ParcelBuilder SetValue(double value)
        {
            _value = value;
            return this;
        }

        public Parcel Build()
        {
            return new Parcel() { 
                Receipient = _receipient,
                Weight = _weight,
                Value = _value,
                Sender = _sender
            };
        }
    }
}
