using System.Collections.Generic;

namespace ProjectFeudo.Domain.Interfaces.DAO
{
    public interface IBaseDAO<T> where T : class
    {
        IEnumerable<T> GetAllFromSpecificFile(string assetFile, string formatType);
        IEnumerable<T> GetAllByFileType(string formatType);
    }
}


