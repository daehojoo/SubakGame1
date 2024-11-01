using System.Collections.Generic;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    public static RankingManager Instance { get; private set; }
    private List<PlayerScore> playerScores = new List<PlayerScore>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        LoadScores();
    }

    public void AddScore(string playerName, int score)
    {
        playerScores.Add(new PlayerScore(playerName, score));
        playerScores.Sort((x, y) => y.score.CompareTo(x.score));
        SaveScores();
    }

    public List<PlayerScore> GetTopScores(int count)
    {
        return playerScores.GetRange(0, Mathf.Min(count, playerScores.Count));
    }

    private void SaveScores()
    {
        string json = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("PlayerScores", json);
        PlayerPrefs.Save();
    }

    private void LoadScores()
    {
        if (PlayerPrefs.HasKey("PlayerScores"))
        {
            string json = PlayerPrefs.GetString("PlayerScores");
            JsonUtility.FromJsonOverwrite(json, this);
        }
    }
}
