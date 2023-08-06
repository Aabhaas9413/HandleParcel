using ParcelLib.Models;
using ParcelLib.Services;
using ParcelLib.Services.IServices;

namespace ParcelLibTest
{
    public class HandleParcelTests
    {
        [Theory]
        [InlineData("Mail", 10, 0.5, false)]
        [InlineData("Regular", 200, 2, false)]
        [InlineData("Heavy", 500, 30, false)]
        [InlineData("Heavy", 2000, 30, true)]
        public void Handle_Parcel_By_Departments(string expectedDepartment, double parcelValue, double parcelWeight, bool isInsuranceReq)
        {
            //Arrange
            IDepartmentService department = instantiateDepartmentService();
            IHandleParcelService parcelService = new HandleParcelService(department);
            Parcel parcel = new Parcel() { Receipient = It.IsAny<Receipient>(), Sender = It.IsAny<Sender>(), Value = parcelValue, Weight = parcelWeight };
            string expectedDepartmentName = expectedDepartment;

            //Act
            var actualDepartmentInfo = parcelService.ParcelHandler(parcel);

            //Arrange
            Assert.Equal(expectedDepartmentName, actualDepartmentInfo.Item1);
            Assert.Equal(isInsuranceReq, actualDepartmentInfo.Item2);
        }
        private static IDepartmentService instantiateDepartmentService()
        {
            List<Department> departments = new List<Department>
                {
                    new Department("Mail", 1),
                    new Department("Regular", 10),
                    new Department("Heavy", double.MaxValue)
                };
            IDepartmentService department = new DepartmentService(departments);
            return department;
        }
    }
}