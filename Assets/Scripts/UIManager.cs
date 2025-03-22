using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Timer")]
    public TextMeshProUGUI timer;
    public float timerNumber = 0;

    [Header("Progreso")]
    public Transform player;
    public Transform finish;
    private Slider progressBar;
    private float totalDistance;
    private float currentDistance;

    [Header("Game Over")]
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public GameObject loseScreen;
    private Vector3 restartPosition;
    public string mainMenuScene;

    [Header("Sounds")]
    public AudioSource audioSource;
    public AudioClip victoryAudio;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        progressBar = GetComponentInChildren<Slider>();
        totalDistance = Vector3.Distance(player.position, finish.position);

        restartPosition = player.position;

        RestartUI();
    }

    private void Update()
    {
        if(gameOverScreen.activeInHierarchy == false)
        {
            timerNumber += Time.deltaTime;

            int minutes = (int)(timerNumber / 60);
            int seconds = (int)(timerNumber % 60);
            int milliseconds = (int)((timerNumber - (int)timerNumber) * 100);

            timer.text = string.Format("{0:00}::{1:00}::{2:00}", minutes, seconds, milliseconds);
        }

        currentDistance = Vector3.Distance(player.position, finish.position);
        progressBar.value = 1 - Mathf.Clamp01(currentDistance / totalDistance);
    }

    public void RestartGame()
    {
        player.position = restartPosition;
        player.gameObject.SetActive(true);

        RestartUI();
    }

    public void RestartUI()
    {
        player.gameObject.SetActive(true);
        
        player.gameObject.SetActive(true);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        gameOverScreen.SetActive(false);
    }

    public void WinScreen()
    {    
        audioSource.clip = victoryAudio;
        audioSource.PlayOneShot(victoryAudio);

        player.gameObject.SetActive(false);

        gameOverScreen.SetActive(true);
        winScreen.SetActive(true);
    }

    public void LoseScreen()
    {
        player.gameObject.SetActive(false);

        gameOverScreen.SetActive(true);
        loseScreen.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
