using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionApp.Models
{
    public class Goal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Profile))]
        public int ProfileId { get; set; }

        [ManyToOne]
        public Profile Profile { get; set; }

        //
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public float DailyKj { get; set; }

    }
}
