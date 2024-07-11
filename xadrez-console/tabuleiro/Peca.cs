﻿using System;
using System.ComponentModel;
using tabuleiro;

namespace tabuleiro
{
   abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor) {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;
        }//PUBLIC PECA

        public void incrementarQteMovimentos()
        {
            qteMovimentos++;
        }//Quantidade de movimentos ++

        public void decrementarQteMovimentos()
        {
            qteMovimentos--;
        }//Quantidade de movimentos --

        public bool existeMovimentosPossiveis() {
            bool[,] mat = movimentosPossiveis();
            for(int i = 0; i<tab.linhas; i++){
                    for (int j = 0; j < tab.colunas; j++){
                    if (mat[i, j]){
                        return true;
                      }
                }
            }
            return false;
        } //EXISTE MOVIMENTOS POSSIVEIS


        public bool podeMoverPara(Posicao pos)
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }


        public abstract bool[,] movimentosPossiveis();
        

        

    }//CLASS PECA


}//NAMESPACE
