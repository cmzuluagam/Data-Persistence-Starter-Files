using System;
using System.IO;
using UnityEngine;

public class BestScoreManager : MonoBehaviour
{
    public static BestScoreManager Instance;

    public BestScore BestScore { get; private set; } = new("None", 0);

    private string currentPlayerName = "None";

    internal void LoadBestScore(BestScore data)
    {
        this.BestScore = data;
    }

    internal void ReportScore(int score)
    {
        if (this.BestScore.Score < score)
        {
            this.BestScore = new(this.currentPlayerName, score);

            string json = JsonUtility.ToJson(this.BestScore);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }

    internal void UpdateCurrentPlayerName(string text)
    {
        this.currentPlayerName = text;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Instance is null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }

        Destroy(gameObject);
    }
}
