namespace Model.Listing
{
    public class Listing
    {
        public string name { get; set; }
        public double pricePerPassenger { get; set; }
        public VehicleType vehicleType { get; set; }
        public double TotalPrice
        {
            get { return vehicleType.maxPassengers * pricePerPassenger; }
        }
    }
}
