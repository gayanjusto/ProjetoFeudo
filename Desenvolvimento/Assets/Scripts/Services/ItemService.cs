using Assets.Scripts.Domain.Interfaces.Services;
using ProjectFeudo.DAO;
using ProjectFeudo.Domain.Interfaces.DAO;
using ProjectFeudo.Domain.Itens;
using System.Collections.Generic;
using System.Linq;


namespace ProjectFeudo.Services
{
    public class ItemService : IItemService
    {
        static string[] equippableItensCategories = new[] { "Armor", "Weapon" };
        private readonly IEquippableItemDAO equippableItemDAO;
        private readonly ICommonItemDAO commonItemDAO;

        public ItemService() {
            equippableItemDAO = equippableItemDAO ?? new EquippableItemDAO();
            commonItemDAO = commonItemDAO ?? new CommonItemDAO();
        }

        public IEnumerable<BaseItem> GetItemsFromCategories(IEnumerable<string> itemTypes) {

            List<BaseItem> baseItens = new List<BaseItem>();

            foreach (var category in itemTypes) {
                if (equippableItensCategories.Contains(category)) {
                    AddItemToBaseList(equippableItemDAO.GetAllByFileType(".json"), baseItens);
                } else {
                    AddItemToBaseList(commonItemDAO.GetAllByFileType(".json"), baseItens);
                }
            }

            return baseItens;
        }


        private IEnumerable<BaseItem> AddItemToBaseList<T>(IEnumerable<T> itens, List<BaseItem> baseItens) where T : BaseItem {
            foreach (var item in itens) {
                baseItens.Add(item);
            }

            return baseItens;
        }

    }
}

