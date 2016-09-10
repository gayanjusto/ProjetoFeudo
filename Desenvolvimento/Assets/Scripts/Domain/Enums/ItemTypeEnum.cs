
namespace ProjectFeudo.Domain.Enums
{
    public class ItemTypeEnum
    {
        public ItemTypeEnum(string value) { Value = value; }
        public string Value { get; set; }

        public static ItemTypeEnum Bare { get { return new ItemTypeEnum("Bare"); } }
        public static ItemTypeEnum Armor { get { return new ItemTypeEnum("Armor"); } }
        public static ItemTypeEnum Weapon { get { return new ItemTypeEnum("Weapon"); } }
        public static ItemTypeEnum Shield { get { return new ItemTypeEnum("Shield"); } }
    }
}
  
