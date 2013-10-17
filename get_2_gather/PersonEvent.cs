using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace get_2_gather
{
    class PersonEventItem
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "EventID")]
        public int EventID { get; set; }

        [JsonProperty(PropertyName = "PersonID")]
        public int PersonID { get; set; }

        [JsonProperty(PropertyName = "IsAttendingResponse")]
        public bool IsAttendingResponse { get; set; }
    }
}
