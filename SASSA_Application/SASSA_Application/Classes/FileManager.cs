using System.Collections.Generic;
using System.IO;

namespace SASSA_Application.Classes
{
    public static class FileManager
    {
        // ---- Beneficiaries ----
        public static List<Beneficiary> LoadBeneficiaries()
        {
            List<Beneficiary> list = new List<Beneficiary>();

            string filepath = "Users.txt";
            if (!File.Exists(filepath)) return list;

            foreach (string line in File.ReadAllLines(filepath))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');
                if (parts.Length < 8) continue;

                Beneficiary b = new Beneficiary();
                b.Name = parts[0].Trim();
                b.Surname = parts[1].Trim();
                b.IdNumber = parts[2].Trim();
                b.UserCode = parts[3].Trim();
                b.Cell = parts[4].Trim();
                b.Email = parts[5].Trim();
                b.PreferredCentre = parts[6].Trim();
                b.Password = parts[7].Trim();

  
            list.Add(b);
        }
            return list;
        }
        //public static List<Beneficiary> LoadBeneficiaries()
        //{
        //    List<Beneficiary> list = new List<Beneficiary>();

        //    string filepath = Path.Combine(Application.StartupPath, "Users.txt");
        //    if (!File.Exists(filepath)) return list;

        //    foreach (string line in File.ReadAllLines(filepath))
        //    {
        //        if (string.IsNullOrWhiteSpace(line)) continue;
        //        string[] parts = line.Split('|');
        //        if (parts.Length < 8) continue;

        //        Beneficiary b = new Beneficiary();
        //        b.Name = parts[0].Trim();
        //        b.Surname = parts[1].Trim();
        //        b.IdNumber = parts[2].Trim();
        //        b.UserCode = parts[3].Trim();
        //        b.Cell = parts[4].Trim();
        //        b.Email = parts[5].Trim();
        //        b.PreferredCentre = parts[6].Trim();
        //        b.Password = parts[7].Trim();


        //        list.Add(b);
        //    }
        //    return list;
        //}
        //public static List<StaffMember> LoadStaff()
        //{
        //    List<StaffMember> list = new List<StaffMember>();

        //    string filepath = Path.Combine(Application.StartupPath, "Users.txt");
        //    if (!File.Exists(filepath)) return list;

        //    foreach (string line in File.ReadAllLines(filepath))
        //    {
        //        if (string.IsNullOrWhiteSpace(line)) continue;
        //        string[] parts = line.Split('|');

        //        if (parts.Length < 8) continue;


        //        if (parts[3].Trim().Equals("STAFF", StringComparison.OrdinalIgnoreCase))
        //        {
        //            StaffMember s = new StaffMember();
        //            s.Name = parts[0].Trim();
        //            s.StaffNumber = parts[2].Trim();
        //            s.Email = parts[5].Trim();
        //            s.CentreId = parts[6].Trim();
        //            s.Password = parts[7].Trim();


        //            list.Add(s);
        //        }
        //    }
        //        return list;
        //    }
        

        public static List<Booking> LoadBookings()
        {
            List<Booking> list = new List<Booking>();

            if (!File.Exists("Bookings.txt")) return list;

            foreach (string line in File.ReadAllLines("Bookings.txt"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');
                if (parts.Length < 9) continue;

                Booking b = new Booking();
                b.Reference = parts[0];
                b.BeneficiaryId = parts[1];
                b.BeneficiaryName = parts[2];
                b.ServiceName = parts[3];
                b.CentreName = parts[4];
                b.Date = parts[5];
                b.Time = parts[6];
                b.Status = parts[7];
                b.QueueNumber = parts[8];

                list.Add(b);
            }
            return list;
        }

        public static void SaveBooking(Booking b)
        {
            string line = b.Reference + "|" + b.BeneficiaryId + "|" + b.BeneficiaryName + "|" +
                          b.ServiceName + "|" + b.CentreName + "|" + b.Date + "|" +
                          b.Time + "|" + b.Status + "|" + b.QueueNumber;

            File.AppendAllText("Bookings.txt", line + System.Environment.NewLine);
        }

        public static void SaveAllBookings(List<Booking> bookings)
        {
            List<string> lines = new List<string>();

            foreach (Booking b in bookings)
            {
                string line = b.Reference + "|" + b.BeneficiaryId + "|" + b.BeneficiaryName + "|" +
                              b.ServiceName + "|" + b.CentreName + "|" + b.Date + "|" +
                              b.Time + "|" + b.Status + "|" + b.QueueNumber;
                lines.Add(line);
            }

            File.WriteAllLines("Bookings.txt", lines);
        }

        // ---- Services ----
        public static List<ServiceType> LoadServices()
        {
            List<ServiceType> list = new List<ServiceType>();

            if (!File.Exists("Services.txt")) return list;

            foreach (string line in File.ReadAllLines("Services.txt"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');
                if (parts.Length < 4) continue;

                ServiceType s = new ServiceType();
                s.ServiceId = parts[0];
                s.ServiceName = parts[1];
                s.Description = parts[2];
                s.Status = parts[3];

                list.Add(s);
            }
            return list;
        }

        public static void SaveServices(List<ServiceType> services)
        {
            List<string> lines = new List<string>();

            foreach (ServiceType s in services)
            {
                lines.Add(s.ServiceId + "|" + s.ServiceName + "|" + s.Description + "|" + s.Status);
            }
            File.WriteAllLines("Services.txt", lines);
        }
    }
}