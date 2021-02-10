using CodeTur.Comum.Comands;

namespace CodeTur.Comum.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        //Handler : IHandler<Classe> se Classe : ICommand
        //Definindo que ao herdar o IHandler deve ser passado uma classe que herda o ICommand 
            ICommandResult Handle(T command);
        }
 }