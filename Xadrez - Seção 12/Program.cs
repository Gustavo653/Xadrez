using System;
using tabuleiro;
using xadrez; //É possível usar essa nomenclatura, devido os namespaces das classes serem iguais a esta chamada

namespace Xadrez___Seção_12
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while(!partida.terminada)
                    {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab); //Imprime o tabuleiro na tela
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.turno); //Exibe o turno
                        Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual); //Exibe a vez de quem joga

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao(); //Le a posição e converte para matriz
                        partida.validarPosicaoDeOrigem(origem); //Manda a origem para verificação

                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis(); //Pega a posição da peça inserida pelo usuário e armazena seus movimentos possíveis

                        Console.Clear(); //Limpa o tabuleiro                
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis); //Imprime no tabuleiro um tabuleiro novo com as posições possiveis de determinada peça

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao(); //Le a posição e converte para matriz
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino); //Executa o movimento solicitado, inclusive permitindo eliminar outra peça
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }

            Console.ReadKey();
        }
    }
}
