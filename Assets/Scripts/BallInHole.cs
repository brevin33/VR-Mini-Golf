using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInHole : MonoBehaviour
{
    public int hole;
    public static List<int> strokesByHole;
    public Transform nextHole;
    [SerializeField]
    public static Transform player;
    [SerializeField]
    public static Transform ball;
    public AfterHoleMenu menu;
    [SerializeField]
    public static Vector3 startPos;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ball")
        {
            int strokes = other.gameObject.GetComponent<BallHit>().strokes;
            strokesByHole[hole] = other.gameObject.GetComponent<BallHit>().strokes;
            other.gameObject.GetComponent<BallHit>().strokes = 0;
            menu.showAndUpdate(strokesByHole[hole]);
            MenuStrokes.updateStrokes(strokesByHole);
            StartCoroutine(goNextHole(3));
        }
    }

    IEnumerator goNextHole(int secs)
    {
        yield return new WaitForSeconds(1);
        player.position = nextHole.position;
        yield return new WaitForSeconds(secs);
        ball.position = nextHole.position;
    }
    public static void ResetGame()
    {
        ball.position = startPos;
        player.position = startPos;
        strokesByHole = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        ball.gameObject.GetComponent<BallHit>().strokes = 0;
    }

    public static void setPlayerBallStart(Transform Ball, Transform Player,Vector3 start)
    {
        ball = Ball;
        player = Player;
        startPos = start;
    }

    private void Start()
    {
        ResetGame();
    }
    private void startHole()
    {
        ball.position = nextHole.position;
        player.position = new Vector3(ball.position.x,ball.position.y + 1,ball.position.z);
    }

}
