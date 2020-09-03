using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gains.Models
{
    [Table("Diet_Plans", Schema = "Gains")]
    public class DietPlansModel
    {
        [Key]
        [Column("Diet_Id")]
        public int DietId { get; set; }
        [Column("Diet_Heading")]
        public string DietHeading { get; set; }
        [Column("Diet_Author")]
        public string DietAuthor { get; set; }
        [Column("Diet_Author_Description")]
        public string DietAuthorDescription { get; set; }
        [Column("Diet_Category")]
        public string DietCategory { get; set; }
        [Column("Diet_Date")]
        public string DietDate { get; set; }
        [Column("Diet_Profile_Picture")]
        public string DietProfilePic { get; set; }
        [Column("Diet_Detail_Picture")]
        public string DietDetailPic { get; set; }
        [Column("Diet_Body")]
        public string DietBody { get; set; }
        [Column("Diet_Sub_Heading_1")]
        public string DietSubHeading1 { get; set; }
        [Column("Diet_Body_1")]
        public string DietBody1 { get; set; }
        [Column("Diet_Sub_Heading_2")]
        public string DietSubHeading2 { get; set; }
        [Column("Diet_Body_2")]
        public string DietBody2 { get; set; }
        [Column("Diet_Sub_Heading_3")]
        public string DietSubHeading3 { get; set; }
        [Column("Diet_Body_3")]
        public string DietBody3 { get; set; }
        [Column("Diet_Sub_Heading_4")]
        public string DietSubHeading4 { get; set; }
        [Column("Diet_Body_4")]
        public string DietBody4 { get; set; }
        [Column("Diet_Sub_Heading_5")]
        public string DietSubHeading5 { get; set; }
        [Column("Diet_Body_5")]
        public string DietBody5 { get; set; }
        [Column("Diet_Sub_Heading_6")]
        public string DietSubHeading6 { get; set; }
        [Column("Diet_Body_6")]
        public string DietBody6 { get; set; }
        [Column("Diet_Sub_Heading_7")]
        public string DietSubHeading7 { get; set; }
        [Column("Diet_Body_7")]
        public string DietBody7 { get; set; }

    }
}