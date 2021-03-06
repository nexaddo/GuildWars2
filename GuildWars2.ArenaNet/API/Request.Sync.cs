﻿using System;
using System.Collections.Generic;

using RestSharp;

using GuildWars2.ArenaNet;

namespace GuildWars2.ArenaNet.API
{
    public abstract partial class Request<T>
        where T : class, new()
    {
        public T Execute()
        {
            RestClient client = new RestClient();
            client.BaseUrl = URL;
            client.Timeout = Timeout;
            client.AddHandler("application/json", new RestSharpNewtonSoftJsonDeserializer());
            client.AddHandler("text/json", new RestSharpNewtonSoftJsonDeserializer());

            RestRequest request = new RestRequest();
            request.Method = APIMethod;
            request.Resource = APIPath;

            foreach (KeyValuePair<string, string> parameter in APIParameters)
            {
                request.AddParameter(parameter.Key, parameter.Value);
            }

            IRestResponse<T> response = client.Execute<T>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return response.Data;
            else
                return null;
        }
    }
}
