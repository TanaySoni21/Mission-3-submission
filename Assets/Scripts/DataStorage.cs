using System.IO;
using UnityEngine;

public class DataStorage : MonoBehaviour
{
    public static DataStorage Instance;
    public string highScorePlayerName = "tanay";
    public string playerName;
    public int highScore = 69;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string playername;
        public int score;
    }

    public void SaveHighScore(int score)
    {
        SaveData data = new SaveData();
        data.score = score;
        data.playername = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath +  "/savedata.json" , json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayerName = data.playername;
            highScore = data.score;
        }
    }
}
