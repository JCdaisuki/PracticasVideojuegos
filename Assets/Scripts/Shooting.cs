using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("References")]
    public Camera cam; 
    public LayerMask targetLayer; 

    [Header("Bullet Config.")]
    public GameObject shootEffect;

    private void Start()
    {
        cam = FindAnyObjectByType<Camera>();

        shootEffect.active = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        shootEffect.active = true;
        Invoke("ShootEffect", 0.05f);
    }

    private void ShootEffect()
    {
        shootEffect.active = false;
    }
}
