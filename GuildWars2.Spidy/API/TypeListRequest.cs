﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.Spidy.API
{
    public class TypeListRequest : Request<TypeListResponse>
    {
        protected override string GetAPIPath()
        {
            return "/api/" + VERSION + "/" + FORMAT + "/types";
        }
    }
}
