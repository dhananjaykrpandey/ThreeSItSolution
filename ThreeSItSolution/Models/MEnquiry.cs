﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ThreeSItSolution.Models
{
    [Table("MEnquiry")]
    public class MEnquiry
    {
        [Key]
        public int IID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Full Name")]
        [Column(TypeName = "VARCHAR(30)")]
        [StringLength(30, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        [Display(Name = "Full Name")]
        public string cFullName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Address")]
        [StringLength(500, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        [Column(TypeName = "VARCHAR(500)")]
        [Display(Name = "Address")]
        public string cAddress { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Mobile No.")]
        [StringLength(10, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 10)]
        [Column(TypeName = "VARCHAR(30)")]
        [Display(Name = "Mobile No.")]
        public string cMobileNo { get; set; }

        [Display(Name = "Telephone No.")]
        [Column(TypeName = "VARCHAR(30)")]
        [StringLength(10, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 10)]
        public string cPhoneNo { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Email-ID")]
        [StringLength(30, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        [Column(TypeName = "VARCHAR(30)")]
        [EmailAddress]
        [Display(Name = "Email-Id", Prompt = "Email - Id (example@example.com)")]
        public string cEmailId { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Date of Birth")]
        [Column(TypeName = "DateTime")]
        [Display(Name = "Date Of Birth")]
        public DateTime dDob { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select Gender")]
        [StringLength(1)]
        [Column(TypeName = "VARCHAR(1)")]
        [Display(Name = "Gender")]
        public string cGenger { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Guardian Or Sponsor Name")]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        [Display(Name = "Guardian Or Sponsor Name")]
        [Column(TypeName = "VARCHAR(50)")]
        public string cGuradian { get; set; }


        [StringLength(200, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        [Display(Name = "Company")]
        [Column(TypeName = "VARCHAR(200)")]
        public string cCompnay { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select/Enter Academic Background")]
        [StringLength(200, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        [Display(Name = "Academic Background")]
        [Column(TypeName = "VARCHAR(200)")]
        public string cAcademic { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select/Enter Career Background")]
        [StringLength(200, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        [Display(Name = "Career Background")]
        [Column(TypeName = "VARCHAR(200)")]
        public string cCareerBackground { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Current Occupation")]
        [StringLength(200, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        [Display(Name = "Current Occupation")]
        [Column(TypeName = "VARCHAR(200)")]
        public string cCurrentOccupation { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter School/College Name")]
        [StringLength(200, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        [Display(Name = "School/College Name")]
        [Column(TypeName = "VARCHAR(200)")]
        public string cSchaool { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select/Enter Reason To Pursue Our Computer Course")]
        [StringLength(2000, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        [Display(Name = "Reason To Pursue Our Computer Course")]
        [Column(TypeName = "VARCHAR(2000)")]
        public string cReason { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select/Enter Source of Information")]
        [StringLength(1000, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        [Display(Name = "Source of Information")]
        [Column(TypeName = "VARCHAR(1000)")]
        public string cSourceOfInfo { get; set; }


        [StringLength(1000, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        [Display(Name = "Remarks If Any")]
        [Column(TypeName = "VARCHAR(1000)")]
        public string cRemakrs { get; set; }

        public DateTime? DCreateDate { get; set; } = DateTime.Now;
    }
}
