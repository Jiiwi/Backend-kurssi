namespace Tehtava1
{
    public class BikeRentalStationList
    {
        public BikeRentalStation[] stations;

        public class BikeRentalStation{

            public int id;
            public string name;
            public double x;
            public double y;
            public int bikesAvailable;
            public int spacesAvailable;
            public bool allowDropoff;
            public bool isFloatingBike;
            public string state;
            public string[] networks;
            public bool realTimeData;
        }
    }
}