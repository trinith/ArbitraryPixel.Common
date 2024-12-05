using Newtonsoft.Json;

namespace ArbitraryPixel.Common.Json.JsonDotNET
{
    public class JsonDotNETJsonConvert : IJsonConvert
    {
        public T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public string SerializeObject(object value, bool isIndented = true)
        {
            return JsonConvert.SerializeObject(value, (isIndented) ? Formatting.Indented : Formatting.None);
        }
    }
}
