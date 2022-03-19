namespace Thucook.Main.ApiService.Models
{
    public class DoctorScheduleSlot
    {
        public long ScheduleId { get; set; }

        public long OccurrenceStartUnix { get; set; }

        public long[] Slots { get; set; }
    }
}
