using System;
using Newtonsoft.Json;

namespace BetweenNet.Events
{
    [Serializable]
    public abstract class BaseEvent
    {
        [JsonProperty("SendAt")]
        public DateTime SendAt { get; set; }

        public BaseEvent()
        {
            SendAt = DateTime.Now;
        }
    }
}
