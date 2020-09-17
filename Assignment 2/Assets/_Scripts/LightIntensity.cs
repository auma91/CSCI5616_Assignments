using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour
{
    private Light light;
    public float phase_speed = 1;
    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        angle = 0f;
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime * phase_speed;
        light.intensity = 2*Mathf.Sin(angle) + 6f;
    }
}
