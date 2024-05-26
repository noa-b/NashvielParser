using System;
using System.Text.Json;

namespace Nashviel {
    class Utils {
        public static CONSTS myConsts = new CONSTS();

        public static void setID(int i, Address[] addresses) {
            while (i < addresses.Length) {
                addresses[i].id = Convert.ToString(i);
                i++;
            }
        } 

        public static void metadataFileGenerator(string jsonFileName, int numOFAddresses) {
            var metadata = new OutputMetaFile
            {
                name = jsonFileName,
                alias = jsonFileName,
                coordinateCount = Convert.ToString(numOFAddresses),
                geometryType = "Xkdjndfd",
                fieldIds = new string[] {jsonFileName, jsonFileName}
            };
            using FileStream createStream = File.Create($"{myConsts.CURR_BASE_PATH}\\{myConsts.CURR_FOLDER_NAME}\\{myConsts.OUTPUT_DIRECTORY_NAME}\\{jsonFileName}{myConsts.METADATA_OUTPUT_EXTENTION}");
            JsonSerializer.SerializeAsync(createStream, metadata);
        } 

        public static void jsonfileGenerator(Example currFileContent) {
            Directory.CreateDirectory(Path.Combine(myConsts.CURR_FOLDER_NAME, myConsts.OUTPUT_DIRECTORY_NAME));            

            Guid guid = Guid.NewGuid();
            string outputFileName = $"{guid}";

            using FileStream createStream = File.Create($"{myConsts.CURR_BASE_PATH}\\{myConsts.CURR_FOLDER_NAME}\\{myConsts.OUTPUT_DIRECTORY_NAME}\\{outputFileName}{myConsts.JSON_OUTPUT_EXTENTION}");
            JsonSerializer.SerializeAsync(createStream, currFileContent);
            metadataFileGenerator(outputFileName, currFileContent.addresses.Length);
        } 
    }  
}