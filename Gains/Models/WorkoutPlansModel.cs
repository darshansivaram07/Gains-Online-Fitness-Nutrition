using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gains.Models
{
    [Table("Workout_Plans", Schema = "Gains")]
    public class WorkoutPlansModel
    {

        [Key]
        [Column("Workout_Id")]
        public int WorkoutId { get; set; }
        [Column("Workout_Heading")]
        public string WorkoutHeading { get; set; }
        [Column("Workout_Author")]
        public string WorkoutAuthor { get; set; }
        [Column("Workout_Author_Description")]
        public string WorkoutAuthorDescription { get; set; }
        [Column("Workout_Category")]
        public string WorkoutCategory { get; set; }
        [Column("Workout_Date")]
        public string WorkoutDate { get; set; }
        [Column("Workout_Profile_Picture")]
        public string WorkoutProfilePic { get; set; }
        [Column("Workout_Detail_Picture")]
        public string WorkoutDetailPic { get; set; }
        [Column("Workout_Body")]
        public string WorkoutBody { get; set; }
        [Column("Workout_Sub_Heading_1")]
        public string WorkoutSubHeading1 { get; set; }
        [Column("Workout_Body_1")]
        public string WorkoutBody1 { get; set; }
        [Column("Workout_Sub_Heading_2")]
        public string WorkoutSubHeading2 { get; set; }
        [Column("Workout_Body_2")]
        public string WorkoutBody2 { get; set; }
        [Column("Workout_Sub_Heading_3")]
        public string WorkoutSubHeading3 { get; set; }
        [Column("Workout_Body_3")]
        public string WorkoutBody3 { get; set; }
        [Column("Workout_Sub_Heading_4")]
        public string WorkoutSubHeading4 { get; set; }
        [Column("Workout_Body_4")]
        public string WorkoutBody4 { get; set; }
        [Column("Workout_Sub_Heading_5")]
        public string WorkoutSubHeading5 { get; set; }
        [Column("Workout_Body_5")]
        public string WorkoutBody5 { get; set; }
        [Column("Workout_Sub_Heading_6")]
        public string WorkoutSubHeading6 { get; set; }
        [Column("Workout_Body_6")]
        public string WorkoutBody6 { get; set; }
        [Column("Workout_Sub_Heading_7")]
        public string WorkoutSubHeading7 { get; set; }
        [Column("Workout_Body_7")]
        public string WorkoutBody7 { get; set; }
    }
}