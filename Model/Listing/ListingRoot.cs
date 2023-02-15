namespace Model.Listing
{
    public class ListingRoot
    {
        public string from { get; set; }
        public string to { get; set; }
        public List<Listing> listings { get; set; }
    }
}
