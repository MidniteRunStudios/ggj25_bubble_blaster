using UnityEngine;

public class Coaster : MonoBehaviour
{
    public SplineController splineController;
    public float speed = 5.0f;

    private int currentIndex = 0;
    private float progress = 0.0f;

    void Update()
    {
        if (splineController == null || splineController.points.Length < 2)
            return;

        Transform start = splineController.points[currentIndex];
        Transform end = splineController.points[(currentIndex + 1) % splineController.points.Length];

        progress += speed * Time.deltaTime;

        if (progress >= 1.0f)
        {
            progress = 0.0f;
            currentIndex = (currentIndex + 1) % splineController.points.Length;
        }

        // Update position
        transform.position = Vector3.Lerp(start.position, end.position, progress);

        // Update rotation
        transform.rotation = Quaternion.Lerp(start.rotation, end.rotation, progress);
    }
}
