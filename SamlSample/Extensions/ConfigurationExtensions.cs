using Microsoft.Extensions.Configuration;
using Sustainsys.Saml2;
using Sustainsys.Saml2.AspNetCore2;
using Sustainsys.Saml2.Metadata;
using System;

namespace SamlSample.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void Saml(this IConfiguration config, Saml2Options options)
        {
            var samlConfig = config.GetSection("Authentication:Saml").Get<SamlConfiguration>();

            options.SPOptions.PublicOrigin = samlConfig.EntityId.GetRoot();
            options.SPOptions.EntityId = new EntityId(samlConfig.EntityId);
            options.SPOptions.ReturnUrl = new Uri("/", UriKind.Relative);

            var idp = new IdentityProvider(new EntityId(samlConfig.IdentityProviderIssuer), options.SPOptions)
            {
                MetadataLocation = samlConfig.MetadataUrl,
                AllowUnsolicitedAuthnResponse = true
            };

            options.IdentityProviders.Add(idp);
        }

        private static Uri GetRoot(this string uri) => new Uri(new Uri(uri).GetLeftPart(UriPartial.Authority));
    }
}
