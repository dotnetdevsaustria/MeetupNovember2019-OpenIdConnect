// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace BIF4.IdentityService
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("ue5-api", "BIF4 UE5 Demo API", new[]{ JwtClaimTypes.Name, JwtClaimTypes.Email })
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                // SPA client using implicit flow
                new Client
                {
                    ClientId = "bif4ss2019ue5",
                    ClientName = "BIF4 SS2019 UE5 SPA Client",
                    ClientUri = "https://localhost:5001",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =
                    {
                        "http://localhost:5000/",
                        "http://localhost:5000/silent-refresh.html",
                        "http://localhost:5002/",
                        "http://localhost:5002/silent-refresh.html",
                        "http://localhost:5004/",
                        "http://localhost:5004/silent-refresh.html",
                        "http://localhost:5006/",
                        "http://localhost:5006/silent-refresh.html",
                        "http://localhost:5008/",
                        "http://localhost:5008/silent-refresh.html",
                        "http://localhost:50010/",
                        "http://localhost:50010/silent-refresh.html",
                        "http://127.0.0.1:5000/",
                        "http://127.0.0.1:5000/silent-refresh.html",
                        "http://127.0.0.1:5002/",
                        "http://127.0.0.1:5002/silent-refresh.html",
                        "http://127.0.0.1:5004/",
                        "http://127.0.0.1:5004/silent-refresh.html",
                        "http://127.0.0.1:5006/",
                        "http://127.0.0.1:5006/silent-refresh.html",
                        "http://127.0.0.1:5008/",
                        "http://127.0.0.1:5008/silent-refresh.html",
                        "http://127.0.0.1:50010/",
                        "http://127.0.0.1:50010/silent-refresh.html",
                        "https://localhost:5001/",
                        "https://localhost:5001/silent-refresh.html",
                        "https://localhost:5003/",
                        "https://localhost:5003/silent-refresh.html",
                        "https://localhost:5005/",
                        "https://localhost:5005/silent-refresh.html",
                        "https://localhost:5007/",
                        "https://localhost:5007/silent-refresh.html",
                        "https://localhost:5009/",
                        "https://localhost:5009/silent-refresh.html",
                        "https://localhost:50011/",
                        "https://localhost:50011/silent-refresh.html",
                        "https://127.0.0.1:5001/",
                        "https://127.0.0.1:5001/silent-refresh.html",
                        "https://127.0.0.1:5003/",
                        "https://127.0.0.1:5003/silent-refresh.html",
                        "https://127.0.0.1:5005/",
                        "https://127.0.0.1:5005/silent-refresh.html",
                        "https://127.0.0.1:5007/",
                        "https://127.0.0.1:5007/silent-refresh.html",
                        "https://127.0.0.1:5009/",
                        "https://127.0.0.1:5009/silent-refresh.html",
                        "https://127.0.0.1:50011/",
                        "https://127.0.0.1:50011/silent-refresh.html",
                    },

                    PostLogoutRedirectUris =
                    {
                        "http://localhost:5000/",
                        "http://localhost:5002/",
                        "http://localhost:5004/",
                        "http://localhost:5006/",
                        "http://localhost:5008/",
                        "http://localhost:5010/",
                        "http://127.0.0.1:5000/",
                        "http://127.0.0.1:5002/",
                        "http://127.0.0.1:5004/",
                        "http://127.0.0.1:5006/",
                        "http://127.0.0.1:5008/",
                        "http://127.0.0.1:5010/",
                        "https://localhost:5001/",
                        "https://localhost:5003/",
                        "https://localhost:5005/",
                        "https://localhost:5007/",
                        "https://localhost:5009/",
                        "https://localhost:5011/",
                        "https://127.0.0.1:5001/",
                        "https://127.0.0.1:5003/",
                        "https://127.0.0.1:5005/",
                        "https://127.0.0.1:5007/",
                        "https://127.0.0.1:5009/",
                        "https://127.0.0.1:5011/",
                    },

                    AllowedCorsOrigins =
                    {
                        "http://localhost:5000",
                        "http://localhost:5002",
                        "http://localhost:5004",
                        "http://localhost:5006",
                        "http://localhost:5008",
                        "http://localhost:5010",
                        "http://127.0.0.1:5000",
                        "http://127.0.0.1:5002",
                        "http://127.0.0.1:5004",
                        "http://127.0.0.1:5006",
                        "http://127.0.0.1:5008",
                        "http://127.0.0.1:5010",
                        "https://localhost:5001/",
                        "https://localhost:5003/",
                        "https://localhost:5005/",
                        "https://localhost:5007/",
                        "https://localhost:5009/",
                        "https://localhost:5011/",
                        "https://127.0.0.1:5001/",
                        "https://127.0.0.1:5003/",
                        "https://127.0.0.1:5005/",
                        "https://127.0.0.1:5007/",
                        "https://127.0.0.1:5009/",
                        "https://127.0.0.1:5011/",
                    },

                    AllowedScopes = { "openid", "profile", "ue5-api" }
                }
            };
        }
    }
}