using UnityEngine;
using System.Collections;

public class BarrerHelp : MonoBehaviour
{
    float myTime = 0;
    int count_click = 0;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (count_click == 0)
            {
                count_click++;
                GameObject.Find("stvol3").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("touch").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("stvol3").GetComponent<Collider2D>().enabled = false;
                //GameObject.Find("BarrerHelp").GetComponent<Collider2D>().enabled = false;
                myTime = Time.realtimeSinceStartup;
                GameObject.Find("touch0").GetComponent<Transform>().position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 30));
                GameObject.Find("touch0").GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                if ((Time.realtimeSinceStartup - myTime) < 2)
                {
                    count_click = 0;
                    Vector2 help = (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,30)) - GameObject.Find("touch0").GetComponent<Transform>().position);
                    print(Time.realtimeSinceStartup - myTime);
                    //GameObject.Find("touch1").GetComponent<Transform>().position = GameObject.Find("touch0").GetComponent<Transform>().position + new Vector3(help.x, help.y);
                    //GameObject.Find("touch1").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("stvol3").GetComponent<Transform>().position = GameObject.Find("touch0").GetComponent<Transform>().position;
                    float angle = Vector2.Angle(Vector2.right, help);

                    if (help.y < 0)
                    {
                        angle = -angle;
                    }

                    GameObject.Find("stvol3").GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                    GameObject.Find("stvol3").GetComponent<SpriteRenderer>().enabled = true;
                    //GameObject.Find("BarrerHelp").GetComponent<Collider2D>().enabled = true;
                    GameObject.Find("touch").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("stvol3").GetComponent<Collider2D>().enabled = true;
                }

            }

        }
        if ((count_click > 0) && ((Time.realtimeSinceStartup - myTime) > 2))
        {
            print(Time.realtimeSinceStartup - myTime);
            count_click = 0;
            myTime = 0;
            //GameObject.Find("touch0").GetComponent<Transform>().position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            GameObject.Find("touch0").GetComponent<SpriteRenderer>().enabled = false;
        }

    }
    
}
