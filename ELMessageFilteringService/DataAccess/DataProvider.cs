using ELMessageFilteringService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Windows;

namespace ELMessageFilteringService.DataAccess
{
    public class DataProvider : IDataProvider
    {
        private readonly string allMessagesJSONFile = "AllMessages.json";
        private readonly string lastMessageJSONFile = "LastMessage.json";
        private readonly string messagesToImportCSVFile = "MessagesToImport.csv";
        private readonly string abbreviationsListCSVFile = "AbbreviationsList.csv";
        private readonly string statisticsJSONFile = "Statistics.json";

        public bool ExportMessage(object message)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            try
            {
                var messageInJson = JsonSerializer.Serialize(message, jsonOptions);
                File.AppendAllText(GetFilePath(allMessagesJSONFile), messageInJson + "\n");
                File.WriteAllText(GetFilePath(lastMessageJSONFile), messageInJson);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured during exporting of a new message to the JSON file.\n" + ex.ToString(), "Error");
                return false;
            }
        }

        public IList<RawMessage> ImportRawMessages()
        {
            var messages = new List<RawMessage>();

            try
            {
                var fileContent = File.ReadAllLines(GetFilePath(messagesToImportCSVFile));
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
                var fileContent = File.ReadAllLines(GetFilePath(abbreviationsListCSVFile));
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
                if (File.Exists(GetFilePath(statisticsJSONFile)))
                {
                    var fileContent = File.ReadAllText(GetFilePath(statisticsJSONFile));
                    if (fileContent != null)
                    {
                        var statsFromJson = JsonSerializer.Deserialize<StatisticsDTO>(fileContent);
                        return statsFromJson;
                    }
                }
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
                File.WriteAllText(GetFilePath(statisticsJSONFile), statisticsInJson);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured during exporting of statistics to the JSON file.\n\n" + ex.ToString(), "Error");
                return false;
            }
        }

        private string GetFilePath(string fileName)
        {
            var assemblyLocation = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var filePath = assemblyLocation + @"\ELMfiles\" + fileName;
            if (!File.Exists(filePath))
            {
                filePath = @"C:\ELMfiles\" + fileName;
            }
            return filePath;
        }
    }
}
