using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peek.Repository
{
    public interface IRepo<T>
    {
        void Insert(T item);
        void Update(T item);
        T Select(T item);
        IEnumerable<T> Select();
        IEnumerable<T> Select(int skip, int take);
        void Delete(T item);
        bool Exists(T item);
    }
}
