using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecosistemas_Marinos.Interfaces_Repositorios
{
    public interface IRepositorio<T>
    {
        IEnumerable<T> FindAll();
        T FindById(int id);
        void Add(T t);
        void Remove(T t);
        void Delete(T t);
        void Update(T t);

    }
}
