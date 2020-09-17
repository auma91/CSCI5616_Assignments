using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_manager : MonoBehaviour
{
    // Start is called before the first frame update
    //ParticleSystem m_System;
    public float speed;
    private Light light;
    private float angle = 0f;
    public float phase_speed = 1;
    public Color one = Color.white;
    public Color two = Color.white;
    void Start()
    {
        //at init lets adjust some of the particle system properties
        ParticleSystem ps = GetComponent<ParticleSystem>();
        light = GetComponent<Light>();
        var col = ps.colorOverLifetime;
        col.enabled = true;
        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(one, 0.0f), new GradientColorKey(two, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.75f, 1.0f) });
        light.color = (one + two) / 2;
        col.color = grad;
    }

    // Update is called once per frame
    void Update()
    {
        //here i do the behavior of the movment and the light
        angle += Time.deltaTime * phase_speed;
        light.intensity = 2 * Mathf.Sin(angle) + 6f;
        transform.Translate((-speed * Vector3.up) * Time.deltaTime);

        ParticleSystem ps = GetComponent<ParticleSystem>();
        light = GetComponent<Light>();
        var col = ps.colorOverLifetime;
        col.enabled = true;
        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(one, 0.0f), new GradientColorKey(two, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.75f, 1.0f) });
        light.color = (one + two) / 2;
        col.color = grad;

    }
}
