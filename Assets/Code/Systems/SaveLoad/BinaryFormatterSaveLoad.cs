using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

namespace TAMKShooter.Systems.SaveLoad
{
    public class BinaryFormatterSaveLoad<T> : ISaveLoad<T>
        where T : class
    {

        public string FileExtension { get { return ".dat"; } }

        public string GetSaveFilePath(string fileName)
        {
            return Path.Combine(Application.persistentDataPath, fileName) + FileExtension;
        }

        public void Save(T objectToSave, string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (MemoryStream stream = new MemoryStream())
            {

                formatter.Serialize(stream, objectToSave);

                File.WriteAllBytes(GetSaveFilePath(fileName), stream.GetBuffer());
            }

        }

        public T Load(string fileName)
        {
            if (DoesSaveExist(fileName))
            {
                byte[] data = File.ReadAllBytes(GetSaveFilePath(fileName));

                BinaryFormatter formatter = new BinaryFormatter();

                using (MemoryStream stream = new MemoryStream(data))
                {
                    return (T)formatter.Deserialize(stream);
                }
            }

            return default(T);
        }

        public bool DoesSaveExist(string fileName)
        {
            return File.Exists(GetSaveFilePath(fileName));
        }

    }
}
