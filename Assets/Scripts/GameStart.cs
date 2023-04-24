using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField]
    private Transform ball;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform startpos;
    // Start is called before the first frame update
    private void Awake()
    {
        BallInHole.setPlayerBallStart(ball, player, startpos.position);
    }
}
