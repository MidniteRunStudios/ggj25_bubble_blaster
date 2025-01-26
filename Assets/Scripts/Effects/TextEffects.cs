using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TextEffects : MonoBehaviour
{
    public float colorChangeSpeed = 1.0f;
    private TMP_Text tmpText;
    void Start()
    {
        tmpText = GetComponent<TMP_Text>();
        StartCoroutine(ChangeColor());
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