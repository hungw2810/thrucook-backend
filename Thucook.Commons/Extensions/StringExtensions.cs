using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Thucook.Commons.Enums;

namespace Thucook.Commons.Extensions
{
    public static class StringExtensions
    {
        private static readonly IDictionary<string, ApiMethodTypeEnum> ApiMethodTypeMap =
            new Dictionary<string, ApiMethodTypeEnum>
            {
                { "GET"    , ApiMethodTypeEnum.Get   },
                { "POST"   , ApiMethodTypeEnum.Post  },
                { "PUT"    , ApiMethodTypeEnum.Put   },
                { "DELETE" , ApiMethodTypeEnum.Delete}
            };
        public static ApiMethodTypeEnum ToApiMethod(this string method)
        {
            return ApiMethodTypeMap[method.ToUpper()];
        }

        public static string RemoveDiacritics(this string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public static string ToSnakeCase(this string text)
        {
            var stringBuilder = new StringBuilder();
            foreach (var c in text)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory == UnicodeCategory.SpaceSeparator)
                {
                    stringBuilder.Append('_');
                }
                else if (unicodeCategory == UnicodeCategory.LowercaseLetter ||
                         unicodeCategory == UnicodeCategory.UppercaseLetter ||
                         unicodeCategory == UnicodeCategory.DecimalDigitNumber)
                {
                    stringBuilder.Append(char.ToLower(c));
                }
            }

            return stringBuilder.ToString();
        }
    }
}
