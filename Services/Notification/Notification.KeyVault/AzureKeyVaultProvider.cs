
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Notification.KeyVault
{
    public class AzureKeyVaultProvider
    {
        private static AzureKeyVault         _azureKeyVault;
        private static IConfigurationSection _keyVaultSection;

        public AzureKeyVaultProvider()
        {
            IConfigurationRoot builtConfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                                       .AddJsonFile(
                                                                            "appsettings.json",
                                                                            optional: true,
                                                                            reloadOnChange: true)
                                                                       .Build();

            _azureKeyVault = new AzureKeyVault(
                _keyVaultSection["baseUri"],
                _keyVaultSection["appClientId"],
                _keyVaultSection["appClientSecret"]);

            _keyVaultSection = builtConfig.GetSection("KeyVault");
        }

        public async Task<string> GetValue(string key) => await _azureKeyVault.GetCachedSecret(key);
    }
}