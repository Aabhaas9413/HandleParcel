using ParcelLib.Models;
using ParcelLib.ParcelDataAccess;

namespace ParcelLibTest
{
    public class ReteiveShipmentInfoFromXMLTests
    {
        private readonly string shipmentXmlPath = "C:\\Users\\aabha\\Desktop\\Assignment\\Assignment\\ParcelLibTest\\Assets\\Container_Test.xml";
        [Fact]
        public void Get_ShipmentInfo_from_XML()
        {
            //Arrange
            IRetriveShipmentInfoFromXML info = new RetriveShipmentInfoFromXML();
            var expectedCountOfPasrcels = 1;
            var expectedShipmentId = 1111;

            //Act
            var shipment = info.RetriveShipmentIinfo(shipmentXmlPath);

            //Assert
            Assert.IsType<Shipment>(shipment);
            Assert.Equal(shipment.Parcels.Count, expectedCountOfPasrcels);
            Assert.Equal(shipment.Id, expectedShipmentId);
        }

    }
}
