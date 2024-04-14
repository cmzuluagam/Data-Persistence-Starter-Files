using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI playerNameTextMesh;

    [SerializeField]
    private TextMeshProUGUI bestScoreNameTextMesh;


    public static UIManager Instance;

    public void Start()
    {
        this.RetrieveBestScore();
        this.bestScoreNameTextMesh.text = $"{BestScoreManager.Instance.BestScore.Name} - {BestScoreManager.Instance.BestScore.Score}";
    }

    public void StartGame()
    {
        BestScoreManager.Instance.UpdateCurrentPlayerName(this.playerNameTextMesh.text);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    private void RetrieveBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestScore data = JsonUtility.FromJson<BestScore>(json);
            BestScoreManager.Instance.LoadBestScore(data);
        }
    }
}
