using UnityEngine;

public class PlayerSwitcher : MonoBehaviour {
    public GameObject thirdPersonPlayer;
    public GameObject firstPersonPlayer;

    private bool isFirstPerson = false;

    void Start(){
        thirdPersonPlayer.SetActive(true);
        firstPersonPlayer.SetActive(false);
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.V))
        {
            SwitchPlayer();
        }
    }

    void SwitchPlayer(){
        isFirstPerson = !isFirstPerson;

        thirdPersonPlayer.SetActive(!isFirstPerson);
        firstPersonPlayer.SetActive(isFirstPerson);
    }
}
