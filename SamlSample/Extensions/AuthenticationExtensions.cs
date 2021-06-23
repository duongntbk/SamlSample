using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Sustainsys.Saml2.AspNetCore2;
using System;

namespace SamlSample.Extensions
{
    public static class AuthenticationExtensions
    {
        public static AuthenticationBuilder AddSamlAuthentication(this AuthenticationBuilder auth,
            Action<Saml2Options> configureOptions) =>
            auth
                .AddCookie(AuthenticationScheme.Saml, options => {
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.SameSite = SameSiteMode.None;
                    options.Cookie.Path = "/";
                })
                .AddSaml2(configureOptions);
    }
}
