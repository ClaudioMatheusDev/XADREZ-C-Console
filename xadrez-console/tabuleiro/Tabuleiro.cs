using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }//TABULEIRO

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }//PECA

        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }// PECA


        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }//VERIFICAR SE JÁ HÁ PEÇA NO LUGAR


        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException(" Já existe uma peça nessa posisção!");
            }//VENDO SE JA TEM PEÇA NA POSIÇÃO
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }//COLOCAR PECA

        public bool posicaoValida(Posicao pos)
        {
            if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna > colunas)
            {
                return false;
            }
            return true;
        }//TESTANDO POSIÇÃO INSERIDA

        public void validarPosicao(Posicao pos) {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição invalida!");
            }//IF  VALIDAR POSIÇÃO
        
        }//VALIDAR A POSIÇÃO


    }//CLASS TABULEIRO 

}//MAIN
