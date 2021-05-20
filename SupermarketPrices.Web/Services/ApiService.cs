using Newtonsoft.Json;
using SupermarketPrices.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketPrices.Web.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductViewModel>> GetProductsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ProductViewModel>>($"/api/Product");

            return response;
        }

        public async Task<List<SupermarketViewModel>> GetSupermarketsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<SupermarketViewModel>>($"/api/Supermarket");

            return response;
        }

        public async Task<ProductViewModel> CreateProduct(ProductViewModel product)
        {

            var request = new HttpRequestMessage(HttpMethod.Post, new Uri($"/api/Product", UriKind.RelativeOrAbsolute));

            request.Content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            var json = await response.Content.ReadAsStringAsync();
            var retorno = JsonConvert.DeserializeObject<ProductViewModel>(json);
            

            return retorno;
        }

        public async Task<SupermarketViewModel> CreateSupermarket(SupermarketViewModel supermarket)
        {

            var request = new HttpRequestMessage(HttpMethod.Post, new Uri($"/api/Supermarket", UriKind.RelativeOrAbsolute));

            request.Content = new StringContent(JsonConvert.SerializeObject(supermarket), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            var json = await response.Content.ReadAsStringAsync();
            var retorno = JsonConvert.DeserializeObject<SupermarketViewModel>(json);


            return retorno;
        }

        public async Task<SupermarketProductViewModel> RegistrySupermarketProduct(SupermarketProductViewModel supermarketProduct)
        {

            var request = new HttpRequestMessage(HttpMethod.Post, new Uri($"/api/SupermarketProduct", UriKind.RelativeOrAbsolute));

            request.Content = new StringContent(JsonConvert.SerializeObject(supermarketProduct), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            var json = await response.Content.ReadAsStringAsync();
            var retorno = JsonConvert.DeserializeObject<SupermarketProductViewModel>(json);


            return retorno;
        }

        public async Task<SupermarketViewModel> GetSupermarketsAsync(int supermarketId)
        {
            var response = await _httpClient.GetFromJsonAsync<SupermarketViewModel>($"/api/SupermarketProduct/{supermarketId}");


            return response;
        }


    }
}
