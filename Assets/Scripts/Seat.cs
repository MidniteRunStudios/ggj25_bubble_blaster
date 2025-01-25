using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : MonoBehaviour
{
    public GameObject assignedGameObject;
    public float xOffset = 1.0f; // Adjust this value to set the desired offset on the X-axis
    public float zOffset = 1.0f; // Adjust this value to set the desired offset on the Z-axis
    public float yOffset = 1.0f; // Adjust this value to set the desired offset on the Y-axis

    void Start()
    {

    }

    void Update()
    {
        if (assignedGameObject != null)
        {
            // Update the position with the position of the assigned GameObject plus the offsets on the X, Y, and Z axes
            transform.position = new Vector3(
                assignedGameObject.transform.position.x + xOffset,
                assignedGameObject.transform.position.y + yOffset,
                assignedGameObject.transform.position.z + zOffset
            );

            // Update the rotation with the rotation of the assigned GameObject
            transform.rotation = assignedGameObject.transform.rotation;
        }
    }
}
