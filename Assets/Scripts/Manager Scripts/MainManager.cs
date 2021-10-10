using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

// Singleton design pattern, only one instance of GameManager will ever exist in the game
public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }

    public int highScore;         // High score of the player
    public float musicVolume;     // Volume of the music set by the player

    [SerializeField] 
    Slider volumeSlider;

    private void Awake()
    {
        // Prevents duplicates of GameManger from existing
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartNewGame()
    {
        //AdjustVolume();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();

    }
    //public void AdjustVolume()
   // {
    //    volumeSlider = FindObjectOfType<Slider>();
    //    musicVolume = volumeSlider.value;
    //}

    [System.Serializable]
    class SaveData
    {
        public int PlayerHighScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.PlayerHighScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.PlayerHighScore;
        }
    }
}
