using CodeTur.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Comum.Handlers
{
    public interface IHandlerQuery<T> where T : IQuery
    {
        IQueryResult Handle(T query);
    }
}
