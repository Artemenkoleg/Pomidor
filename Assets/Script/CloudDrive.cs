using UnityEngine;
using System.Collections;

public class CloudDrive : MonoBehaviour
{
    Vector3 velocity;
	
	void Start ()
    {
        velocity = new Vector3(-Random.Range(0.1f,0.7f), 0, 0);
    }
	

	void Update ()
    {
        transform.position += velocity * Time.deltaTime;
        if(transform.position.x <= -15)
        {
            transform.position = new Vector3(15, transform.position.y, transform.position.z);
        }
    }
}
