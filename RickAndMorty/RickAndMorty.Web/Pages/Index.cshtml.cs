using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RickAndMorty.Core;
using RickAndMorty.Web.Models;

namespace RickAndMorty.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public List<CharacterModel> Characters { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;

        }

        public async Task OnGet()
        {
            using (var client = _httpClientFactory.CreateClient("RickAndMortyWeb"))
            {
                var response = await client.GetAsync("character/1,24,33,183,217,218");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var chars = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Character>>(content);

                    Characters = chars.Select(x => new CharacterModel
                    {
                        Name = x.Name,
                        Status  = x.Status,
                        Species = x.Species,
                        Type = x.Type,
                        Gender  = x.Gender,
                        Origin  = x.Origin,
                       Image    = x.Image,
                        Episode = x.Episode,
                        Url = x.Url,
                        Created = x.Created,
                        Id  = x.Id,
                       // Location = GetLocation(x.Location.Id).Result,

                    }).ToList();

                }



            }


            foreach(var character in Characters) {

                character.Location = character.Origin == null ? null : await GetLocation(character);
            
            }



        }

        private async Task<Location> GetLocation(CharacterModel character)
        {
            using (var client = _httpClientFactory.CreateClient("RickAndMortyWeb"))
            {

                string url = character.Origin.Url.Replace(client.BaseAddress.ToString(), string.Empty);


                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var location = Newtonsoft.Json.JsonConvert.DeserializeObject<Location>(content);

                    return location;

                }
                else
                {
                    throw new InvalidOperationException();
                }

                
            }


        }

    }
}