using ParcelLib.Models;
using ParcelLib.Services.IServices;
using ParcelLib.Services;

namespace ParcelLibTest
{
    public class DepartmentServiceTests
    {
        private IDepartmentService InitializeDepatmentService()
        {
            IDepartmentService departmentService = new DepartmentService();
            departmentService.AddDepartment("Mail", 1);
            departmentService.AddDepartment("Regular", 10);
            departmentService.AddDepartment("Heavy", double.MaxValue);
            return departmentService;
        }

        [Fact]        
        public void Get_All_Departments()
        {
            //Arrange            
            IDepartmentService departmentService = InitializeDepatmentService();
            var totalDepartments = 3;

            //Act
            var actualDepartments = departmentService.GetDepartments();

            //Assert
            Assert.Equal(totalDepartments, actualDepartments.Count);
        }

        [Fact]
        public void Add_A_Department_In_Department_List()
        {
            //Arrange
            IDepartmentService departmentService = InitializeDepatmentService();
            Department expectedDepartment = new Department("MidTest", 15);
            int expectedDepartmentCount = 4;

            //Act
            var actualDepartments = departmentService.AddDepartment("MidTest", 15);

            //Assert
            Assert.Equal(expectedDepartmentCount, actualDepartments.Count);
            Assert.Equal(expectedDepartment.Name, actualDepartments.First(x=>x.WeightThreshold ==15).Name);
        }

        [Fact]
        public void Remove_A_Department_In_Department_List()
        {
            //Arrange
            IDepartmentService departmentService = InitializeDepatmentService();
            int expectedDepartmentCount = 2;

            //Act
            var actualDepartments = departmentService.RemoveDepartment("Heavy");

            //Assert
            Assert.Equal(expectedDepartmentCount, actualDepartments.Count);
        }
    }
}
