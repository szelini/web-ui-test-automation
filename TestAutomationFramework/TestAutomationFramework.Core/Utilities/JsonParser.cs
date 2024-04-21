using Newtonsoft.Json;

namespace TestAutomationFramework.Core.Utilities
{
    public class JsonParser
    {
        public static T DeserializeJsonFileToObject<T>(string jsonpath)
        {
           return JsonConvert.DeserializeObject<T>(File.ReadAllText(jsonpath));
        }

        public static T DeserializeJsonToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static List<T> DeserializeJsonToList<T>(string json)
        {
            return JsonConvert.DeserializeObject<List<T>>(json);
        }
    }
}
