namespace PokemonTutorial.Models
{
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Owner> Owner { get; set; }   

    }
}
