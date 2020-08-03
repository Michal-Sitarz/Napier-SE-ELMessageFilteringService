using ELMessageFilteringService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace ELMessageFilteringService.DataAccess
{
    public class DataProvider : IDataProvider
    {
        private readonly string allMessagesJSONFilePath = @"C:\ELMfiles\AllMessages.json";
        private readonly string lastMessageJSONFilePath = @"C:\ELMfiles\LastMessage.json";
        private readonly string messagesToImportCSVFilePath = @"C:\ELMfiles\MessagesToImport.csv";
        private readonly string abbreviationsListCSVFilePath = @"C:\ELMfiles\AbbreviationsList.csv";

        public bool ExportMessage(object message)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            try
            {
                var messageInJson = JsonSerializer.Serialize(message, jsonOptions);
                File.AppendAllText(allMessagesJSONFilePath, messageInJson + "\n");
                File.WriteAllText(lastMessageJSONFilePath, messageInJson);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured during exporting of a new message to the JSON file.\n", ex.ToString());
                return false;
            }
        }

        public IList<RawMessage> ImportMessages()
        {
            var messages = new List<RawMessage>();

            try
            {
                var fileContent = File.ReadAllLines(messagesToImportCSVFilePath);
                foreach (string fileLine in fileContent)
                {
                    string[] line = fileLine.Split(',');

                    messages.Add(new RawMessage
                    {
                        Header = line[0],
                        Body = line[1]
                    });
                }

                return messages;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured during loading of the List of Messages.\n", ex.ToString());
                return null;
            }
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
