using ParcelLib.Models;
using ParcelLib.Services.IServices;
using ParcelLib.Services;

namespace ParcelLibTest
{
    public class DepartmentServiceTests
    {
        private List<Department> departments = new List<Department>();

        
        private DepartmentService InitializeDepatmentService()
        {
            departments.AddRange(
               new List<Department> {
                    new Department("Mail", 1),
                    new Department("Regular", 10),
                    new Department("Heavy", double.MaxValue)
                });
            return new DepartmentService(departments);
        }

        [Fact]        
        public void Get_All_Departments()
        {
            //Arrange            
            IDepartmentService departmentService = InitializeDepatmentService();

            //Act
            var actualDepartments = departmentService.GetDepartments();

            //Assert
            Assert.Equal(departments.Count, actualDepartments.Count);
            Assert.Equal(departments, actualDepartments);
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
