﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Identity.Test.LabInfrastructure
{
    public struct UserQuery
    {
        public UserType? UserType { get; set; }
        public MFA? MFA { get; set; }
        public ProtectionPolicy? ProtectionPolicy { get; set; }
        public HomeDomain? HomeDomain { get; set; }
        public HomeUPN? HomeUPN { get; set; }
        public B2CIdentityProvider? B2CIdentityProvider { get; set; }
        public FederationProvider? FederationProvider { get; set; } //Requires userType to be set to federated
        public AzureEnvironment? AzureEnvironment { get; set; }
        public SignInAudience? SignInAudience { get; set; }
        public AppPlatform? AppPlatform { get; set; }
        public PublicClient? PublicClient { get; set; }

        /// <summary>
        /// Ask for a specific user from the lab. No other parameters will be considered.
        /// </summary>
        public string Upn { get; set; }

        public static UserQuery PublicAadUserQuery => new()
        {
            Upn = "idlab1@msidlab4.onmicrosoft.com"            
        };

        public static UserQuery PublicAadUser2Query => new()
        {
            Upn = "idlab@msidlab4.onmicrosoft.com"
        };
        
        public static UserQuery PublicAadCaeUserQuery => new()
        {
            Upn = "idlabcae@msidlab4.onmicrosoft.com"
        };

        public static UserQuery MsaUserQuery => new()
        {
            UserType = LabInfrastructure.UserType.MSA
        };

        public static UserQuery B2CLocalAccountUserQuery => new()
        {
            UserType = LabInfrastructure.UserType.B2C,
            B2CIdentityProvider = LabInfrastructure.B2CIdentityProvider.Local
        };

        public static UserQuery B2CFacebookUserQuery => new()
        {
            UserType = LabInfrastructure.UserType.B2C,
            B2CIdentityProvider = LabInfrastructure.B2CIdentityProvider.Facebook
        };

        public static UserQuery B2CGoogleUserQuery => new()
        {
            UserType = LabInfrastructure.UserType.B2C,
            B2CIdentityProvider = LabInfrastructure.B2CIdentityProvider.Google
        };

        public static UserQuery B2CMSAUserQuery => new()
        {
            UserType = LabInfrastructure.UserType.B2C,
            B2CIdentityProvider = LabInfrastructure.B2CIdentityProvider.MSA
        };

        public static UserQuery ArlingtonUserQuery => new()
        {
            UserType = LabInfrastructure.UserType.Cloud,
            AzureEnvironment = LabInfrastructure.AzureEnvironment.azureusgovernment
        };

        public static UserQuery HybridSpaUserQuery => new()
        {
            UserType = LabInfrastructure.UserType.Cloud,
            AppPlatform = LabInfrastructure.AppPlatform.spa,
            PublicClient = LabInfrastructure.PublicClient.no,
            SignInAudience = LabInfrastructure.SignInAudience.AzureAdMyOrg

        };
    }
}
