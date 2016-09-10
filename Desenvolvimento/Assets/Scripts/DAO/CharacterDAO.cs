using ProjectFeudo.Domain.Creatures;
using ProjectFeudo.Domain.Interfaces.DAO;
using Newtonsoft.Json;
using System.IO;
using ProjectFeudo.DAO;
using Assets.Scripts.Domain.DTO.CharacterCreation;

namespace Assets.Scripts.DAO
{
    public class CharacterDAO : BaseDAO<BaseCreature>, ICharacterDAO
    {
        public CharacterDAO()
        {
            base.AssetsFolder = "/Character/";
        }
        public void CreateCharacterJsonFile(CharacterCreationJsonDTO character)
        {
            string json = JsonConvert.SerializeObject(character, Formatting.Indented);
            File.WriteAllText(base.StreamingAssetsPath + base.AssetsFolder + "characterData.json", json);
        }

        public CharacterCreationJsonDTO GetCharacterData()
        {
            using (StreamReader file = File.OpenText(StreamingAssetsPath + AssetsFolder + "characterData.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                CharacterCreationJsonDTO data = (CharacterCreationJsonDTO)serializer.Deserialize(file, typeof(CharacterCreationJsonDTO));

                return data;
            }
        }
    }
}
