using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Gains.Models
{
    public class GainsContext : DbContext
    {
        public GainsContext():base("GainsConnectionString")
        {
           
        }
       
        public DbSet<DietPlansModel> dietPlansModels
        {
            get;
            set;
        }
        public DbSet<WorkoutPlansModel> workoutPlansModels
        {
            get;set;
        }
        public DbSet<UserInformationModel> userInformationModels
        {
            get;set;
        }
    }
}