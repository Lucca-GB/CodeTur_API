using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Comum.Comands
{
    public interface ICommand
    {
        //Para toda vez que o ICommand for herdado ele fará uma validação do comando
        void Validar();

    }
}
