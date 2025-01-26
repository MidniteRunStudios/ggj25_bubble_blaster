using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public float arcHeight = 0.5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Vector3 targetPosition = transform.position + transform.forward * 1f; // Assuming the dart is shot forward
        StartCoroutine(ApplyArcVelocity(targetPosition));
    }

    IEnumerator ApplyArcVelocity(Vector3 targetPosition)
    {
        Vector3 startPos = transform.position;
        Vector3 direction = (targetPosition - startPos).normalized;
        float distance = Vector3.Distance(startPos, targetPosition);

        float flightDuration = distance / bulletSpeed;
        float verticalVelocity = arcHeight / (flightDuration / 2f);

        float elapsedTime = 0f;

        while (elapsedTime < flightDuration)
        {
            float horizontalVelocity = bulletSpeed;
            Vector3 currentVelocity = direction * horizontalVelocity  * verticalVelocity * Mathf.Sin((elapsedTime / flightDuration) * Mathf.PI);
            rb.velocity = currentVelocity;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rb.velocity = direction * bulletSpeed; // Maintain speed after reaching the target
    }
}
