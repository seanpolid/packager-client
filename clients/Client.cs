using PackagerClient.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PackagerClient.clients
{
    internal class Client
    {
        private static readonly HttpClient httpClient = new();
        private static readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        public static void SendPackageInfo(string server, string containerName, string path)
        {
            PackageInfoDTO packageInfo = new()
            {
                ContainerName = containerName,
                RepoPath = path
            };

            HttpRequestMessage request = new()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://" + server + "/package"),
                Content = JsonContent.Create<PackageInfoDTO>(packageInfo, null, jsonSerializerOptions)
            };

            HttpResponseMessage response = httpClient.Send(request);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Could not successfully communicate with package server.");
            }
            else
            {
                Console.WriteLine("Path: " + response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
