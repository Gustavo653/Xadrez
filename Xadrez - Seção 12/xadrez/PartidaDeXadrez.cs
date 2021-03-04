using System;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; } //Inicia o tabuleiro
        public int turno { get; private set; } //A cada turno, deve ser incrementado
        public Cor jogadorAtual { get; private set; } //Indica de quem é a vez para jogar
        public bool terminada { get; private set; }

        public PartidaDeXadrez() //COnstrutor
        {
            tab = new Tabuleiro(8, 8); //Partida tem um tabuleiro 8 x 8
            turno = 1; //Inicia no turno 1
            jogadorAtual = Cor.Branca; //As peças brancas iniciam
            terminada = false; //Quando a partida acaba, se torna true
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem); //Tira a peça de determinado local
            p.incrementarQteMovimentos(); //Adiciona uma 1 movimento na peça
            Peca pecaCapturada = tab.retirarPeca(destino); //Tira a peça do destino, caso exista
            tab.colocarPeca(p, destino); //Coloca a peça no novo local
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino); //Faz o movimento
            turno++; //Passa o turno
            mudaJogador(); //Muda o jogador
        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null) //Se a posição for nula
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).cor) //Se a cor da jogada atual não for a cor da peça escolhida
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis()) //Se não há movimentos possíveis
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino)) //Verifica se pode mover uma peça da origem para o destino
            {
                throw new TabuleiroException("Posiçao de destino inválida!");
            }
        }

        private void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca) //Se o jogador atual é branco
            {
                jogadorAtual = Cor.Preta; //O preto é o próximo
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        private void colocarPecas()
        {
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 1).toPosicao()); //Adiciona uma peça na posição c1, depois converte para a matriz
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('d', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 1).toPosicao());

            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 7).toPosicao()); //Adiciona uma peça na posição c1, depois converte para a matriz
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('d', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('d', 8).toPosicao());
        }
    }
}
