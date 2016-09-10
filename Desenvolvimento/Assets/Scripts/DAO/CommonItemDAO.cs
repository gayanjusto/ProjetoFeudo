using ProjectFeudo.Domain.Interfaces.DAO;
using ProjectFeudo.Domain.Itens;

namespace ProjectFeudo.DAO
{
    public class CommonItemDAO : ItemDAO<CommonItem>, ICommonItemDAO
    {
        public CommonItemDAO() {
            base.AssetsFolder = "/Itens/CommonItens";
        }
    }
}


