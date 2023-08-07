using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace SecretsManager.App {
    internal class Program {
        static async Task Main(string[] args) {

            var secretsManagerClient = new AmazonSecretsManagerClient();

            var listSecretVersionsRequest = new ListSecretVersionIdsRequest {
                SecretId = "ApiKey",
                IncludeDeprecated = true
            };

            var versionResponse = await secretsManagerClient.ListSecretVersionIdsAsync(listSecretVersionsRequest);

            var request = new GetSecretValueRequest {
                SecretId = "ApiKey",
                VersionId = "600eff40-5fc5-4bdb-9e75-d2de1f7d0a81"
                //VersionStage = "AWSCURRENT"
            };

            var response = await secretsManagerClient.GetSecretValueAsync(request);

            Console.WriteLine(response.SecretString);

            var describeSecretRequest = new DescribeSecretRequest {
                SecretId = "ApiKey"
            };

            var describeResposne = await secretsManagerClient.DescribeSecretAsync(describeSecretRequest);

            Console.WriteLine(describeResposne.ToString());
        }
    }
}