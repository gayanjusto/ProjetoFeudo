using Assets.Scripts.Domain.DTO.CharacterCreation;
using Assets.Scripts.Domain.Entities.CharacterManagement;

namespace Assets.Scripts.Domain.Factories.CharacterCreation
{
    public class ClassJsonDTOFactory
    {
        public static CharacterCreationClassJsonDTO InstantiateDtoClassFromBaseClass(BaseClass baseClass)
        {
            CharacterCreationClassJsonDTO dtoClass = new CharacterCreationClassJsonDTO();
            dtoClass.ClassId = baseClass.ClassId;
            dtoClass.ClassName = baseClass.GetType().Name;
            dtoClass.ClassSkills = baseClass.ClassSkills;

            return dtoClass;
        }

    }
}
