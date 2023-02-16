// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Collections.Generic;

namespace Idp
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("api1", "My API #1")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                // client credentials flow client
                new Client
                {
                    ClientId = "console client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "api1" }
                },
                
                //WPFclient poassword grant
                new Client{
                    ClientId="WPF client",
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    ClientSecrets={ new Secret("WPF client".Sha256())},
                    AllowedScopes={
                        "api1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },

                // MVC client using hybrid flow
                new Client
                {
                    ClientId = "MVC Client",
                    ClientName = "My MVC Client",

                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                    ClientSecrets = { new Secret("MVC client".Sha256()) },

                    RedirectUris = { "http://localhost:5002/signin-oidc" },
                    FrontChannelLogoutUri = "http://localhost:5002/signout-oidc",
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                    //请求aeecsstoken和idtoken的时候允许将用户的信息附加到idtoken里面，这样会用就不用重新请求用户端点（userinfo）请求用户信息
                    //flase情况下idtoken里面包含 id和用户姓名什么的基本信息，ture会额外包涵电话邮箱之类的东西
                    AlwaysIncludeUserClaimsInIdToken=true,

                    AccessTokenLifetime=60,//设置过期时间
                    
                    AllowOfflineAccess = true,
                    AllowedScopes = {
                        "api1" ,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess
                    }
                },

                // SPA client using implicit flow
                new Client
                {
                    ClientId = "angular-client",
                    ClientName = "angular Client",
                    ClientUri = "http://localhost:4200",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireClientSecret=true,
                    AccessTokenLifetime=60*5,

                    RedirectUris =
                    {
                        "http://localhost:4200/signin-oidc",
                        "http://localhost:4200/redirect-silentrenew"
                    },

                    PostLogoutRedirectUris = { "http://localhost:4200" },
                    AllowedCorsOrigins = { "http://localhost:4200" },

                    AllowedScopes = { "openid", "profile", "api1" }
                },

                 // mvc, hybrid flow
                new Client
                {
                    ClientId = "hybrid client",
                    ClientName = "ASP.NET Core Hybrid 客户端",
                    ClientSecrets = {new Secret("hybrid secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Hybrid,

                    AccessTokenType = AccessTokenType.Reference,

                    RedirectUris =
                    {
                        "http://localhost:7000/signin-oidc"
                    },

                    PostLogoutRedirectUris =
                    {
                        "http://localhost:7000/signout-callback-oidc"
                    },

                    AllowOfflineAccess = true,

                    AlwaysIncludeUserClaimsInIdToken = true,

                    AllowedScopes =
                    {
                        "api1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                    }
                }


            };
        }
    }
}