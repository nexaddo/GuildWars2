﻿using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace GuildWars2.ArenaNet.API
{
    public class RecipesResponse
    {
        [JsonProperty("recipes")]
        public List<int> Recipes { get; set; }
    }
}
