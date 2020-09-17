using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingOrbs : MonoBehaviour

{
    // Start is called before the first frame update
    public float bouncingspeed = 1;
    private float start;
    public float phase;
    public float magnitude;
    void Start()
    {
        start = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, magnitude*Mathf.Sin(Time.time*bouncingspeed+phase)+start, transform.localPosition.z);
    }
}
