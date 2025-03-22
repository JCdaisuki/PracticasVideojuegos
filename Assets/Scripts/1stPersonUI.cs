using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstPersonUI : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject gameScreen;
    public GameObject winScreen;

    [Header("Points Count")]
    public int deathCount = 0;
    public TextMeshProUGUI number;
    public int deathObjetive;
    public static FirstPersonUI Instance { get; private set; }

    [Header("Win Conditions")]
    public bool nextLevel = false;
    public GameObject nextLevelButton;

    [Header("Scenes")]
    public string menuPrincipal;
    public string nextLevelScene;

    [Header("Sounds")]
    public AudioSource audioSource;
    public AudioClip victoryAudio;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            deathCount = Instance.deathCount;
            Destroy(Instance);
        }
    }

    private void Start()
    {
        Time.timeScale = 1;
        audioSource = GetComponent<AudioSource>();

        gameScreen.SetActive(true);
        winScreen.SetActive(false);

        number.text = deathCount.ToString();
    }

    public void AddPoint()
    {
        deathCount++;
        number.text = deathCount.ToString();
        
        if(deathCount == deathObjetive)
        {
            WinScreen();
        }
    }

    private void WinScreen()
    {
        Time.timeScale = 0;

        audioSource.clip = victoryAudio;
        audioSource.PlayOneShot(victoryAudio);

        gameScreen.SetActive(false);
        winScreen.SetActive(true);

        if(nextLevel)
        {
            nextLevelButton.SetActive(true);
        }
        else
        {
            nextLevelButton.SetActive(false);
        }
    }

    public void MainMenu()
    {
        winScreen.SetActive(false);
        
        SceneManager.LoadScene(menuPrincipal);
    }

    public void NextScene()
    {
        Instance.deathCount = deathCount;
        winScreen.SetActive(false);

        SceneManager.LoadScene(nextLevelScene);
    }
}
