This is a sample app for my blog post at the link below.

[https://duongnt.com/integrate-sso-asp-net-core](https://duongnt.com/integrate-sso-asp-net-core)

# Usage

Update `appsettings.json` file with details of your identity provider. Please see [this](https://duongnt.com/saml-setup-okta) link on how to use setup and use OKTA.
```
"Authentication": {
    "Saml": {
      "EntityId": "https://localhost:5001/Saml2",
      "IdentityProviderIssuer": "<identity provider entity id>",
      "MetadataUrl": "<link to metadata file on identity provider>"
    }
}
```

Start the app with the following command.
```
dotnet run
```

Open the app at `https://localhost:5001` and access `Secret` page to trigger authentication.

# License

MIT License

https://opensource.org/licenses/MIT