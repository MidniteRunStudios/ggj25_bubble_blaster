using UnityEngine;

public class BasicFPSController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    public float lerpSpeed = 10f; // Speed at which the rotation interpolates

    float xRotation = 0f;
    float yRotation = 0f;

    Quaternion targetRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        targetRotation = transform.localRotation;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouseX;

        targetRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, lerpSpeed * Time.deltaTime);
    }
}
