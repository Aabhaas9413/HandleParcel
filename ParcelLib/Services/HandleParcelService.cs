using ParcelLib.Models;
using ParcelLib.Services.IServices;

namespace ParcelLib.Services
{
    public class HandleParcelService : IHandleParcelService
    {
        private readonly List<Department> _departments;
        private readonly IDepartmentService _departmentService;

        public HandleParcelService(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            _departments = _departmentService.GetDepartments();
        }

        public Tuple<string, bool> ParcelHandler(double weight, double value)
        {
            string departmentName = string.Empty;
            bool isInsured = false;
            if (value > 1000)
            {
                isInsured = true;
            }

            foreach (var department in _departments)
            {
                if (weight <= department.WeightThreshold)
                {
                    departmentName = department.Name;
                    break;
                }
            }  

            return Tuple.Create(departmentName, isInsured);
        }
    }
}