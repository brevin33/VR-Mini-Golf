using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubSpeed : MonoBehaviour
{
    private Vector3 oldPosition;
    private Vector3 speed;
    // Start is called before the first frame update
    void Start()
    {
        oldPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        speed =  ((speed * 0.6f) + ((oldPosition - transform.position) * 0.4f));
        speed.y = 0;
        oldPosition = transform.position;
    }

    public Vector3 getClubSpeed()
    {
        return speed;
    }
}
