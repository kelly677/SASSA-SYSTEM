namespace SASSA_Application.Classes
{
    public class Booking
    {
        public string Reference { get; set; }
        public string BeneficiaryId { get; set; }       // ID number
        public string BeneficiaryName { get; set; }
        public string ServiceName { get; set; }
        public string CentreName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }              // Booked, Checked In, Waiting, Called, Being Served, Completed, Cancelled, No-Show
        public string QueueNumber { get; set; }         // e.g. "Q-001"

        public string QueueNumberText
        {
            get { return QueueNumber; }
        }
    }
}