using Thucook.Commons.CustomJsonConverter;
using Thucook.Commons.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Thucook.Commons.Extensions
{
    public static class JsonExtensions
    {
        private static JsonSerializerSettings _defaultSetting;
        private static JsonSerializerSettings DefaultSetting
        {
            get
            {
                if (_defaultSetting == null)
                {
                    _defaultSetting = CreateDefaultSetting();
                }
                return _defaultSetting;
            }
        }

        private static JsonSerializerSettings _camelCaseSetting;
        private static JsonSerializerSettings CamelCaseSetting
        {
            get
            {
                if (_camelCaseSetting == null)
                {
                    _camelCaseSetting = CreateDefaultSetting();
                    _camelCaseSetting.ContractResolver = new CamelCasePropertyNamesContractResolver();
                }
                return _camelCaseSetting;
            }
        }

        private static JsonSerializerSettings CreateDefaultSetting()
        {
            var setting = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                //DefaultValueHandling = DefaultValueHandling.Ignore,
            };
            setting.Converters.Add(new CustomGuidConverter());

            return setting;
        }

        public static string JsonSerialize<T>(this T obj, bool camelCase = false) where T : class
        {
            if (obj == null)
                return null;
            if (camelCase)
            {
                return JsonConvert.SerializeObject(obj, CamelCaseSetting);
            }
            else
            {
                return JsonConvert.SerializeObject(obj, DefaultSetting);
            }
        }

        public static T JsonDeserialize<T>(this string jsonValue)
        {
            if (string.IsNullOrEmpty(jsonValue))
                return default;

            return JsonConvert.DeserializeObject<T>(jsonValue, DefaultSetting);
        }
    }
}
