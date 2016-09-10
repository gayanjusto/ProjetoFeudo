using Newtonsoft.Json;
using ProjectFeudo.Domain.Interfaces.DAO;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

namespace ProjectFeudo.DAO
{
    public abstract class BaseDAO<T> : IBaseDAO<T> where T : class
    {
        protected string StreamingAssetsPath = Application.dataPath + "/StreamingAssets/Repositories";
        protected string AssetsFolder;

        public IEnumerable<T> GetAllFromSpecificFile(string assetFile, string formatType) {
            using (StreamReader file = File.OpenText(StreamingAssetsPath + AssetsFolder + assetFile + formatType)) {
                JsonSerializer serializer = new JsonSerializer();
                IEnumerable<T> itens = (IEnumerable<T>)serializer.Deserialize(file, typeof(IEnumerable<T>));

                return itens;
            }
        }

        public IEnumerable<T> GetAllByFileType(string formatType) {

            List<string> files = new List<string>();
            foreach (string file in Directory.GetFiles(StreamingAssetsPath + AssetsFolder, "*.*", SearchOption.AllDirectories)
                .Where(x => Path.GetExtension(x).Contains(formatType))) {
                files.Add(File.ReadAllText(file));
            }

            List<T> itemList = new List<T>();
            foreach (var file in files) {
                JsonSerializer serializer = new JsonSerializer();
                IEnumerable<T> itens = JsonConvert.DeserializeObject<IEnumerable<T>>(file);
                foreach (var item in itens) {
                    itemList.Add(item);
                }
            }

            files = null;
            return itemList;
        }
    }
}


