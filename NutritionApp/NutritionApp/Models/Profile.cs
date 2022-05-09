using System;

namespace NutritionApp.Models
{
    public class Profile
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Age { get; set; }
        public string Gender { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float Activity { get; set; }
        public float Pregnant { get; set; }
    }
}