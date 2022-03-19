namespace Thucook.Main.ApiModel.ApiErrorMessages
{
    /// <summary>
    /// Prefix must be: PSYS_
    /// </summary>
    public static class ApiSystemErrorMessages
    {
        public static ApiErrorMessage INTERNAL_SERVER_ERROR => new ApiErrorMessage
        {
            Code = "PSYS_5001",
            Value = "Internal server error{0}"
        };
        public static ApiErrorMessage MODEL_VALIDATION_FAILED => new ApiErrorMessage
        {
            Code = "PSYS_4001",
            Value = "Invalid request model{0}"
        };
    }
}
