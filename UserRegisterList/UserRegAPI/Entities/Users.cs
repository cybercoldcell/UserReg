using System;
using System.Collections.Generic;

namespace UserRegAPI.Entities
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public Nullable<DateTime> DateReg { get; set; }
        public string SelectedDays { get; set; }
        public string AddRequest { get; set; }
    }
}
