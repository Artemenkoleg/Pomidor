using UnityEngine;
using System.Collections;

public class StvolBarrerHelp : MonoBehaviour
{
    
	void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        Pomidor pomidor = collision.gameObject.GetComponent<Pomidor>();
        if (pomidor != null)
        {
            GameObject.Find("stvol3").GetComponent<Collider2D>().enabled = false;
            GameObject.Find("stvol3").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("touch0").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("touch").GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
