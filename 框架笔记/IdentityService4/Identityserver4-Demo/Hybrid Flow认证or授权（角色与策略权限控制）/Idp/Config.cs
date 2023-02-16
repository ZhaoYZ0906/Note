// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;
using IdentityModel;

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
                new IdentityResources.Address(),
                new IdentityResources.Phone(),
                new IdentityResources.Email(),
                //roles资源名称/scope名称，下面客户请求的时候用（类似于api1）
                //角色 显示名称随便写
                //new List<string>{ "role"} claimtype指具体资源的名字  比如：new Claim(JwtClaimTypes.Role,"wbb")
                new IdentityResource("roles","角色",new List<string>{ JwtClaimTypes.Role}),
                new IdentityResource("locations","地址",new List<string>{ "location"})
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("api1", "My API #1")//,new List<string>{"location" })
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

                // wpf client, password grant
                new Client
                {
                    ClientId = "wpf client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("wpf secrect".Sha256())
                    },
                    AllowedScopes = {
                        "api1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.Profile }
                },

                // mvc client, authorization code
                new Client
                {
                    ClientId = "mvc client",
                    ClientName = "ASP.NET Core MVC Client",

                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                    ClientSecrets = { new Secret("mvc secret".Sha256()) },

                    RedirectUris = { "http://localhost:5002/signin-oidc" },

                    FrontChannelLogoutUri = "http://localhost:5002/signout-oidc",
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                    AlwaysIncludeUserClaimsInIdToken = true,

                    AllowOfflineAccess = true, // offline_access
                    AccessTokenLifetime = 60, // 60 seconds

                    AllowedScopes =
                    {
                        "api1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },

                // angular, implicit flow
                new Client
                {
                    ClientId = "angular-client",
                    ClientName =  "Angular SPA 客户端",
                    ClientUri = "http://localhost:4200",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = true,
                    AccessTokenLifetime = 60 * 5,

                    RedirectUris =
                    {
                        "http://localhost:4200/signin-oidc",
                        "http://localhost:4200/redirect-silentrenew"
                    },

                    PostLogoutRedirectUris =
                    {
                        "http://localhost:4200"
                    },

                    AllowedCorsOrigins =
                    {
                        "http://localhost:4200"
                    },

                    AllowedScopes = {
                        "api1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },

                //hybrid
                new Client{
                    ClientId="hybrid client",
                    ClientName="hybrid client",
                    AllowedGrantTypes=GrantTypes.Hybrid,
                   
                    ClientSecrets={ new Secret ("hybrid secrest".Sha256()) },

                    RedirectUris={
                        "http://localhost:7000/signin-oidc"
                    },

                    PostLogoutRedirectUris={
                       " http://localhost:7000/signout-callback-oidc "
                    },

                    AllowOfflineAccess=true,

                    AlwaysIncludeUserClaimsInIdToken=true,

                    AllowedScopes={
                        "api1",
                        "roles",
                        "locations",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                    
                }
            };
        }
    }
}