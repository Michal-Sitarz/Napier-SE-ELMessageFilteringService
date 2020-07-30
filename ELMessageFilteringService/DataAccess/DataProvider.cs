using ELMessageFilteringService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Text.Json;

namespace ELMessageFilteringService.DataAccess
{
    public class DataProvider : IDataProvider
    {
        private readonly string allMessagesJSONFilePath = @"C:\ELMfiles\AllMessages.json";
        private readonly string messagesToImportXMLFilePath = @"C:\ELMfiles\MessagesToImport.xml";
        private readonly string abbreviationsListCSVFilePath = @"C:\ELMfiles\AbbreviationsList.csv";

        public bool ExportMessage(Message message)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            try
            {
                var messageInJson = JsonSerializer.Serialize(message, jsonOptions);
                File.AppendAllText(allMessagesJSONFilePath, messageInJson + "\n");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured during exporting of a new message to the JSON file.\n", ex.ToString());
                return false;
            }
        }

        public IList<MessageDTO> ImportMessages()
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, string> ImportAbbreviations()
        {
            var abbreviations = new Dictionary<string, string>();
            try
            {
                var fileContent = File.ReadAllLines(abbreviationsListCSVFilePath);
                foreach (string fileLine in fileContent)
                {
                    string[] line = fileLine.Split(',');
                    abbreviations.Add(line[0].Trim(), line[1].Trim());
                }
                return abbreviations;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured during loading of the List of Abbreviations.\n", ex.ToString());
                return null;
            }
        }

    }
}
