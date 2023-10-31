namespace MeuCampeonato.Models
{
    public class Jogo
    {
        public int IdJogo {get;set;}
        public List<Time>? Times {get;set;}
        public Time? Vencedor { get;set;}
        public int ChaveDoCampeonato {get;set;}
        public List<int>? Gols {get;set;}
        public int CampeonatoId {get;set;}
        public virtual Campeonato? Campeonato {get;set;}
    }
}