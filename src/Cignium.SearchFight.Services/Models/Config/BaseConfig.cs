using System.Configuration;

namespace App.SearchFight.Services.Models.Config
{
    public class BaseConfig
    {
        private const string MissingConfiguration = "There was an issue with the configuration file. (Missing Value: {Key})";

        public static string GetFromConfiguration(string key)
        {
            var configurationValue = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(configurationValue))
                throw new ConfigurationErrorsException(MissingConfiguration.Replace("{Key}", key));

            return configurationValue;
        }
    }
}
