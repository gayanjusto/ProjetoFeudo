using ProjectFeudo.DAO;
using ProjectFeudo.Domain.Enums;
using ProjectFeudo.Domain.Interfaces.DAO;
using ProjectFeudo.Domain.Interfaces.Services;
using ProjectFeudo.Domain.Itens;
using ProjectFeudo.Managers;
using UnityEngine;

namespace ProjectFeudo.Services
{
    public class InventoryService : IInventoryService
    {

        private readonly IAnimationService animationService;
        private readonly IEquippableItemDAO equippableItemDAO;

        public InventoryService() {
            animationService = animationService ?? new AnimationService();
            equippableItemDAO = equippableItemDAO ?? new EquippableItemDAO();
        }


        public EquippableItem EquipItem(GameObject rootGameObject, string itemId) {

            EquippableItem item = equippableItemDAO.GetItemById(itemId);

            OverrideObjectAnimator(rootGameObject, item);

            return item;
        }

        public EquippableItem EquipBarePart(GameObject rootGameObject, string bodyPart) {
            EquippableItem item = equippableItemDAO.GetItemByTypeAndBodyPart(ItemTypeEnum.Bare.Value, bodyPart);

            OverrideObjectAnimator(rootGameObject, item);

            return item;
        }

        void OverrideObjectAnimator(GameObject rootGameObject, EquippableItem item) {
            AnimationManager animationManager = rootGameObject.GetComponent<AnimationManager>();

            animationManager.SetAnimatorController(
                animationService.ChangeAnimationClipsByBodyPart(animationManager, item)
                );
        }
    }
}
