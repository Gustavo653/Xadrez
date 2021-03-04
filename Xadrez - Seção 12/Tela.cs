using System;
using tabuleiro;
using xadrez;

namespace Xadrez___Seção_12
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab) //Método que imprime um tabuleiro
        {
            for (int i = 0; i < tab.linhas; i++) //Para cada linha
            {
                Console.Write(8 - i + " "); //Adiciona os números na tabela do xadrez
                for (int j = 0; j < tab.colunas; j++) //Para cada coluna
                {
                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine(); //QUebra linha
            }
            Console.WriteLine("  a b c d e f g h");//Adiciona as letras na tabela de xadrez
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis) //Método que imprime um tabuleiro
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++) //Para cada linha
            {
                Console.Write(8 - i + " "); //Adiciona os números na tabela do xadrez
                for (int j = 0; j < tab.colunas; j++) //Para cada coluna
                {
                    if (posicoesPossiveis[i,j]) //Se a posição for marcada como possível de movimento
                    {
                        Console.BackgroundColor = fundoAlterado; //Mundar seu fundo para cinza
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(i, j)); //imprime as peças
                    Console.BackgroundColor = fundoOriginal; //e retorna a cor original
                }
                Console.WriteLine(); //QUebra linha
            }
            Console.WriteLine("  a b c d e f g h");//Adiciona as letras na tabela de xadrez
            Console.BackgroundColor = fundoOriginal; //Retorna a or padrão ao fim de sua execução
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- "); //Adiciona um traço quando não há peça na posição
            }
            else
            {
                if (peca.cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor; //Salva a cor do console na variavel aux
                    Console.ForegroundColor = ConsoleColor.Yellow; //Define o foregroundcolor como yellow
                    Console.Write(peca);//Imprime a peça
                    Console.ForegroundColor = aux; //Volta cor salva na aux
                }
                Console.Write(" ");
            }
        }
    }
}
