using UnityEngine;
using System.IO;

public class Saver : MonoBehaviour
{
    public void TrySave(FieldCell[,] gameField, int score, string name)
    {
        FieldSave save = new FieldSave(gameField, score);
        if (!Directory.Exists(GetPath("")))
        {
            Directory.CreateDirectory(GetPath(""));
        }
        string path = GetPath(GetFileName(name));
        File.WriteAllText(path, JsonUtility.ToJson(save));
    }

    public bool TryLoad(string name, out FieldSave save)
    {
        string path = GetPath(GetFileName(name));

        if (File.Exists(path))
        {
            save = JsonUtility.FromJson<FieldSave>(File.ReadAllText(path));
            return true;
        }
        else
        {
            save = null;
            return false;
        }       
    }

    private string GetFileName(string name)
    {
        return "FieldSave_" + name + ".json";
    }

    private string GetPath(string fileName)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        string path = Path.Combine(Application.persistentDataPath + "Saves", fileName);
#else
        string path = Path.Combine(Application.dataPath + "/Saves", fileName);
#endif
        return path;
    }
}
