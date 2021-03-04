namespace tabuleiro
{
    abstract class Peca //Classe genérica de peças quaisquer
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; } //Protected: ser editada apenas por esta classe e suas subclasses
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; } //Atribtos

        public Peca(Tabuleiro tab, Cor cor) //Construtor
        {
            this.posicao = null; //Uma peça inicia sem posição
            this.cor = cor;
            this.tab = tab;
            qteMovimentos = 0; //Uma peça inicia com seus movimentos zerados
        }

        public void incrementarQteMovimentos()
        {
            qteMovimentos++;
        }

        public bool existeMovimentosPossiveis() //Verifica se há movimentos possiveis, percorrendo toda a matriz
        {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.colunas; j++)
                {
                    if(mat[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool podeMoverPara(Posicao pos)
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }

        public abstract bool[,] movimentosPossiveis(); //Método abstrato da classe genérica peça
    }
}
