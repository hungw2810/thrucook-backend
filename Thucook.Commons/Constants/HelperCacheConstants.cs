using System;

namespace Thucook.Commons.Constants
{
    public static class HelperCacheConstants
    {
        public const long ClinicIdLocationIdsToCacheTimeoutInSeconds = 60; // TODO: it's should be longer
        public const long ClinicIdDoctorIdsToCacheTimeoutInSeconds = 60; // TODO: it's should be longer
        public const long UserIdToClinicIdCacheTimeoutInSeconds = 7 * 24 * 3600;
        public const long UserIdToClinicOwnerCacheTimeoutInSeconds = 300;
        public const long UserIdToLocationIdsCacheTimeoutInSeconds = 30;
        public const long UserIdToDoctorIdsCacheTimeoutInSeconds = 30;

        public static readonly int CacheAuthorizationFailInSeconds = 5;

        public static class CacheKey
        {
            public static string ClinicIdToLocationIds(Guid clinicId) => $"Clinic:{clinicId}|LocationIds";
            public static string ClinicIdToDoctorIds(Guid clinicId) => $"Clinic:{clinicId}|DoctorIds";
            public static string UserIdToClinicId(Guid userId) => $"User:{userId}|ClinicId";
            public static string UserIdToClinicOwner(Guid clinicId, Guid userId) => $"User:{userId}|Clinic:{clinicId}|IsOwner";
            public static string UserIdToLocationIds(Guid clinicId, Guid userId) => $"User:{userId}|Clinic:{clinicId}|LocationIds";
            public static string UserIdToDoctorIds(Guid clinicId, Guid userId) => $"User:{userId}|Clinic:{clinicId}|DcotorIds";
        }
    }
}
