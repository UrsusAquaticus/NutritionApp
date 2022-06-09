using NutritionApp.ViewModels;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionApp.Models
{
    public class Goal : BaseViewModel
    {
        //IDs
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Profile))]
        public int ProfileId { get; set; }

        //Private
        private Profile profile;
        private DateTime startTime;
        private DateTime endTime;
        private float dailyKj;

        //Public
        [ManyToOne]
        public Profile Profile { get => profile; set => SetValue(ref profile, value); }
        public DateTime StartTime { get => startTime; set => SetValue(ref startTime, value); }
        public DateTime EndTime { get => endTime; set => SetValue(ref endTime, value); }
        public float DailyKj { get => dailyKj; set => SetValue(ref dailyKj, value); }
    }
}
