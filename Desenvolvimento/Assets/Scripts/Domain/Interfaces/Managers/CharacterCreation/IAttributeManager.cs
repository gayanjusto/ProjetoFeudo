namespace Assets.Scripts.Domain.Interfaces.Managers.CharacterCreation
{
    public interface IAttributeManager
    {
        int AttributePoints { get; set; }
        bool HasPointsToUse();

        void IncreaseAttribute(int attributeId);
        void DecreaseAttribute(int attributeId);

        int GetIntelligencePoints();
        int GetStrengthPoints();
        int GetDexterityPoints();
    }
}
