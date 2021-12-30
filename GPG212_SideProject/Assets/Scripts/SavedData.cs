using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class SavedData : MonoBehaviour
{
    string saveFile;
    public Text savedTime;
    public PlayerController player;

    private void Start()
    {
        saveFile = Application.persistentDataPath + "/HighestTime.json";
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void SaveToJson()
    {
        HighScore score = new HighScore();
        score.savedScore = player.finalTime.ToString();
        string json = JsonUtility.ToJson(score, true);
        File.WriteAllText(saveFile, json);
    }

    public void LoadFromJson()
    {
        string json = File.ReadAllText(saveFile);
        HighScore score = JsonUtility.FromJson<HighScore>(json);
        Debug.Log(score.savedScore);
        savedTime.text = score.savedScore;
    }
}
