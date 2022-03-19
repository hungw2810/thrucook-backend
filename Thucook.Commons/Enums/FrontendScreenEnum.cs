using System.ComponentModel;

namespace Thucook.Commons.Enums
{
    public enum FrontendScreenEnum
    {
        [Description("Clinic Settings - General")]
        GeneralSettings = 1,
        [Description("Clinic Settings - Locations")]
        Locations = 2,
        [Description("Clinic Settings - Specialties")]
        Specialties = 3,
        [Description("Clinic Settings - Doctors")]
        Doctors = 4,
        [Description("Clinic Settings - Symptoms")]
        Symptoms = 5,
        [Description("Clinic Settings - Users")]
        Users = 6,
        [Description("Clinic Settings - User Roles")]
        UserRoles = 7,
        [Description("Clinic Settings - User Groups")]
        UserGroups = 8,
        [Description("Clinic Settings - Properties")]
        Properties = 13,
        [Description("Clinic Settings - Forms")]
        Forms = 14,
        [Description("Clinic Settings - Medicine Library")]
        MedicineLibrary = 15,

        [Description("Dashboards - Doctor Schedules")]
        DoctorSchedules = 9,
        [Description("Dashboards - Appointments")]
        Appointments = 10,
        [Description("Dashboards - Today Examinations")]
        TodayQueue = 11,

        [Description("Lists - Contacts")]
        Contacts = 12,
        [Description("Lists - Medical Records")]
        MedicalRecords = 17,
    }
}
