using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public string FstPersonScene;
    public string TrdPersonScene;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void FirstPerson()
    {
        SceneManager.LoadScene(FstPersonScene);
    }

    public void ThirdPerson()
    {
        SceneManager.LoadScene(TrdPersonScene);
    }
}
