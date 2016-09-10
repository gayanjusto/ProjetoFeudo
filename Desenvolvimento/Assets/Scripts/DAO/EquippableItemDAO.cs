using Assets.Scripts.Domain.Enums;
using ProjectFeudo.Domain.Interfaces.DAO;
using ProjectFeudo.Domain.Itens;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFeudo.DAO
{

    public class EquippableItemDAO : ItemDAO<EquippableItem>, IEquippableItemDAO
    {


        public EquippableItemDAO() {
            base.AssetsFolder = "/Itens/EquippableItens/";
        }


        private void SetChildrenToParentItem(IEnumerable<EquippableItem> itemList) {
            var childrenList = itemList.Where(x => x.ParentPartId != null);

            foreach (var item in childrenList) {
                var parentItem = itemList.First(x => x.Id == item.ParentPartId);
                parentItem.ChildPartList = parentItem.ChildPartList ?? new List<EquippableItem>();

                parentItem.ChildPartList.Add(item);
            }
        }

        public EquippableItem GetItemById(string id) {
            var items = GetAllByFileType(FileTypeEnum.JSON);

            return items.First(x => x.Id == id);
        }

        public EquippableItem GetItemByTypeAndBodyPart(string type, string bodyPart) {
            var items = GetAllByFileType(FileTypeEnum.JSON);

            return items.First(x => x.Type == type && x.ItemBodyPart == bodyPart);
        }
    }
}

