using System;
using System.Collections.Generic;
using System.IO;

namespace SASSA_Application.Classes
{
    public static class FileManager
    {
        // ============================================================
        // BENEFICIARIES (also holds Admin accounts)
        // Format: Name|Surname|ID|Cell|Email|Centre|Password
        // ============================================================
        public static List<Beneficiary> LoadBeneficiaries()
        {
            List<Beneficiary> list = new List<Beneficiary>();

            if (!File.Exists("Beneficiaries.txt")) return list;

            foreach (string line in File.ReadAllLines("Beneficiaries.txt"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split('|');
                if (parts.Length < 7) continue;

                Beneficiary b = new Beneficiary();
                b.Name = parts[0];
                b.Surname = parts[1];
                b.IdNumber = parts[2];
                b.Cell = parts[3];
                b.Email = parts[4];
                b.PreferredCentre = parts[5];
                b.Password = parts[6];

                list.Add(b);
            }
            return list;
        }

        public static void SaveBeneficiaries(List<Beneficiary> list)
        {
            List<string> lines = new List<string>();

            foreach (Beneficiary b in list)
            {
                string line = b.Name + "|" + b.Surname + "|" + b.IdNumber + "|" +
                              b.Cell + "|" + b.Email + "|" + b.PreferredCentre + "|" +
                              b.Password;
                lines.Add(line);
            }

            File.WriteAllLines("Beneficiaries.txt", lines);
        }

        // ============================================================
        // STAFF
        // Format: FullName|StaffNumber|Centre|Email
        // ============================================================
        public static List<StaffMember> LoadStaff()
        {
            List<StaffMember> list = new List<StaffMember>();

            if (!File.Exists("Staff.txt")) return list;

            foreach (string line in File.ReadAllLines("Staff.txt"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split('|');
                if (parts.Length < 4) continue;

                StaffMember s = new StaffMember();
                s.Name = parts[0];
                s.StaffNumber = parts[1];
                s.CentreId = parts[2];
                s.Email = parts[3];
                s.Password = parts[3];   // staff password is their email

                list.Add(s);
            }
            return list;
        }

        public static void SaveStaff(List<StaffMember> list)
        {
            List<string> lines = new List<string>();

            foreach (StaffMember s in list)
            {
                string line = s.Name + "|" + s.StaffNumber + "|" + s.CentreId + "|" + s.Email;
                lines.Add(line);
            }

            File.WriteAllLines("Staff.txt", lines);
        }

        // ============================================================
        // BOOKINGS
        // Format: Reference|BeneficiaryId|BeneficiaryName|Service|Centre|Date|Time|Status|QueueNumber
        // ============================================================
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

            File.AppendAllText("Bookings.txt", line + Environment.NewLine);
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

        // ============================================================
        // SERVICES
        // Format: ServiceId|ServiceName|Description|Status
        // ============================================================
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

        public static void SaveServices(List<ServiceType> list)
        {
            List<string> lines = new List<string>();

            foreach (ServiceType s in list)
            {
                lines.Add(s.ServiceId + "|" + s.ServiceName + "|" + s.Description + "|" + s.Status);
            }

            File.WriteAllLines("Services.txt", lines);
        }
    }
}