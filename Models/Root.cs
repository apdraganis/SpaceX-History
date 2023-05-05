using System.Text.Json.Serialization;

namespace SpaceXHistory.Models
{
    public class Root
    {
        public Links Links { get; set; }
        public object Success { get; set; }
        public string Name { get; set; }
        public DateTime Date_utc { get; set; }
        public DateTime Date_local { get; set; }
        public bool Upcoming { get; set; }

        [JsonIgnore]
        public string Status
        {
            get
           {
                if (Upcoming)
                    return "Upcoming";

                if (Success is bool value)
                {
                    if (value)
                        return "Successful";
                    else
                        return "Failed";
                }

                return "Failed";
            }
        }

        [JsonIgnore]
        public Color StatusColor
        {
            get
            {
                if (Upcoming)
                    return Color.FromHex("#3a86ff");

                if (Success is bool value)
                {
                    if (value)
                        return Color.FromHex("#76c893");
                    else
                        return Color.FromHex("#e63946");
                }

                return Color.FromHex("#e63946");
            }
        }
    }
}
