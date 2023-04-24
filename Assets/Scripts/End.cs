using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField]
    private int strokes;
    public BallHit ball;
    [SerializeField] GameObject endText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            ball.strokes += strokes;
            ball.strokesTotal += strokes;
            BallInHole.strokesByHole[8] = other.gameObject.GetComponent<BallHit>().strokes;
            MenuStrokes.updateStrokes(BallInHole.strokesByHole);
            endText.SetActive(true);
            StartCoroutine(passiveMe(20));
        }
    }

    IEnumerator passiveMe(int secs)
    {
        yield return new WaitForSeconds(secs);
        endText.SetActive(false);
        BallInHole.ResetGame();
    }
}
