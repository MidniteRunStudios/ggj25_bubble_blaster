using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameManager GameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other == null || other.gameObject == null) {  return; }

        if (other.transform.CompareTag("Player"))
        {
            GameManager.EndGame();
        }
    }
}
