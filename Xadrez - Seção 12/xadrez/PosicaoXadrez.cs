using tabuleiro;

namespace xadrez
{
    class PosicaoXadrez
    {
        public char coluna { get; set; }
        public int linha { get; set; } //Atributos

        public PosicaoXadrez(char coluna, int linha) //COnstrutor
        {
            this.coluna = coluna;
            this.linha = linha;
        }

        public Posicao toPosicao() //Transforma o objeto em uma posição
        {
            return new Posicao(8 - linha, coluna - 'a'); //Converte a matriz em um xadrez
        }

        public override string ToString() //Exibe a coordenada de uma peça
        {
            return "" + coluna + linha;
        }
    }
}
