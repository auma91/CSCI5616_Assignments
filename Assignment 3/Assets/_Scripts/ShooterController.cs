using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float rate_of_fire;
    public GameObject bullet;
    public GameObject[] bullets;
    private float elapsed;
    private int index;
    void Start()
    {
        bullets = new GameObject[10];
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > 2/rate_of_fire) {
            //first fill up the list with game objects
            if (index < 10)
            {
                GameObject toAdd = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z-5f), Quaternion.Euler(-90, 0, 0));
                toAdd.transform.parent = gameObject.transform;
                toAdd.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                toAdd.GetComponent<particle_manager>().speed = Mathf.Abs(rate_of_fire * 10);
                toAdd.GetComponent<particle_manager>().one = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                toAdd.GetComponent<particle_manager>().two = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                bullets[index] = toAdd;
                elapsed = 0f;
                index++;
            }
            else {
                //so instead of Calling Destroy - lets not waste computation to reinstantiate an object, lets just change the postion of the exiting object
                //this is a more efficient solution in terms of skiping multiple instantiate/destroy calls a second
                //in order to simulate that i instantiated a new orb of light i have made a script thing here to adjust the color of the orb
                for (int i = 0; i < 10; i++) {
                    if (Vector3.Distance(bullets[i].transform.localPosition, Vector3.zero) > 30f) {
                        bullets[i].transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                        bullets[i].GetComponent<particle_manager>().speed = Mathf.Abs(rate_of_fire * 10);
                        bullets[i].GetComponent<particle_manager>().one = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                        bullets[i].GetComponent<particle_manager>().two = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                        
                        print("alot of distance");
                        break;
                    }
                    
                }
            }
            
            
        }

    }
}
