using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Comum.Queries
{
    public class GenericQueryResult : IQueryResult
    {
        public GenericQueryResult(bool sucesso, string mensagem, object data)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Data = data;
        }

        public bool Sucesso { get; private set; }
        public string Mensagem { get; private set; }
        public Object Data { get; private set; }
    }
}
