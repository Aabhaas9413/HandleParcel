using ParcelLib.Models;
using ParcelLib.ParcelDataAccess;
using ParcelLib.Services.IServices;

namespace ShipmentInfoAPI
{
    public static class ShipmentAPI
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/DepartmentUsed/{weight}/{value}", GetDepartmentUsedInfo);
            app.MapGet("/ShipmentInfoFromXML/{path}", GetShipmentInfoFromXML);
            app.MapPost("/Department", InsertDepartment);
            app.MapDelete("/Department", RemoveDepartment);
        }

        public static async Task<IResult> GetDepartmentUsedInfo(double weight, double value, IHandleParcelService parcelService)
        {
            try
            {
                var results = parcelService.ParcelHandler(weight, value);
                if (results == null) { return Results.NotFound(); }
                ParcelInfoDto parcelInfoDto = new() { 
                    DepartmentName = results.Item1, 
                    IsInsured = results.Item2
                };                
                return Results.Ok(parcelInfoDto);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> GetShipmentInfoFromXML(string path, IRetriveShipmentInfoFromXML infoFromXML)
        {
            try
            {
                var results = infoFromXML.RetriveShipmentIinfo(path);
                if (results == null) { return Results.NotFound(); }
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> InsertDepartment(Department department, IDepartmentService departmentService)
        {
            try
            {
                departmentService.AddDepartment(department.Name, department.WeightThreshold);
                return Results.Ok();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> RemoveDepartment(string departmentName, IDepartmentService departmentService)
        {
            try
            {
                departmentService.RemoveDepartment(departmentName);
                return Results.Ok();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
