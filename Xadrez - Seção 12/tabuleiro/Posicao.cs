namespace tabuleiro
{
    class Posicao
    {
        public int linha { get; set; }
        public int coluna { get; set; } //Atributos

        public Posicao(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna; //COnstrutor
        }

        public void definirValores(int linha, int coluna) //Recebe a posicao
        {
            this.linha = linha;
            this.coluna = coluna;
        }

        public override string ToString()
        {
            return linha + ", " + coluna; //Formatação de saída
        }
    }
}
