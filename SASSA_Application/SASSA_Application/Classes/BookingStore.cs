using System.Collections.Generic;
using System.Linq;

namespace SASSA_Application.Classes
{
    public static class BookingStore
    {
        // One list, shared by the beneficiary portal and the staff portal
        public static List<Booking> Bookings = new List<Booking>
        {
            new Booking { Reference = "SASSA-2024-001", BeneficiaryName = "Nomsa Dlamini",  ServiceName = "New Grant Application", Time = "09:00", QueueNumber = 3, Status = "Waiting" },
            new Booking { Reference = "SASSA-2024-002", BeneficiaryName = "Sipho Nkosi",    ServiceName = "Payment Enquiry",       Time = "09:30", QueueNumber = 1, Status = "Being Served" },
            new Booking { Reference = "SASSA-2024-003", BeneficiaryName = "Thandi Mokoena", ServiceName = "Grant Information Update", Time = "10:00", QueueNumber = 0, Status = "Booked" },
            new Booking { Reference = "SASSA-2024-004", BeneficiaryName = "David Khoza",    ServiceName = "Document Submission",   Time = "08:00", QueueNumber = 0, Status = "Completed" },
            new Booking { Reference = "SASSA-2024-005", BeneficiaryName = "Mpho Sithole",   ServiceName = "General Assistance",    Time = "11:00", QueueNumber = 4, Status = "Checked In" }
        };
    }
}

