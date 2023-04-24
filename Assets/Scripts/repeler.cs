using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeler : MonoBehaviour
{
    public float power;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            Rigidbody ball = other.gameObject.GetComponent<Rigidbody>();
            Vector3 dir = (other.transform.position - transform.position);
            dir.y = 0;
            dir = dir.normalized;
            ball.AddForce(dir*power * Time.deltaTime);
        }
    }


}
