using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class TargetValue : MonoBehaviour
{
    //place this on the target itself.
    //collider can be set to trigger but if it is not then the OnCollision() function will take over.

    [SerializeField] int _value;


    private void OnTriggerEnter(Collider other)
    {
        var IScore = FindObjectOfType <Player_Score>().GetComponent<IScore>();

        if (other.CompareTag("Bullet"))
        {
            if (IScore != null)
            {
                IScore.AddScore(_value);
                Debug.Log($"Score: {_value}");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var IScore = FindObjectOfType<Player_Score>().GetComponent<IScore>();

        if (collision.transform.CompareTag("Bullet"))
        {
            if (IScore != null)
            {
                IScore.AddScore(_value);
                Debug.Log($"Score: {_value}");
            }
        }
    }
}
