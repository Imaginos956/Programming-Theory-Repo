using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public int score;
    public int bestScore;
    public string namePlayer;
    public string nameLastPlayer;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        LoadDataPlayer();
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class SaveData
    {
        public int bestScore;
        public string namePlayer;
        public string nameLastPlayer;
    }

    public void SaveDataPlayer()
    {
        SaveData data = new SaveData();
        if (score > bestScore)
        {
            data.bestScore = score;
            data.namePlayer = nameLastPlayer;
        }
        data.nameLastPlayer = nameLastPlayer;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadDataPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            namePlayer = data.namePlayer;
            nameLastPlayer = data.nameLastPlayer;
        }
    }
}
