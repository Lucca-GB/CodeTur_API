using CodeTur.Comum.Comands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Comum.Handles
{
    //Handler : IHandler<Classe> se Classe : ICommand
    //Definindo que ao herdar o IHandler deve ser passado uma classe que herda o ICommand 
    interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
