using System;
using tabuleiro;

namespace xadrez { 
    internal class Peao : Peca
{
    public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
    {
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


        }//MOVIMENTO PEÃO COR PRETA

            return mat;

    }//MOVIMENTOS POSSIVEIS DE UM PEAO


    }//Classe PEAO
}

