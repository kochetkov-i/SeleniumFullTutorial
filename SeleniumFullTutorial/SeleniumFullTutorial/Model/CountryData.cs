namespace SeleniumFullTutorial.Model
{
    public class CountryData
    {
        public CountryData(string name, string link, int zones)
        {
            this.Name = name;
            this.Link = link;
            this.Zones = zones;
        }

        public string Name { get; set; }
        public string Link { get; set; }
        public int Zones { get; set; }
    }
}