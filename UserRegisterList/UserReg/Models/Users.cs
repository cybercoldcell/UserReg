using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserReg.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Maximum characters is 30")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Maximum characters is 50")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[Range(typeof(DateTime), "01/01/2019", "30/06/2019", ErrorMessage = "Date is out of Range")]
        public Nullable<DateTime> DateReg { get; set; }
        
        public string SelectedDays { get; set; }

        [StringLength(100, ErrorMessage = "Maximum characters is 100")]
        public string AddRequest { get; set; }

        [Required]
        public List<DayList> DayListCheckBox { get; set; }
    }

    public class DayList
    {
        public string Day { get; set; }
        public bool IsChecked { get; set; }
    }

   
}
