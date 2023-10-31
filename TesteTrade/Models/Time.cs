namespace MeuCampeonato.Models
{
    public class Time
    {
        public int IdTime {get;set;}
        public string? Nome {get;set;}
        public int UsuarioId {get;set;}
        public string? Cor { get;set;}
        public virtual Usuario? Usuario {get;set;}
    }
}