using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Model
{
    public class UserInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Nationality { get; set; }
        public string BirthCountry { get; set; }
        public string Mobile { get; set; }
        public string AcademicQualification { get; set; }
    }
}
