
using System.Collections.Generic;

namespace ProjectFeudo.Domain.Interfaces.DAO
{
    public interface IItemDAO<T> : IBaseDAO<T> where T : class
    {
        IEnumerable<T> GetItensByContextAndRarity(int[] context, int rarity);
    }

}
