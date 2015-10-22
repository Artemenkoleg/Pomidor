using UnityEngine;
using System.Collections;

public class Pomidor : MonoBehaviour
{
    public Vector3 velocityPlayer;
    public Vector3 velocityCamera;

    void Start ()
    {
        velocityPlayer = new Vector3(1.0f, 1.0f);
        velocityCamera = new Vector3(0.125f, 0.125f);
    }
	


	void Update ()
    {
        
        // выход из игры
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        transform.position += velocityPlayer * Time.deltaTime;
        GameObject.Find("Main Camera").transform.position = new Vector3(transform.position.x / 2, transform.position.y / 2, GameObject.Find("Main Camera").transform.position.z);
        //GameObject.Find("Main Camera").transform.position += velocityCamera * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        velocityPlayer = Vector3.Reflect(velocityPlayer, collision.contacts[0].normal);
        velocityCamera = Vector3.Reflect(velocityCamera, collision.contacts[0].normal);

        if (((velocityPlayer.x < 0) && (GameObject.Find("PlayerFace").GetComponent<Transform>().localScale.x > 0)) || 
            ((velocityPlayer.x > 0) && (GameObject.Find("PlayerFace").GetComponent<Transform>().localScale.x < 0)))
        {
            GameObject.Find("PlayerFace").GetComponent<Transform>().localScale = new Vector3(-GameObject.Find("PlayerFace").GetComponent<Transform>().localScale.x,
                                                                                              GameObject.Find("PlayerFace").GetComponent<Transform>().localScale.y,
                                                                                              GameObject.Find("PlayerFace").GetComponent<Transform>().localScale.z);
            GameObject.Find("PomidorAtlas_7").GetComponent<Transform>().localScale = new Vector3(-GameObject.Find("PomidorAtlas_7").GetComponent<Transform>().localScale.x,
                                                                                                    GameObject.Find("PomidorAtlas_7").GetComponent<Transform>().localScale.y,
                                                                                                    GameObject.Find("PomidorAtlas_7").GetComponent<Transform>().localScale.z);
        }
    }
}
