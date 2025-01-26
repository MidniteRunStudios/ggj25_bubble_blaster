using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TextEffects : MonoBehaviour
{
    
    public float bounceAmplitude = 1.0f;
    public float bounceFrequency = 1.0f;
    public float colorChangeSpeed = 1.0f;

    private Vector3 originalPosition;
    private TMP_Text tmpText;
    void Start()
    {
        tmpText = GetComponent<TMP_Text>();
        originalPosition = tmpText.transform.localPosition;
        StartCoroutine(ChangeColor());
    }

    void Update()
    {
        Bounce();
    }

    void Bounce()
    {
        float newY = Mathf.Sin(Time.deltaTime * bounceFrequency) * bounceAmplitude;
        tmpText.transform.localPosition = new Vector3(originalPosition.x, originalPosition.y + newY, originalPosition.z);
    }

    IEnumerator ChangeColor()
    {
        while (true)
        {
            tmpText.color = new Color(Random.value, Random.value, Random.value);
            yield return new WaitForSeconds(colorChangeSpeed);
        }
    }
}