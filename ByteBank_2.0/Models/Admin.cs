namespace ByteBank_2._0.Models
{
    internal class Admin
    {
        public string Nome { get; set; }
        public string NomeDeUsuario { get; set; }
        public int Senha { get; set; }
        public Admin() { }
        public Admin(string aNome, string aNomeDeUsuario, int aSenha)
        {
            Nome = aNome;
            NomeDeUsuario = aNomeDeUsuario;
            Senha = aSenha;
        }

    }
}
