using System;
using tabuleiro;

namespace xadrez { 
    internal class Peao : Peca
{
    private PartidaDeXadrez partida;    
    public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
    {
            this.partida = partida;
    }

    public override string ToString()
    {
        return "P";
    }
    private bool existeInimigos(Posicao pos)
    {
        Peca p = tab.peca(pos);
        return p != null && p.cor != cor;
    }//VERIFICA SE A PEÇA PODE MOVER SE ESTIVER VAZIA OU COM PEÇA ADVERSARIA

    private bool livre(Posicao pos)
    {
        return tab.peca(pos) == null;
    }//Verifica se a posição para o PEAO estiver nula

    public override bool[,] movimentosPossiveis()
    {
        bool[,] mat = new bool[tab.linhas, tab.colunas];

        Posicao pos = new Posicao(0, 0);

        if (cor == Cor.Branca)
        {
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            if (tab.posicaoValida(pos) && livre(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha - 2, posicao.coluna);
            if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && existeInimigos(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && existeInimigos(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }


            // #jogadaespecial en passant
            if (posicao.linha == 3)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.posicaoValida(esquerda) && existeInimigos(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        mat[esquerda.linha - 1, esquerda.coluna] = true;
                    } //PEÇAS NA POSIÇÃO DA ESQUERDA

                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tab.posicaoValida(direita) && existeInimigos(direita) && tab.peca(direita) == partida.vulneravelEnPassant)
                    {
                        mat[direita.linha - 1, direita.coluna] = true;
                    }//PEÇAS NA POSIÇÃO DA ESQUERDA

                } // #jogadaespecial en passant

            }//MOVIMENTO PEÃO COR BRANCO

        else
        {

            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tab.posicaoValida(pos) && livre(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha + 2, posicao.coluna);
            if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && existeInimigos(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && existeInimigos(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

                // #jogadaespecial en passant
                if (posicao.linha == 4)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.posicaoValida(esquerda) && existeInimigos(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        mat[esquerda.linha + 1, esquerda.coluna] = true;
                    } //PEÇAS NA POSIÇÃO DA ESQUERDA

                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tab.posicaoValida(direita) && existeInimigos(direita) && tab.peca(direita) == partida.vulneravelEnPassant)
                    {
                        mat[direita.linha + 1, direita.coluna] = true;
                    }//PEÇAS NA POSIÇÃO DA ESQUERDA

                } // #jogadaespecial en passant


            }//MOVIMENTO PEÃO COR PRETA

            return mat;

    }//MOVIMENTOS POSSIVEIS DE UM PEAO


    }//Classe PEAO
}

