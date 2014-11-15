using Newtonsoft.Json;
using System;

namespace PostItSample {
    public class PostItItem{
        public string Id { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "delete_flg")]
        public bool DeleteFlg { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreateAt { get; set; }

    }


}
