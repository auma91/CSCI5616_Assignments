using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 position;
    public float moveSpeed;
    public Vector3 scale = Vector3.one;
    public Vector3 rotation;
    float counter = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        this.transform.Translate(position * Time.deltaTime);
        this.transform.Rotate(rotation * Time.deltaTime);
        print(Time.deltaTime);
        print(counter);
    }
}
