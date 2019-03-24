using System.Collections.Generic;

namespace DemoApp.Business
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T p);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }
}