using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState GameState;
    public TMP_Text TMP_Text;

    private void Start()
    {
        GameState.isPlaying = false;
    }
    private void Update()
    {
        if (GameState == null)
        {
            return;
        }

        if (!GameState.isPlaying)
        {
            if (Input.anyKey)
            {
                GameState.isPlaying = true;
                TMP_Text.enabled = false;
            }
        }
    }
}
