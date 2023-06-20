using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int Score;
}

public class Progress : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);

    [DllImport("__Internal")]
    private static extern void LoadExtern();
    
    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(int value);

    public PlayerInfo PlayerInfo;
    
    public static Progress Instance;

    public bool IsInvertControl;
    
    public bool IsPhone { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
        LoadExtern();
    }

    private void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        SaveExtern(jsonString);
    }

    public void SaveToLeaderboard(int score)
    {
        if (PlayerInfo.Score > score) return;
        PlayerInfo.Score = score;
        SetToLeaderboard(score);
        Save();
    }

    public void SetPlayerInfo(string value) => PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);

    public void GetDeviceType(string type) => IsPhone = type == "mobile";
}