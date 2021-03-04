using System;

namespace tabuleiro
{
    class TabuleiroException : Exception
    {
        public TabuleiroException(string msg) : base(msg) //Classe com herança de exceção
        {

        }
    }
}
