using PackagerClient.clients;

namespace PackagerClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? server = Environment.GetEnvironmentVariable("PACKAGE_SERVER");
            if (server == null)
            {
                Console.WriteLine("Could not identify the packager server. Please ensure the environment variable PACKAGE_SERVER is set.");
                return;
            }

            string? containerName = Environment.GetEnvironmentVariable("CONTAINER_NAME");
            if (containerName == null)
            {
                Console.WriteLine("Could not identify the name of the container. Please ensure the environment variable CONTAINER_NAME is set.");
                return;
            }

            string path = Directory.GetCurrentDirectory();
            Client.SendPackageInfo(server, containerName, path);
        }
    }
}