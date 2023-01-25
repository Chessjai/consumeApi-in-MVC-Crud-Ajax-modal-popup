using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S3Q3.Models
{
    [Table("s3q3ajax")]
    public class studentmodel
    {

        //  public int Id { get; set; }
        //  [Required(ErrorMessage = "Name is Required")]
        //[Key]
        //public int Id { get; set; }
        //[Required(ErrorMessage = "Name is Required")]
        //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only Alphabestis Char is allowed")]
        //public string Name { get; set; }
        //public int Age { get; set; }

        //[DataType(DataType.Date)]
        //public DateTime DOB { get; set; }
        //[NotMapped]
        //public string DOB1 { get; set; }
        //public Nullable<System.DateTime> created_on { get; set; }
        //public Nullable<System.DateTime> update_on { get; set; }
        //[NotMapped]
        //public string created_on2 { get; set; }
        //[NotMapped]
        //public string update_on2 { get; set; }
        //public int create_by { get; set; }
        //public int updated_by { get; set; }

        [Key]
        public long id { get; set; }
        [RegularExpression("[A-Za-z ]*", ErrorMessage = "Invalid Name ")]
        [Required(ErrorMessage = "You Cannot leave this feild empty")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string name { get; set; }
        public int age { get; set; }

        [DataType(DataType.Date)]
        public DateTime dob { get; set; }
        [NotMapped]
        public string DOB1 { get; set; }

        public Nullable<System.DateTime> createdon { get; set; }


        public Nullable<System.DateTime> updateon { get; set; }
        [NotMapped]
        public string created_on2 { get; set; }
        [NotMapped]
        public string update_on2 { get; set; }
        public long createby { get; set; }
        public long updatedby { get; set; }
    }
}