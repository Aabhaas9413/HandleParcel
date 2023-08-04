
namespace ParcelLib.Models
{
    public class Department
    {
        public string Name { get; set; }
        public double WeightThreshold { get; set; }

        public Department(string name, double weightThreshold)
        {
            Name = name;
            WeightThreshold = weightThreshold;
        }
    }

}
