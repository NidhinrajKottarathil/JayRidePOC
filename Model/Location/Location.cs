namespace Model.Location
{
    public class Location
    {
        public string Geoname_id { get; set; }
        public string Capital { get; set; }
        public List<Language> Languages { get; set; }
        public string Country_flag { get; set; }
        public string Country_flag_emoji { get; set; }
        public string Country_flag_emoji_unicode { get; set; }
        public string Calling_code { get; set; }
        public bool Is_eu { get; set; }
    }
}
