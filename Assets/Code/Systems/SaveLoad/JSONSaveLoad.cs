using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;


namespace TAMKShooter.Systems.SaveLoad
{
    public class JSONSaveLoad<T> : ISaveLoad<T>
        where T : class
    {

        public string FileExtension { get { return ".json"; } }

        public string GetSaveFilePath(string fileName)
        {
            return Path.Combine(Application.persistentDataPath, fileName) + FileExtension;
        }

        public void Save(T objectToSave, string fileName)
        {

            string jsonObject = JsonUtility.ToJson(objectToSave, true);

            File.WriteAllText(GetSaveFilePath(fileName), jsonObject, Encoding.UTF8);
        }

        public T Load(string fileName)
        {
            if (DoesSaveExist(fileName))
            {
                string jsonObject = File.ReadAllText(GetSaveFilePath(fileName), Encoding.UTF8);

                return JsonUtility.FromJson<T>(jsonObject);
                
            }

            return default(T);
        }
        public bool DoesSaveExist(string fileName)
        {
            return File.Exists(GetSaveFilePath(fileName));
        }

    }
}
