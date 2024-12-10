using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;


namespace Cities.Tools
{
    public class Call
    {
        private readonly HttpClient _client;

        public Call(HttpClient client)
        {
            _client = client;
        }


        /// <summary>
        /// GetCall permet de récupérer des données depuis une API
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public T? GetDataFromAPI<T>()
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://quizmania-api.p.rapidapi.com/trivia-filtered?category=geography&difficulty=easy"),
                    Headers =
                    {
                        { "x-rapidapi-key", "1315f88c8cmsh2fa4664a09697b4p10c882jsn0f76df775734" },
                        { "x-rapidapi-host", "quizmania-api.p.rapidapi.com" },
                    },
                };

                var response = _client.SendAsync(request).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();

                // Lire le contenu de la réponse
                var body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                // Désérialiser la réponse JSON en utilisant le type spécifié
                return JsonSerializer.Deserialize<T>(body, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Gérer les majuscules/minuscules dans les noms de propriétés
                });
            }

            catch (Exception e)
            {
                throw new CallException("Erreur lors de la récupération des données depuis l'API", e);
            }
        }
            
    }

}

