using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int points;
    public PlayerScore PlayerScore;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other == null || PlayerScore == null)
        {
            return;
        }

        if (other.transform.CompareTag("Bullet"))
        {
            PlayerScore.AddScore(points);
            Destroy(gameObject);
        }
    }
}
