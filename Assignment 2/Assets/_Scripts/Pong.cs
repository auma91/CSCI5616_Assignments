using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 initialVelocity;

    private float minVelocity = 10f;
    public Light light;
    private Vector3 lastFrameVelocity;
    private Rigidbody rb;
    private int currentColorindex;
    private Color[] colorsList = new Color[4] { Color.white, Color.red, Color.blue, Color.green };
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        lastFrameVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bounce(collision.contacts[0].normal);
        light.color = colorsList[currentColorindex];
    }

    private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);
        rb.velocity = new Vector3(direction.x,direction.y,direction.z) * Mathf.Max(speed, minVelocity);
        if (currentColorindex == colorsList.Length - 1)
        {
            currentColorindex = 0;
        }
        else {
            currentColorindex++;
        }
    }
}
