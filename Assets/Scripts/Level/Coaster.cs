using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

public class Coaster : MonoBehaviour
{
    
    public GameState gameState;
    public float speed = 5.0f;
    private SplineAnimate splineAnim;

    private void Start()
    {
        splineAnim = GetComponent<SplineAnimate>();
        splineAnim.Pause();
    }
    void Update()
    {
        if (gameState.isPlaying && !splineAnim.IsPlaying)
        {
            splineAnim.Play();
        }
        if (!gameState.isPlaying)
        {
            splineAnim.Pause();
        }
    }
}
