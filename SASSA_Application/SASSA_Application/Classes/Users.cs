namespace SASSA_Application.Classes
{
    public abstract class User
    {
        public string Name { get; set; }          // for staff this holds the full name
        public string Surname { get; set; } = "";
        public string Email { get; set; }
        public string Password { get; set; }

        public abstract string Role { get; }
        public abstract string LoginId { get; }   // each type decides what it logs in with

        public string FullName { get { return (Name + " " + Surname).Trim(); } }
    }

    public class Beneficiary : User
    {
        public string IdNumber { get; set; }
        public string Cell { get; set; }
        public string PreferredCentre { get; set; }

        public override string Role { get { return "Beneficiary"; } }
        public override string LoginId { get { return IdNumber; } }
    }

    public class Administrator : Beneficiary      // same registration details as a beneficiary
    {
        public override string Role { get { return "Admin"; } }
    }

    public class StaffMember : User
    {
        public string StaffNumber { get; set; }
        public string CentreId { get; set; }

        public override string Role { get { return "Staff"; } }
        public override string LoginId { get { return StaffNumber; } }
    }
}