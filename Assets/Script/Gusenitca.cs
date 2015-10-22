using UnityEngine;
using System.Collections;

public class Gusenitca : MonoBehaviour
{
    Animator animator;
    //Animation anim;
    //public bool contactPom = false;

    void Start ()
    {
        animator = GetComponent<Animator>();
        animator.speed = Random.Range(0.65f, 0.75f);
        //anim = GetComponent<Animation>();
    }
	

	void Update ()
    {
       
        /*
        if(anim.IsPlaying("BumAnim"))
        {
            DestroyImmediate(gameObject);
        }
        */
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Pomidor pomidor = collision.gameObject.GetComponent<Pomidor>();
        if (pomidor != null)
        {
            GetComponent<CircleCollider2D>().enabled = false;
            Account.accountNum += 10;
            Account.changeAccount = true;
            animator.SetBool("contactPom", true);
            //contactPom = true;
        }
    }

    void DestroyObj()
    {
        Destroy(gameObject);
    }
}
