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

    public int highScore;               // High score of the player
    public int musicVolume = 80;        // Volume of the music set by the player : Default 80%
    public int effectsVolume = 80;      // Volume of sound effects set by the player : Default 80%

    [SerializeField]
    Slider volumeMusicSlider, volumeEffectsSlider;
    GameObject mainScreen, optionScreen, shipUIScreen, endScreen;
    bool gameActive;

    private void Awake()
    {
        // Singleton design pattern, only one instance of GameManager will ever exist
        // Prevents duplicates of MainManager from existing
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Delegates for Scene management
    private void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the index of the scene in the project's build settings.
        int buildIndex = currentScene.buildIndex;
        Debug.Log("About to check build scene...");
        // If index 0 (Main Menu Scene) then retrieve the main Menu Screen objects
        if (buildIndex == 0)
        {
            Debug.Log("In build scene 0");
            mainScreen = GameObject.Find("Main Screen");
            optionScreen = GameObject.Find("Option Screen");

            if (GameObject.FindGameObjectWithTag("slider_music"))
            {
                volumeMusicSlider = (Slider)FindObjectOfType(typeof(Slider));
            }
            if (GameObject.FindGameObjectWithTag("slider_effects"))
            {
                volumeEffectsSlider = (Slider)FindObjectOfType(typeof(Slider));
            }
            optionScreen.SetActive(false);
        }
        else if (buildIndex == 1) // In Game Scene, then get the related Screens
        {
            Debug.Log("In build scene 1");
            endScreen = GameObject.Find("End Screen");
            shipUIScreen = GameObject.Find("Ship UI");
            endScreen.SetActive(false);
        }
    }

    public void StartNewGame()
    {
        //Starts the game by loading the game scene
        SceneManager.LoadScene(1);
    }

    public void GameEnd()
    {
        endScreen.gameObject.SetActive(true);
        shipUIScreen.gameObject.SetActive(false);
        gameActive = false;

        // TODO
        //UpdateHighScore();
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        // Closes game
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();

    }

    public void ApplySettingsAndReturn()
    {
        // Apply volume settings
        AdjustVolume();
        // Return to Main Menu
        ChangeBetweenMainOrOptions();
    }

    public void ChangeBetweenMainOrOptions()
    {
        // Sets the mainScreen and optionScreens to be the opposite of their current active state
        mainScreen.SetActive(!mainScreen.activeInHierarchy);
        optionScreen.SetActive(!optionScreen.activeInHierarchy);
    }
    public void AdjustVolume()
    {
        musicVolume = (int)volumeMusicSlider.value;
        effectsVolume = (int)volumeEffectsSlider.value;
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
