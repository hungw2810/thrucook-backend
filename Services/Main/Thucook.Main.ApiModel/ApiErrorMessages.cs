namespace Thucook.Main.ApiModel
{
    public class ApiErrorMessage
    {
        internal ApiErrorMessage() { }
        public string Code { get; internal set; }
        public string Value { get; internal set; }
        public ApiErrorMessage Format(params string[] formatValues)
        {
            return new ApiErrorMessage
            {
                Code = Code,
                Value = string.Format(Value, formatValues)
            };
        }
    }
}
