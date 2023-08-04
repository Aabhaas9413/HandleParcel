using ParcelLib.Models;

namespace ParcelLib.ParcelAccess
{
    public class HandleParcel
    {
        private List<Department> departments;

        public HandleParcel()
        {
            departments = new List<Department>
        {
            new Department("Mail", 1),
            new Department("Regular", 10),
            new Department("Heavy", double.MaxValue) // Maximum weight threshold
        };
        }

        public void AddDepartment(string name, double weightThreshold)
        {
            departments.Add(new Department(name, weightThreshold));
        }

        public void RemoveDepartment(string name)
        {
            departments.RemoveAll(d => d.Name.Equals(name));
        }
        public List<string> ParcelHandler(Parcel parcel)
        {
            List<string> departmentNames = new List<string>();
            if (parcel.Value > 1000)
            {
                departmentNames.Add("Insurance");
            }

            foreach (var department in departments)
            {
                if (parcel.Weight <= department.WeightThreshold)
                {
                    departmentNames.Add(department.Name);
                    break;
                }
            }

            return departmentNames;
        }
    }
}