using System;
using System.Collections.Generic;
using ZurichTest.Domain.Entidades;

namespace ZurichTest.Domain.Contratos
{
    public interface IRepositorioSeguro : IRepositorioBase<Seguro>
    {
        IEnumerable<Object> PegarTodosOsSeguros();
        Object PesquisarSeguroPorId(int id);
        Object RetornarMediaDosSeguros();
    }
}
