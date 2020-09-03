using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gains.Models
{
    [Table("User_Information", Schema = "Gains")]
    public class UserInformationModel
    {
        [Key]
        [Column("User_Id")]
        public int UserId { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Alphabets Only!!!")]
        [Column("User_First_Name")]
        public string UserFirstName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Alphabets Only!!!")]
        [Column("User_Last_Name")]
        public string UserLastName { get; set; }
        [Required]
        [Column("User_Phone_Number")]
        [RegularExpression(@"^[1-9]{1}[0-9]{9}$", ErrorMessage = "Enter your 10 digit phone number and it cannot start with 0")]

        public string UserPhoneNumber { get; set; }
        [Required]
        [Column("User_Email_Id")]
        [EmailAddress(ErrorMessage ="Enter your gmail-id")]
        public string UserEmailId { get; set; }
    }
}