using Microsoft.Extensions.Configuration;
using ParcelLib.Models;
using ParcelLib.ParcelDataAccess;
using ParcelLib.Services;
using ParcelLib.Services.IServices;

class Program
{
    private static readonly string shipmentXmlPath = "C:\\Users\\aabha\\Desktop\\Assignment\\Assignment\\Container_68465468.xml";
    public static void Main()
    {        
        Shipment shipment = GetShipmentInfoFromXML();
        IDepartmentService departmentService = InstantiateDepartmentService();
        IHandleParcelService handleParcleService = new HandleParcelService(departmentService);
        Console.WriteLine("Shipment for the day: " + shipment.ShippingDate + " has " + shipment.Parcels.Count + " parcels:");
        Console.WriteLine("#####################################");
        foreach (Parcel parcel in shipment.Parcels)
        {
            Tuple<string, bool> depatment = handleParcleService.ParcelHandler(parcel);
            HandleByDepartment(depatment.Item1, depatment.Item2, parcel);
        }
    }

    private static Shipment GetShipmentInfoFromXML()
    {
        IConfiguration config = GetConfiguration();
        IRetriveShipmentInfoFromXML shipmentInfo = new RetriveShipmentInfoFromXML();
        Shipment shipment = shipmentInfo.RetriveShipmentIinfo(config["XMLFilePath"]);
        return shipment;
    }

    private static IConfiguration GetConfiguration()
    {
        var builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        IConfiguration config = builder.Build();
        return config;
    }

    private static IDepartmentService InstantiateDepartmentService()
    {
        List<Department> departments = new List<Department>
                {
                    new Department("Mail", 1),
                    new Department("Regular", 10),
                    new Department("Heavy", double.MaxValue)
                };
        IDepartmentService departmentService = new DepartmentService(departments);
        return departmentService;
    }

    private static void HandleByDepartment(string departmentName, bool IsInsured, Parcel parcel)
    {
       Console.WriteLine("This parcel is from: " + parcel.Sender.Name);
       Console.WriteLine("This parcel is to: " + parcel.Receipient.Name);
       Console.WriteLine("Parcel with weight " + parcel.Weight + " kg and value " + parcel.Value + " euros");
       if (IsInsured) Console.WriteLine("This item has been signed off from Insurance department.");       
       Console.WriteLine(string.IsNullOrEmpty(departmentName) ?
           "Please check the range of the departments.":
           "This parcel is handled by the " + departmentName + " department.");
       Console.WriteLine("#####################################");               
    }
}