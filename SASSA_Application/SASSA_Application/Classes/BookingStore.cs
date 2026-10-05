using System.Collections.Generic;

namespace SASSA_Application.Classes
{
    public static class BookingStore
    {
        // Empty at startup. Bookings are added when a beneficiary creates one.
        public static List<Booking> Bookings = new List<Booking>();

        // Call this once when the app starts (or when a portal opens)
        // to load all bookings from the file.
        public static void Load()
        {
            Bookings = FileManager.LoadBookings();
        }
    }
}