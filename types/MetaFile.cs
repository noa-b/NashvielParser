namespace Nashviel{
    class MetaData {
        public OutputMetaFile metadata;
    }

    class OutputMetaFile {
            public string name { get; set; }
            public string alias { get; set; }
            public string coordinateCount { get; set; }
            public string geometryType { get; set; }
            public string[] fieldIds { get; set; }
    }
}