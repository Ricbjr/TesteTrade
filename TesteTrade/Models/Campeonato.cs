namespace MeuCampeonato.Models
{
    public class Campeonato
    {
        public int IdCampeonato {get;set;}
        public string? Nome {get;set;}
        public List<Jogo>? Jogos {get;set;}
        public List<Time>? Times {get; set;}
        public int UsuarioId {get;set;}
        public virtual Usuario? Usuario {get;set;}
    }
}