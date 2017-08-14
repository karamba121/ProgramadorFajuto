using Microsoft.EntityFrameworkCore;
using ProgramadorFajuto.Domain.Dominio.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Repositorios.Base
{
    public class RepositorioEF<T> : IRepositorio<T> where T : class
    {
        private DbSet<T> _set;

        public RepositorioEF(ContextoEF contexto) => this._set = contexto.Set<T>();

        public T Adicionar(T entidade)
        {
            return this._set.Add(entidade).Entity;
        }

        public void Adicionar(IEnumerable<T> entidades)
        {
            this._set.AddRange(entidades);
        }

        public void Deletar(Expression<Func<T, bool>> filtro)
        {
            this._set.RemoveRange(this._set.Where(filtro));
        }

        public void Editar(T entidade)
        {
            this._set.Update(entidade);
        }

        public IEnumerable<T> ListarTodos()
        {
            return this._set.ToList();
        }

        public IEnumerable<T> ListarTodos(Expression<Func<T, bool>> filtro)
        {
            return this._set.Where(filtro).ToList();
        }

        public T Obter(Expression<Func<T, bool>> filtro)
        {
            return this._set.FirstOrDefault(filtro);
        }
    }
}
