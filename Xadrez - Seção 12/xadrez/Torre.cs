using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor) //Construtor com herança de peça
        {

        }

        public override string ToString() //Define sua letra de saída no tabuleiro
        {
            return "T";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos); //Recebe a posição
            return p == null || p.cor != this.cor; //Retorna nulo ou peça do oponente
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            //Verificando acima
            pos.definirValores(posicao.linha - 1, posicao.coluna); //Uma posicao acima da torre
            while (tab.posicaoValida(pos) && podeMover(pos)) //Enquanto a posicao for valida e poder mover
            {
                mat[pos.linha, pos.coluna] = true; //Permite mover
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) //Para o while quando bater numa peça adversaria
                {
                    break;
                }
                pos.linha = pos.linha - 1; //Avança a próxima casa
            }

            //Verificando abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna); //Uma posicao acima da torre
            while (tab.posicaoValida(pos) && podeMover(pos)) //Enquanto a posicao for valida e poder mover
            {
                mat[pos.linha, pos.coluna] = true; //Permite mover
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) //Para o while quando bater numa peça adversaria
                {
                    break;
                }
                pos.linha = pos.linha + 1;//Avança a próxima casa
            }

            //Verificando direita
            pos.definirValores(posicao.linha, posicao.coluna + 1); //Uma posicao acima da torre
            while (tab.posicaoValida(pos) && podeMover(pos)) //Enquanto a posicao for valida e poder mover
            {
                mat[pos.linha, pos.coluna] = true; //Permite mover
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) //Para o while quando bater numa peça adversaria
                {
                    break;
                }
                pos.coluna = pos.coluna + 1;//Avança a próxima casa
            }

            //Verificando esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1); //Uma posicao acima da torre
            while (tab.posicaoValida(pos) && podeMover(pos)) //Enquanto a posicao for valida e poder mover
            {
                mat[pos.linha, pos.coluna] = true; //Permite mover
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) //Para o while quando bater numa peça adversaria
                {
                    break;
                }
                pos.coluna = pos.coluna - 1;//Avança a próxima casa
            }
            return mat;
        }
    }
}