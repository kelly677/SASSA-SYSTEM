namespace SASSA_Application.Classes
{
    public class TimeSlot
    {
        public string SlotId { get; set; }
        public string CentreId { get; set; }
        public string Date { get; set; }         // yyyy-MM-dd
        public string Time { get; set; }         // e.g. "09:00"
        public int Capacity { get; set; }
        public int BookedCount { get; set; }

        public int AvailablePositions
        {
            get { return Capacity - BookedCount; }
        }
    }
}