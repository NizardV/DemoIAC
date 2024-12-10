namespace DemoIAC.Server.Models
{
    public class Score
    {
        public int Id { get; set; } // Clé primaire
        public string? UserName { get; set; } // Nom de l'utilisateur
        public int Points { get; set; } // Score
    }
}
