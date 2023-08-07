using ParcelLib.Models;
using ParcelLib.Services;
using ParcelLib.Services.IServices;
using ParcelLibTest.Builder;

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
            Parcel parcel = new ParcelBuilder(It.IsAny<Sender>(), It.IsAny<Receipient>())
                                              .SetValue(parcelValue)
                                              .SetWeight(parcelWeight)
                                              .Build();
            string expectedDepartmentName = expectedDepartment;

            //Act
            var actualDepartmentInfo = parcelService.ParcelHandler(parcel.Weight, parcel.Value);

            //Arrange
            Assert.Equal(expectedDepartmentName, actualDepartmentInfo.Item1);
            Assert.Equal(isInsuranceReq, actualDepartmentInfo.Item2);
        }
        private static IDepartmentService instantiateDepartmentService()
        {
            IDepartmentService departmentService = new DepartmentService();
            departmentService.AddDepartment("Mail", 1);
            departmentService.AddDepartment("Regular", 10);
            departmentService.AddDepartment("Heavy", double.MaxValue);
            return departmentService;
        }
    }
}