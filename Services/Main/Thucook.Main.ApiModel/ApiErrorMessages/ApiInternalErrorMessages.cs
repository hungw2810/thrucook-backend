namespace Thucook.Main.ApiModel.ApiErrorMessages
{
    /// <summary>
    /// Prefix must be: PINT_
    /// </summary>
    public static class ApiInternalErrorMessages
    {

        #region Exact errors PINT_1xxx
        public static ApiErrorMessage EmailAlreadyUsed => new ApiErrorMessage
        {
            Code = "PINT_1001",
            Value = "Email Already Used"
        };

        public static ApiErrorMessage DuplicateLocationName => new ApiErrorMessage
        {
            Code = "PINT_1002",
            Value = "Duplicate Location Name"
        };

        public static ApiErrorMessage DuplicateLocationPhoneNumber => new ApiErrorMessage
        {
            Code = "PINT_1003",
            Value = "Duplicate Location Phone Number"
        };

        #endregion

        #region Notfound errors PINT_4xxx

        #endregion

        #region Invalid errors PINT_5xxx
        public static ApiErrorMessage InvalidSignupCode => new ApiErrorMessage
        {
            Code = "PINT_5001",
            Value = "Invalid Signup Code"
        };
        #endregion
    }
}
