namespace SASSA_Application.Classes
{
    public class Booking
    {
        public string Reference { get; set; }
        public string BeneficiaryName { get; set; }
        public string ServiceName { get; set; }
        public string Time { get; set; }
        public int QueueNumber { get; set; }          // 0 means not checked in yet
        public string Status { get; set; }            // Booked, Checked In, Waiting, Called, Being Served, Completed, No-Show

        public string QueueNumberText
        {
            get { return QueueNumber > 0 ? "Q-" + QueueNumber.ToString("000") : "-"; }
        }
    }
}
