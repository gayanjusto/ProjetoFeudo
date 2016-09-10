using System;
using System.Collections.Generic;
using ProjectFeudo.Domain.Interfaces.DAO;
using System.Linq;
using ProjectFeudo.Domain.Itens;
using Assets.Scripts.Domain.Enums;

namespace ProjectFeudo.DAO
{
    public class ItemDAO<T> : BaseDAO<T>, IItemDAO<T> where T : BaseItem
    {

        public IEnumerable<T> GetItensByContextAndRarity(int[] context, int rarity) {
            return base.GetAllByFileType(FileTypeEnum.JSON)
                .Where(x => x.ItemContextIds.Intersect(context).Any() && x.Rarity <= rarity );
        }
    }

}
