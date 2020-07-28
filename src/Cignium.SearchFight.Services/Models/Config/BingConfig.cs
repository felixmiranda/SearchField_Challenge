namespace App.SearchFight.Services.Models.Config
{
    public class BingConfig : BaseConfig
    {
        public static string BaseUrl => GetFromConfiguration("Bing.Url");
        public static string ApiKey => GetFromConfiguration("Bing.ApiKey");        
    }
}