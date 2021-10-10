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

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }

    public int highScore;          // High score of the player
    public int musicVolume;        // Volume of the music set by the player : Default 80%
    public int effectsVolume;      // Volume of sound effects set by the player : Default 80%

    [SerializeField]
    Slider volumeMusicSlider, volumeEffectsSlider;

    private void Awake()
    {
        // Singleton design pattern, only one instance of GameManager will ever exist
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
        AdjustVolume();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();

    }
    public void AdjustVolume()
    {
        if (GameObject.FindGameObjectWithTag ("slider_music"))
        {
            volumeMusicSlider = (Slider) FindObjectOfType(typeof (Slider));
        }
        if (GameObject.FindGameObjectWithTag("slider_effects"))
        {
            volumeMusicSlider = (Slider)FindObjectOfType(typeof(Slider));
        }

        musicVolume = (int)volumeMusicSlider.value;
        effectsVolume = (int)volumeEffectsSlider.value; ;
    }

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
