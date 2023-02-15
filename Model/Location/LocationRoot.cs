namespace Model.Location
{
    public class LocationRoot
    {
        public string IP { get; set; }
        public string HostName { get; set; }
        public string Type { get; set; }
        public string Continent_Code { get; set; }
        public string Continent_Name { get; set; }
        public string Country_Code { get; set; }
        public string Country_Name { get; set; }
        public string Region_Code { get; set; }
        public string Region_Name { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Location Location { get; set; }
    }
}
