using System;
using System.Text.Json;

namespace Nashviel {
    class UnitTests {
        public static CONSTS myConsts = new CONSTS();

        public static async void given_example_generateIDs() {
            //Arrange
            string inputFilePath = $"{myConsts.CURR_FOLDER_NAME}\\{myConsts.CURR_INPUT_FILE_NAME}";
            using FileStream openStream = File.OpenRead(inputFilePath);
            Example? inputFile = 
                await JsonSerializer.DeserializeAsync<Example>(openStream);  

            //Act
            Utils.setID(0, inputFile.addresses);
            await using FileStream createStream = File.Create($"{myConsts.TEST_RECOURCES}\\wasOutputed\\output.json");
            await JsonSerializer.SerializeAsync(createStream, inputFile);
            
            //Assert
            using FileStream correctOutputOpenStream = File.OpenRead($"{myConsts.TEST_RECOURCES}\\correctOutput\\currectOutPut.json");
            Example? correctOutput = 
                await JsonSerializer.DeserializeAsync<Example>(correctOutputOpenStream); 
            using FileStream wasOutputedOpenStream = File.OpenRead($"{myConsts.TEST_RECOURCES}\\wasOutputed\\output.json");
            Example? wasOutputed = 
                await JsonSerializer.DeserializeAsync<Example>(wasOutputedOpenStream); 

            //Assertions.assertEquals(correctOutput, wasOutputed);
        }
    }
}