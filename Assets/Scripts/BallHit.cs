using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallHit : MonoBehaviour
{
    private float hitCooldown;
    private Rigidbody ball;
    public float hitCooldownTime;
    public float hitPower;
    public ClubSpeed clubspeed;
    public BoxCollider clubHitBox;
    public int strokes;
    [SerializeField]
    public AudioSource hitSound;
    public int strokesTotal;
    public Vector3 lastPos;
    float lastvelocityy;
    private void OnTriggerEnter(Collider other)
    {
        // ball out of bounds
        if (other.gameObject.name == "out")
        {
            transform.position = lastPos;
            ball.velocity = Vector3.zero;
        }

        // hit ball
        if ((other.gameObject.name == "club" || other.gameObject.name == "club small" || other.gameObject.name == "club mid") && hitCooldown <= 0)
        {
            lastPos = transform.position;
            hitSound.Play();
            strokes += 1;
            strokesTotal += 1;
            hitCooldown = hitCooldownTime;
            Vector3 clubSpeed = other.gameObject.GetComponent<ClubSpeed>().getClubSpeed();
            Vector3 force = Vector3.Scale((clubSpeed * hitPower), (clubSpeed * hitPower)) * -1;
            force.x = force.x * (clubSpeed.x < 0 ? -1 : 1);
            force.z = force.z * (clubSpeed.z < 0 ? -1 : 1);
            ball.AddForce(force);
            clubHitBox.enabled = false;
        }

    }
    // Start is called before the first frame update
    private void Awake()
    {
        ball = GetComponent<Rigidbody>();
        strokes = 0;
        lastPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        hitCooldown -= Time.deltaTime;
        if (hitCooldown <= 0)
        {
            clubHitBox.enabled = true;
        }
        if (ball.velocity.y > 1.0f)
        {
            ball.velocity = new Vector3(ball.velocity.x, ball.velocity.y * 0.9f, ball.velocity.z);
        }
        if ((ball.velocity.y - lastvelocityy > 0.28f))
        {
            ball.velocity = new Vector3(ball.velocity.x, ball.velocity.y * 0.5f, ball.velocity.z);
        }
        lastvelocityy = ball.velocity.y;
    }
}
