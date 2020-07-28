namespace App.SearchFight.Services.Models.Config
{
    public class GoogleConfig : BaseConfig
    {
        public static string BaseUrl => GetFromConfiguration("Google.Url");
        public static string ApiKey => GetFromConfiguration("Google.ApiKey");
        public static string ContextId => GetFromConfiguration("Google.Cx");        
    }
}