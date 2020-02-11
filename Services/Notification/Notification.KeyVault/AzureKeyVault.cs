using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Notification.KeyVault
{
    internal class AzureKeyVault
    {
        public AzureKeyVault(string baseUri, string clientId, string clientSecret)
        {
            BaseUri      = baseUri;
            ClientId     = clientId;
            ClientSecret = clientSecret;
        }

        public AzureKeyVault(string baseUri, KeyVaultClient keyVaultClient)
        {
            BaseUri         = baseUri;
            _keyVaultClient = keyVaultClient;
        }

        public static string BaseUri { get; private set; }

        public static string ClientId { get; private set; }

        public static string ClientSecret { get; private set; }

        private static KeyVaultClient _keyVaultClient = null;

        private static readonly Dictionary<string, string> SecretsCache = new Dictionary<string, string>();

        public async Task<string> GetCachedSecret(string secretName)
        {
            if (SecretsCache.ContainsKey(secretName))
            {
                return SecretsCache.ContainsKey(secretName)
                    ? SecretsCache[secretName]
                    : string.Empty;
            }

            if (_keyVaultClient is null)
            {
                _keyVaultClient = new KeyVaultClient(
                    async (authority, resource, scope) =>
                    {
                        var                  authContext = new AuthenticationContext(authority);
                        var                  credential  = new ClientCredential(ClientId, ClientSecret);
                        AuthenticationResult result      = await authContext.AcquireTokenAsync(resource, credential);

                        if (result == null)
                        {
                            throw new InvalidOperationException("Failed to retrieve JWT token");
                        }

                        return result.AccessToken;
                    });
            }

            var secretBundle = await _keyVaultClient.GetSecretAsync(BaseUri, secretName)
                                                    .ConfigureAwait(false);

            SecretsCache.Add(secretName, secretBundle.Value);

            return SecretsCache[secretName];
        }
    }
}