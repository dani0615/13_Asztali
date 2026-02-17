using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LoLAPI.Models
{
    public class ChampionDatas
    {
        [JsonPropertyName("data")]
        public Dictionary<string, Champion> Data { get; set; }


    }
}
