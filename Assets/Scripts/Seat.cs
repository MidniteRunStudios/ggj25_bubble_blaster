using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : MonoBehaviour
{
    public GameObject assignedGameObject;
    public float xOffset = 1.0f; // Adjust this value to set the desired offset on the X-axis
    public float zOffset = 1.0f; // Adjust this value to set the desired offset on the Z-axis
    public float yOffset = 1.0f; // Adjust this value to set the desired offset on the Y-axis
    public float rotationLerpSpeed = 50.0f; // Adjust this value to set the speed of rotation interpolation

    void Update()
    {
        if (assignedGameObject != null)
        {
            // Calculate the offset in relation to the rotation of the assigned object
            Vector3 offset = assignedGameObject.transform.right * xOffset +
                             assignedGameObject.transform.up * yOffset +
                             assignedGameObject.transform.forward * zOffset;

            // Update the position with the calculated offset
            transform.position = assignedGameObject.transform.position + offset;

            // Update the rotation with the rotation of the assigned GameObject using Lerp
            transform.rotation = Quaternion.Lerp(transform.rotation, assignedGameObject.transform.rotation, Time.deltaTime * rotationLerpSpeed);
        }
    }
}
