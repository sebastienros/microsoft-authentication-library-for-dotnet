﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Microsoft.Identity.Client
{
    /// <summary>
    /// In MSAL.NET 1.x, was representing a User. From MSAL 2.x use <see cref="IAccount"/> which represents an account
    /// (a user has several accounts). See https://aka.ms/msal-net-2-released for more details.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Use IAccount instead (See https://aka.ms/msal-net-2-released)")]
    public interface IUser
    {
        /// <summary>
        /// In MSAL.NET 1.x was the displayable ID of a user. From MSAL 2.x use the <see cref="IAccount.Username"/> of an account.
        /// See https://aka.ms/msal-net-2-released for more details
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Obsolete("Use IAccount.Username instead (See https://aka.ms/msal-net-2-released)", true)]
        string DisplayableId { get; }

        /// <summary>
        /// In MSAL.NET 1.x was the name of the user (which was not very useful as the concatenation of 
        /// some claims). From MSAL 2.x rather use <see cref="IAccount.Username"/>. See https://aka.ms/msal-net-2-released for more details.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Obsolete("Use IAccount.Username instead (See https://aka.ms/msal-net-2-released)", true)]
        string Name { get; }

        /// <summary>
        /// In MSAL.NET 1.x was the URL of the identity provider (e.g. https://login.microsoftonline.com/tenantId).
        /// From MSAL.NET 2.x use <see cref="IAccount.Environment"/> which retrieves the host only (e.g. login.microsoftonline.com).
        /// See https://aka.ms/msal-net-2-released for more details.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Obsolete("Use IAccount.Environment instead to get the Identity Provider host (See https://aka.ms/msal-net-2-released)", true)]
        string IdentityProvider { get; }

        /// <summary>
        /// In MSAL.NET 1.x was an identifier for the user in the guest tenant.
        /// From MSAL.NET 2.x, use <see cref="IAccount.HomeAccountId"/><see cref="AccountId.Identifier"/> to get
        /// the user identifier (globally unique accross tenants). See https://aka.ms/msal-net-2-released for more details.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Obsolete("Use IAccount.HomeAccountId.Identifier instead to get the user identifier (See https://aka.ms/msal-net-2-released)", true)]
        string Identifier { get; }
    }

    /// <Summary>
    /// Interface defining common API methods and properties. Both <see cref="T:PublicClientApplication"/> and <see cref="T:ConfidentialClientApplication"/> 
    /// extend this class. For details see https://aka.ms/msal-net-client-applications
    /// </Summary>
    public partial interface IClientApplicationBase
    {
        /// <summary>
        /// In MSAL 1.x returned an enumeration of <see cref="IUser"/>. From MSAL 2.x, use <see cref="GetAccountsAsync"/> instead.
        /// See https://aka.ms/msal-net-2-released for more details.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Obsolete("Use GetAccountsAsync instead (See https://aka.ms/msal-net-2-released)", true)]
        IEnumerable<IUser> Users { get; }

        /// <summary>
        /// In MSAL 1.x, return a user from its identifier. From MSAL 2.x, use <see cref="GetAccountsAsync"/> instead.
        /// See https://aka.ms/msal-net-2-released for more details.
        /// </summary>
        /// <param name="identifier">Identifier of the user to retrieve</param>
        /// <returns>the user in the cache with the identifier passed as an argument</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use GetAccountAsync instead and pass IAccount.HomeAccountId.Identifier (See https://aka.ms/msal-net-2-released)", true)]
        IUser GetUser(string identifier);

        /// <summary>
        /// In MSAL 1.x removed a user from the cache. From MSAL 2.x, use <see cref="RemoveAsync(IAccount)"/> instead.
        /// See https://aka.ms/msal-net-2-released for more details.
        /// </summary>
        /// <param name="user">User to remove from the cache</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use RemoveAccountAsync instead (See https://aka.ms/msal-net-2-released)", true)]
        void Remove(IUser user);

        /// <summary>
        /// Identifier of the component (libraries/SDK) consuming MSAL.NET. 
        /// This will allow for disambiguation between MSAL usage by the app vs MSAL usage by component libraries.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use WithComponent on AbstractApplicationBuilder<T> to configure this instead.  See https://aka.ms/msal-net-application-configuration", true)]
        string Component { get; set; }

        /// <summary>
        /// Sets or Gets a custom query parameters that may be sent to the STS for dogfood testing or debugging. This is a string of segments
        /// of the form <c>key=value</c> separated by an ampersand character.
        /// Unless requested otherwise, this parameter should not be set by application developers as it may have adverse effect on the application.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use ExtraQueryParameters on each call instead.  See https://aka.ms/msal-net-application-configuration", true)]
        string SliceParameters { get; set; }

        /// <summary>
        /// Gets a boolean value telling the application if the authority needs to be verified against a list of known authorities. The default
        /// value is <c>true</c>. It should currently be set to <c>false</c> for Azure AD B2C authorities as those are customer specific 
        /// (a list of known B2C authorities cannot be maintained by MSAL.NET)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Can be set on AbstractApplicationBuilder<T>.WithAuthority as needed.  See https://aka.ms/msal-net-application-configuration", true)]
        bool ValidateAuthority { get; }

#if !DESKTOP && !NET_CORE
#pragma warning disable CS1574 // XML comment has cref attribute that could not be resolved
#endif
        /// <summary>
        /// The redirect URI (also known as Reply URI or Reply URL), is the URI at which Azure AD will contact back the application with the tokens. 
        /// This redirect URI needs to be registered in the app registration (https://aka.ms/msal-net-register-app)
        /// In MSAL.NET, <see cref="T:PublicClientApplication"/> define the following default RedirectUri values:
        /// <list type="bullet">
        /// <item><description><c>urn:ietf:wg:oauth:2.0:oob</c> for desktop (.NET Framework and .NET Core) applications</description></item>
        /// <item><description><c>msal{ClientId}</c> for Xamarin iOS and Xamarin Android (as this will be used by the system web browser by default on these
        /// platforms to call back the application)
        /// </description></item>
        /// </list>
        /// These default URIs could change in the future.
        /// In <see cref="Microsoft.Identity.Client.ConfidentialClientApplication"/>, this can be the URL of the Web application / Web API.
        /// </summary>
        /// <remarks>This is especially important when you deploy an application that you have initially tested locally; 
        /// you then need to add the reply URL of the deployed application in the application registration portal.
        /// </remarks>
        [Obsolete("Should be set using AbstractApplicationBuilder<T>.WithRedirectUri and can be viewed with ClientApplicationBase.AppConfig.RedirectUri. See https://aka.ms/msal-net-application-configuration", true)]
        string RedirectUri { get; set; }
#pragma warning restore CS1574 // XML comment has cref attribute that could not be resolved

    }

    /// <Summary>
    /// Abstract class containing common API methods and properties. Both <see cref="T:PublicClientApplication"/> and <see cref="T:ConfidentialClientApplication"/> 
    /// extend this class. For details see https://aka.ms/msal-net-client-applications
    /// </Summary>
    public partial class ClientApplicationBase
    {
        /// <summary>
        /// In MSAL 1.x returned an enumeration of <see cref="IUser"/>. From MSAL 2.x, use <see cref="GetAccountsAsync"/> instead.
        /// See https://aka.ms/msal-net-2-released for more details.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Obsolete("Use GetAccountsAsync instead (See https://aka.ms/msal-net-2-released)", true)]
        public IEnumerable<IUser> Users { get { throw new NotImplementedException(); } }

        /// <summary>
        /// In MSAL 1.x, return a user from its identifier. From MSAL 2.x, use <see cref="GetAccountsAsync"/> instead.
        /// See https://aka.ms/msal-net-2-released for more details.
        /// </summary>
        /// <param name="identifier">Identifier of the user to retrieve</param>
        /// <returns>the user in the cache with the identifier passed as an argument</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use GetAccountAsync instead and pass IAccount.HomeAccountId.Identifier (See https://aka.ms/msal-net-2-released)", true)]
        public IUser GetUser(string identifier) { throw new NotImplementedException(); }

        /// <summary>
        /// In MSAL 1.x removed a user from the cache. From MSAL 2.x, use <see cref="RemoveAsync(IAccount)"/> instead.
        /// See https://aka.ms/msal-net-2-released for more details.
        /// </summary>
        /// <param name="user">User to remove from the cache</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use RemoveAccountAsync instead (See https://aka.ms/msal-net-2-released)", true)]
        public void Remove(IUser user) { throw new NotImplementedException(); }

        /// <summary>
        /// Identifier of the component (libraries/SDK) consuming MSAL.NET. 
        /// This will allow for disambiguation between MSAL usage by the app vs MSAL usage by component libraries.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use WithComponent on AbstractApplicationBuilder<T> to configure this instead. See https://aka.ms/msal-net-application-configuration", true)]
        public string Component { get; set; }

        /// <summary>
        /// Sets or Gets a custom query parameters that may be sent to the STS for dogfood testing or debugging. This is a string of segments
        /// of the form <c>key=value</c> separated by an ampersand character.
        /// Unless requested otherwise, this parameter should not be set by application developers as it may have adverse effect on the application.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use ExtraQueryParameters on each call instead. See https://aka.ms/msal-net-application-configuration", true)]
        public string SliceParameters { get; set; }

        /// <summary>
        /// Gets/sets a boolean value telling the application if the authority needs to be verified against a list of known authorities. The default
        /// value is <c>true</c>. It should currently be set to <c>false</c> for Azure AD B2C authorities as those are customer specific
        /// (a list of known B2C authorities cannot be maintained by MSAL.NET). This property can be set just after the construction of the application
        /// and before an operation acquiring a token or interacting with the STS.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Can be set on AbstractApplicationBuilder<T>.WithAuthority as needed. See https://aka.ms/msal-net-application-configuration", true)]
        public bool ValidateAuthority { get; set; }

#pragma warning disable CS1574 // XML comment has cref attribute that could not be resolved
        /// <summary>
        /// The redirect URI (also known as Reply URI or Reply URL), is the URI at which Azure AD will contact back the application with the tokens.
        /// This redirect URI needs to be registered in the app registration (https://aka.ms/msal-net-register-app).
        /// In MSAL.NET, <see cref="T:PublicClientApplication"/> define the following default RedirectUri values:
        /// <list type="bullet">
        /// <item><description><c>urn:ietf:wg:oauth:2.0:oob</c> for desktop (.NET Framework and .NET Core) applications</description></item>
        /// <item><description><c>msal{ClientId}</c> for Xamarin iOS and Xamarin Android (as this will be used by the system web browser by default on these
        /// platforms to call back the application)
        /// </description></item>
        /// </list>
        /// These default URIs could change in the future.
        /// In <see cref="Microsoft.Identity.Client.ConfidentialClientApplication"/>, this can be the URL of the Web application / Web API.
        /// </summary>
        /// <remarks>This is especially important when you deploy an application that you have initially tested locally;
        /// you then need to add the reply URL of the deployed application in the application registration portal</remarks>
        [Obsolete("Should be set using AbstractApplicationBuilder<T>.WithRedirectUri and can be viewed with ClientApplicationBase.AppConfig.RedirectUri. See https://aka.ms/msal-net-application-configuration", true)]
        public string RedirectUri { get; set; }
#pragma warning restore CS1574 // XML comment has cref attribute that could not be resolved
    }

    public partial class AuthenticationResult
    {
        /// <summary>
        /// In MSAL.NET 1.x, returned the user who signed in to get the authentication result. From MSAL 2.x
        /// rather use <see cref="Account"/> instead. See https://aka.ms/msal-net-2-released for more details.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Obsolete("Use Account instead (See https://aka.ms/msal-net-2-released)", true)]
        public IUser User { get { throw new NotImplementedException(); } }
    }

    public partial class TokenCacheNotificationArgs
    {
        /// <summary>
        /// In MSAL.NET 1.x, returned the user who signed in to get the authentication result. From MSAL 2.x
        /// rather use <see cref="Account"/> instead. See https://aka.ms/msal-net-2-released for more details.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Obsolete("Use Account instead (See https://aka.ms/msal-net-2-released)", true)]
        public IUser User { get { throw new NotImplementedException(); } }
    }

    /// <Summary>
    /// Abstract class containing common API methods and properties. 
    /// For details see https://aka.ms/msal-net-client-applications
    /// </Summary>
    public partial class PublicClientApplication
    {
#if DESKTOP || NET_CORE
#pragma warning disable 1998
        /// <summary>
        /// In ADAL.NET, acquires security token from the authority, using the username/password authentication, 
        /// with the password sent in clear. 
        /// In MSAL 2.x, only the method that accepts a SecureString parameter is supported.
        /// 
        /// See https://aka.ms/msal-net-up for more details.
        /// </summary>
        /// <param name="scopes">Scopes requested to access a protected API</param>
        /// <param name="username">Identifier of the user application requests token on behalf.</param>
        /// <param name="password">User password.</param>
        /// <returns>Authentication result containing a token for the requested scopes and account</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use overload with SecureString instead (See https://aka.ms/msal-net-up)", true)]
        public async Task<AuthenticationResult> AcquireTokenByUsernamePasswordAsync(IEnumerable<string> scopes, string username, string password)
        {
            { throw new NotImplementedException(); }
        }
#pragma warning restore 1998
#endif
    }
}
