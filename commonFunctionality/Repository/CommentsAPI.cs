using commonFunctionality.Models;
using Newtonsoft.Json;

namespace commonFunctionality.Repository
{
    public static class CommentsAPI
    {
        public static async Task<List<Comments>> GetComments()
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
                client.DefaultRequestHeaders.Accept.Clear();

                var response = await client.GetAsync("comments");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var comments = JsonConvert.DeserializeObject<List<Comments>>(result);
                    return comments;
                }
                else
                {
                    return null;
                }
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}