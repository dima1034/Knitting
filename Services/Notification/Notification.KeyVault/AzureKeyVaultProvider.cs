using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using InfrastructureContracts;
using Microsoft.Extensions.Configuration;

namespace Notification.KeyVault
{
    public class AzureKeyVaultProvider : IKeyValueProvider
    {
        private static AzureKeyVault _azureKeyVault;

        public AzureKeyVaultProvider()
        {
            var pathToBin = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly()
                        .Location);

            var builtConfig = new ConfigurationBuilder().SetBasePath(pathToBin)
                                                        .AddJsonFile(
                                                             "appsettings.json",
                                                             optional: false,
                                                             reloadOnChange: true)
                                                        .Build();

            IConfigurationSection keyVaultSection = builtConfig.GetSection("KeyVault");

            _azureKeyVault = new AzureKeyVault(
                keyVaultSection["baseUri"],
                keyVaultSection["appClientId"],
                keyVaultSection["appClientSecret"]);
        }

        public async Task<string> GetValue(string key) => await _azureKeyVault.GetCachedSecret(key);
    }
}