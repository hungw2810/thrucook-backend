using System.ComponentModel;

namespace Thucook.Commons.Enums
{
    public enum FrontendFeatureEnum
    {
        [Description("Add Appointment")]
        AddAppointment = 101,
        [Description("Approve Appointment")]
        ApproveAppointment = 102,
        [Description("Check in Appointment")]
        CheckInAppointment = 103,
        [Description("Start/finish Appointment")]
        StartFinishAppointment = 104,
        [Description("Cancel Appointment")]
        CancelAppointment = 105,
    }
}
