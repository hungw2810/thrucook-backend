namespace Thucook.Commons.Constants
{
    public static class AppConstants
    {
        public static class EnvironmentName
        {
            public const string Development = "Development";
            public const string Staging = "Staging";
            public const string Production = "Production";
        }

        public static class ConfigurationLocation
        {
            public const string LocalMachine = "machine";
            public const string S3 = "s3";
        }

        public static class AppHeader
        {
            public const string X_APP_ID = "x-app-id";
            public const string X_USER_ID = "x-user-id";
            public const string X_SCREEN_ID = "x-screen-id";
            public const string X_FEATURE_ID = "x-feature-id";
        }
    }
}
