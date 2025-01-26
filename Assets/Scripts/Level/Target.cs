using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int points;
    public PlayerScore PlayerScore;
    private AudioSource audioSource;
    private Renderer targetRenderer;
    private SphereCollider sphereCollider;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        targetRenderer = GetComponent<Renderer>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == null || PlayerScore == null)
        {
            return;
        }

        if (other.transform.CompareTag("Bullet"))
        {

            StartCoroutine(PlayAudioAndDestroy());
        }
    }

    private IEnumerator PlayAudioAndDestroy()
    {
        sphereCollider.enabled = false;
        // Make the target invisible
        targetRenderer.enabled = false;
        // play sound
        audioSource.Play();
        PlayerScore.AddScore(points);

        // Wait until the audio has finished playing
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        Destroy(gameObject);
    }
}
