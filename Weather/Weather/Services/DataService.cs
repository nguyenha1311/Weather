using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Weather.Models;



namespace Weather.Services
{
    public class DataService : IDataService
    {
        public DataService() {}

        /// <inheritdoc />
        public async Task<ServiceResult> GetDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(queryString);

            ServiceResult serviceResult = new ServiceResult();

            if(response != null) {
                if(response.IsSuccessStatusCode) {
                    string json = response.Content.ReadAsStringAsync().Result;
                    dynamic data = JsonConvert.DeserializeObject(json);
                    serviceResult.Results = data;
                    serviceResult.Errors = string.Empty;
                } else {
                    serviceResult.Errors = "No weather info is found. Please try again later.";
                    serviceResult.Results = null;
                    Debug.WriteLine("We could not get the weather info. The request returned this status code: " + response.StatusCode);
                }
            } else {
                serviceResult.Errors = "No weather info is found. Please try again later.";
                serviceResult.Results = null;
                Debug.WriteLine("There is no Http response message.");
            }

            return serviceResult;
        }
        
    }
}
