using System;
using System.Text.Json;

namespace Nashviel {
    class Program
    {
        public static CONSTS myConsts = new CONSTS();

        public static void Main()
        {
            string inputFilePath = $"{myConsts.CURR_FOLDER_NAME}\\{myConsts.CURR_INPUT_FILE_NAME}";
            using FileStream openStream = File.OpenRead(inputFilePath);
            Example? currExample = 
                JsonSerializer.Deserialize<Example>(openStream);           
            Utils.setID(0, currExample.addresses);
            Utils.jsonfileGenerator(currExample);
        }
    }
}