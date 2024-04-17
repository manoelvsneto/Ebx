using System.Text.Json.Serialization;
using static Ebx.Models.Event;

namespace Ebx.Models
{

    public class Event
    {
   
        public class Request
        {
            public string Type { get; set; }
            public string? Destination { get; set; }
            public string? Origin { get; set; }
            public int Amount { get; set; }
        }
    }
}