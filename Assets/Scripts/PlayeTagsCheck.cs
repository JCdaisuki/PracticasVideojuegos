using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTagsCheck : MonoBehaviour
{
    public UIManager uiManager;

    private void Start()
    {
        uiManager = FindAnyObjectByType<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstaculo"))
        {
            uiManager.LoseScreen();
        }
        else if(other.CompareTag("Finish"))
        {
            uiManager.WinScreen();
        }
    }
}
