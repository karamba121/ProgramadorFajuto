using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProgramadorFajuto.Domain.Dominio.Repositorios.Base
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> ListarTodos();
        IEnumerable<T> ListarTodos(Expression<Func<T, bool>> filtro);
        T Obter(Expression<Func<T, bool>> filtro);
        T Adicionar(T entidade);
        void Adicionar(IEnumerable<T> entidades);
        void Deletar(Expression<Func<T, bool>> filtro);
        void Editar(T entidade);
    }
}
