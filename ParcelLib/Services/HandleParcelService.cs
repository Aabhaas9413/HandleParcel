using ParcelLib.Models;
using ParcelLib.Services.IServices;

namespace ParcelLib.Services
{
    public class HandleParcelService : IHandleParcelService
    {
        private List<Department> departments;
        private readonly IDepartmentService _departmentService;

        public HandleParcelService(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            departments = _departmentService.GetDepartments();
        }


        public Tuple<string, bool> ParcelHandler(Parcel parcel)
        {
            string departmentName = string.Empty;
            bool isInsured = false;
            if (parcel.Value > 1000)
            {
                isInsured = true;
            }

            foreach (var department in departments)
            {
                if (parcel.Weight <= department.WeightThreshold)
                {
                    departmentName = department.Name;
                    break;
                }
            }  

            return Tuple.Create(departmentName, isInsured);
        }
    }
}