namespace SignalRChat.Models
{
    public class UserMessage 
    {
        public Guid Id { get; private set; }

        public string Nome { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public bool Ativo { get; private set; }

        public DateTime? DataUpdate { get; private set; }
        
        public UserMessage (string nome)
        {
            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now;
            Ativo = true;
        }

        public void Update(string nome)
        {
            Nome = nome;
            DataUpdate = DateTime.Now;
        }

        public void Delete()
        {
            Ativo = false;
            DataUpdate = DateTime.Now;
        }
    }
}