using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MauiTest1.Models;
using Newtonsoft.Json;

namespace MauiTest1.Services
{
    public class ApiService
    {
        public static async Task<List<StudentModel>?> GetStudents()
        {
            try
            {
                var httpClientHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                };

                var httpClient = new HttpClient(httpClientHandler);
                var apiUrl = "https://10.0.2.2:7187/api/Student";
                var response = await httpClient.GetStringAsync(apiUrl);

                var students = JsonConvert.DeserializeObject<List<StudentModel>>(response);

                return students;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
