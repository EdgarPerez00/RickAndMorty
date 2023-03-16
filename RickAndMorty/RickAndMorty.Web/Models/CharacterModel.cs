using RickAndMorty.Core;

namespace RickAndMorty.Web.Models
{
    public class CharacterModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public string Species { get; set; }

        public string Type { get; set; }

        public string Gender { get; set; }

        public OriginLocation Origin { get; set; }

        public Location  Location { get; set; }

        public string Image { get; set; }

        public List<string> Episode { get; set; }

        public string Url { get; set; }

       public DateTime Created { get; set; }
    }
}
