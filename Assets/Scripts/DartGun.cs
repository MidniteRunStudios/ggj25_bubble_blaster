using UnityEngine;

public class DartGun : MonoBehaviour
{
    public GameObject dartPrefab;
    public Transform firePoint;
    public float fireRate = 10f;

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            FireDart();
        }
    }

    void FireDart()
    {
        GameObject dart = Instantiate(dartPrefab, firePoint.position, firePoint.rotation);
    }
}
