using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject thirdPersonCamera;
    public GameObject firstPersonCamera;

    private bool isFirstPerson = false;

    void Start()
    {
        thirdPersonCamera.SetActive(true);
        firstPersonCamera.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SwitchCamera();
        }
    }

    void SwitchCamera()
    {
        isFirstPerson = !isFirstPerson;

        thirdPersonCamera.SetActive(!isFirstPerson);
        firstPersonCamera.SetActive(isFirstPerson);
    }
}
