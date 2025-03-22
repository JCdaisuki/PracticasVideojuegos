using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("References")]
    public Camera cam; 
    public AudioSource audioSource;
    public LayerMask targetLayer; 
    public Transform gunBarrel;

    [Header("Bullet Config.")]
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;

    [Header("Effects")]
    public GameObject shootEffect;
    public AudioClip shotAudio;


    private void Start()
    {
        cam = FindAnyObjectByType<Camera>();
        audioSource = GetComponent<AudioSource>();

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
        shootEffect.SetActive(true);
        Invoke("ShootEffect", 0.05f);

        audioSource.clip = shotAudio;
        audioSource.PlayOneShot(shotAudio);

        GameObject bullet = GameObject.Instantiate(bulletPrefab, gunBarrel.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.useGravity = false; 
            Vector3 direction = (gunBarrel.forward).normalized; 
            rb.velocity = direction * bulletSpeed;
        }

        Destroy(bullet, 5f);
    }

    Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.point; 
        }

        return transform.position + transform.forward * 10f; 
    }

    private void ShootEffect()
    {
        shootEffect.SetActive(false);
    }
}
