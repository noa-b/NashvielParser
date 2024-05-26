namespace Nashviel{
    class InputJsonFile {
        public string type { get; set; }
        public CRS crs { get; set; }
        public Feature[] features { get; set; }
    }
}