using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("References")]
    public Camera cam; 
    public LayerMask targetLayer; 
    public Transform gunBarrel;

    [Header("Bullet Config.")]
    public GameObject shootEffect;
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;

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
        shootEffect.SetActive(true);
        Invoke("ShootEffect", 0.05f);

        GameObject bullet = GameObject.Instantiate(bulletPrefab, gunBarrel.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        
        if (rb != null)
        {
            Vector3 target = GetMouseWorldPosition();
            Vector3 direction = (target - transform.position).normalized;
            bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(0, Vector3.up) * (direction * bulletSpeed);
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
