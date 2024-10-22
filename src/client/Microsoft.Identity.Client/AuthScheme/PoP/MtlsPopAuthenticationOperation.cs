﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.Identity.Client.AppConfig;
using Microsoft.Identity.Client.Cache.Items;
using Microsoft.Identity.Client.Internal;
using Microsoft.Identity.Client.OAuth2;
using Microsoft.Identity.Client.Utils;
#if SUPPORTS_SYSTEM_TEXT_JSON
using JObject = System.Text.Json.Nodes.JsonObject;
using JToken = System.Text.Json.Nodes.JsonNode;
#else
using Microsoft.Identity.Json;
using Microsoft.Identity.Json.Linq;
#endif

namespace Microsoft.Identity.Client.AuthScheme.PoP
{
    internal class MtlsPopAuthenticationOperation : IAuthenticationOperation
    {
        private readonly X509Certificate2 _mtlsCert;

        public MtlsPopAuthenticationOperation(X509Certificate2 mtlsCert)
        {
            _mtlsCert = mtlsCert;
            KeyId = mtlsCert.Thumbprint;
        }

        public int TelemetryTokenType => (int)TokenType.Pop;

        public string AuthorizationHeaderPrefix => Constants.MtlsPoPAuthHeaderPrefix;

        public string AccessTokenType => Constants.MtlsPoPTokenType;

        /// <summary>
        /// For PoP, we chose to use the base64(jwk_thumbprint)
        /// </summary>
        public string KeyId { get; }

        public IReadOnlyDictionary<string, string> GetTokenRequestParams()
        {
            return CollectionHelpers.GetEmptyDictionary<string, string>();
        }

        public void FormatResult(AuthenticationResult authenticationResult)
        {
            var header = new JObject();
            header[JsonWebTokenConstants.KeyId] = KeyId;
            header[JsonWebTokenConstants.Type] = Constants.MtlsPoPTokenType;

            //authenticationResult.Certificate = _mtlsCert;
        }

        private JObject CreateBody(string accessToken)
        {
            return null;
        }

        /// <summary>
        /// A key ID that uniquely describes a public / private key pair. While KeyID is not normally
        /// strict, AAD support for PoP requires that we use the base64 encoded JWK thumbprint, as described by 
        /// https://tools.ietf.org/html/rfc7638
        /// </summary>
        private static byte[] ComputeThumbprint(string canonicalJwk)
        {
            using (SHA256 hash = SHA256.Create())
            {
                return hash.ComputeHash(Encoding.UTF8.GetBytes(canonicalJwk));
            }
        }
    }
}
