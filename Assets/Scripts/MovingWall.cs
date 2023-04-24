using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform point1;
    [SerializeField]
    private Transform point2;
    private bool point1Active = true;
    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        if (point1Active)
        {
            float dist = Vector3.Distance(point1.position, transform.position);
            if (dist <= .2)
            {
                point1Active = false;
            }
            transform.position = Vector3.Lerp(transform.position, point1.transform.position,dt/speed);
        }
        else
        {
            float dist = Vector3.Distance(point2.position, transform.position);
            if (dist <= .05)
            {
                point1Active = true;
            }
            transform.position = Vector3.Lerp(transform.position, point2.transform.position, dt / speed);
        }
    }
}
