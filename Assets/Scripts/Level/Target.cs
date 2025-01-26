using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int points;
    public PlayerScore PlayerScore;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == null || PlayerScore == null)
        {
            return;
        }

        if (other.transform.CompareTag("Bullet"))
        {
            audioSource.Play();
            PlayerScore.AddScore(points);
            Destroy(gameObject);
        }
    }
}
