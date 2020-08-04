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
        private readonly string statisticsJSONFilePath = @"C:\ELMfiles\Statistics.json";


        public bool ExportMessage(object message)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
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
                MessageBox.Show("An error occured during exporting of a new message to the JSON file.\n" + ex.ToString(), "Error");
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
                MessageBox.Show("An error occured during loading of the List of Messages.\n\n" + ex.ToString(), "Error");
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
                MessageBox.Show("An error occured during loading of the List of Abbreviations.\n\n" + ex.ToString(), "Error");
                return null;
            }
        }

        public StatisticsDTO ImportStatistics()
        {
            try
            {
                if (File.Exists(statisticsJSONFilePath))
                {
                    var fileContent = File.ReadAllText(statisticsJSONFilePath);
                    if (fileContent != null)
                    {
                        var statsFromJson = JsonSerializer.Deserialize<StatisticsDTO>(fileContent);
                        return statsFromJson;
                    }
                }
                //MessageBox.Show("File containing statistics has been either emptied, moved, deleted or corrupted.");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured during importing of statistics from the JSON file.\n\n" + ex.ToString(), "Error");
                return null;
            }
        }

        public bool ExportStatistics(StatisticsDTO statistics)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            try
            {
                var statisticsInJson = JsonSerializer.Serialize(statistics, jsonOptions);
                File.WriteAllText(statisticsJSONFilePath, statisticsInJson);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured during exporting of statistics to the JSON file.\n\n" + ex.ToString(), "Error");
                return false;
            }
        }
    }
}
