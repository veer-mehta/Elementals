using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerAir : MonoBehaviour
{
    [SerializeField] float superJumpForce;
    [SerializeField] GameObject AirTrail;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void UsePower()
    {
        GameObject trail = Instantiate(AirTrail, transform.position, Quaternion.identity);
        rb.velocity = new Vector2(rb.velocity.x, superJumpForce);
        Destroy(trail, 0.6f);
    }

}
