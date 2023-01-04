using CovoitEco.APP.Model.Models;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;

namespace CovoitEco.APP.Service.Utilisateur.Queries
{
    public class UtilisateurQueriesService : IUtilisateurQueriesService
    {
        #region Fields

        private const int MaxRetries = 3;
        private static readonly Random Random = new Random();
        private readonly HttpClient _httpClient;
        private readonly AsyncRetryPolicy<UserProfileVm> _retrypolicy;
        #endregion

        #region Constructor

        public UtilisateurQueriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _retrypolicy = Policy<UserProfileVm>.Handle<HttpRequestException>().RetryAsync(MaxRetries);
        }

        #endregion

        public async Task<UserProfileVm> GetUtilisateurPofile(int idUser)
        {
            return await _retrypolicy.ExecuteAsync(async () =>
            {
                if (Random.Next(1, 40) == 1)
                    throw new HttpRequestException("This is a fake request exception");
                var httpResponse = await _httpClient.GetAsync("https://localhost:7197/api/User/GetUserProfile?id=" + idUser);
                if (!httpResponse.IsSuccessStatusCode) throw new Exception();
                var content = await httpResponse.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<UserProfileVm>(content);
                return users;
            });
        }
    }
}
