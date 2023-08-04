using ParcelLib.Models;
using ParcelLib.ParcelAccess;
using ParcelLib.ParcelDataAccess;

class Program
{
    public static void Main()
    {
        var shipmentXmlPath = "C:\\Users\\aabha\\Desktop\\Assignment\\Assignment\\Container_68465468.xml";
        RetriveShipmentInfoFromXML info = new RetriveShipmentInfoFromXML();
        Shipment shipment = info.RetriveShipmentIinfo(shipmentXmlPath);
        HandleParcel handleParcle = new HandleParcel();
        Console.WriteLine("Shipment for the day: "+ shipment.ShippingDate + " has " + shipment.Parcels.Count + " parcels:");
        foreach(Parcel parcel in shipment.Parcels)
        {
            List<string> depatmentList = handleParcle.ParcelHandler(parcel);
            depatmentList.ForEach(e => HandleByDepartment(e, parcel));
        }
    }
    private static void HandleByDepartment(string departmentName, Parcel parcel)
    {
        if (departmentName.Equals("Insurance"))
        {
            Console.WriteLine("This item has been signed off from "+ departmentName+ " department.");
        }
        else
        {
            Console.WriteLine("This parcel is from: " + parcel.Sender.Name);
            Console.WriteLine("This parcel is to: " + parcel.Receipient.Name);
            Console.WriteLine("Parcel with weight " + parcel.Weight + " kg and value " + parcel.Value + " euros");
            Console.WriteLine("This parcel is handled by the " + departmentName + " department.");
            Console.WriteLine("#####################################");
        }        
    }
}