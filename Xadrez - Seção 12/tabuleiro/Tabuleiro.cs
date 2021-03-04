namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; } //Atributos
        private Peca[,] pecas; //A matriz peças só poderá ser acessada por esta classe e seus respectivos métodos

        public Tabuleiro(int linhas, int colunas) //Construtor
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas]; //Pecas recebe uma nova matriz de peças com determinado número de linhas e colunas
        }

        public Peca peca(int linha, int coluna) //Método que permite o acesso a uma peça individual da matriz Peca
        {
            return pecas[linha, coluna]; //Retorna a matriz com a linha e coluna
        }

        public Peca peca(Posicao pos) //Sobrecarga usada para verificações de peça
        {
            return pecas[pos.linha, pos.coluna];
        }

        public bool existePeca(Posicao pos) //Verifica se em uma pos existe uma peça
        {
            validarPosicao(pos); //Chama o método validarPosicao e verifica a posição
            return peca(pos) != null; //Apenas retorna se pos for diferente de nulo
        }

        public void colocarPeca(Peca p, Posicao pos) //Coloca uma peça p numa posição pos
        {
            if (existePeca(pos)) //existePeça já verifica se a posição é valida, e se está ocupada
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            pecas[pos.linha, pos.coluna] = p; //Vai na matriz de peças e recebe a peça p, ou seja, a peça p é jogada numa determinada matriz
            p.posicao = pos; //A posição da peça p agora é pos
        }

        public Peca retirarPeca(Posicao pos)
        {
            if (peca(pos) == null) //Se a peça estiver na posição nula, não precisa retirar pois já está fora
            {
                return null;
            }
            Peca aux = peca(pos); //Variavel que recebe a posição da peça
            aux.posicao = null; //seta a posição como nula
            pecas[pos.linha, pos.coluna] = null; //seta o local no tabuleiro como nulo
            return aux; //retorna a peça
        }

        public bool posicaoValida(Posicao pos) //testa se uma posição pos é válida
        {
            if (pos.linha < 0 || pos.linha >= linhas | pos.coluna < 0 || pos.coluna >= colunas) //COmpara o tamanho do tabuleiro com a posição inserida
            {
                return false;
            }
            return true; //Se a posição for válida, retorna true
        }

        public void validarPosicao(Posicao pos) //Verifica posição e se necessário lança exceção
        {
            if(!posicaoValida(pos)) //Se o método posicaoValida retornar false, lança exceção
            {
                throw new TabuleiroException("Posição inválida! ");
            }
        }
    }
}
