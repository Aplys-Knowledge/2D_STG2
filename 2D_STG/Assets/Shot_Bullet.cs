using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot_Bullet : MonoBehaviour
{

    private int Max_energy = 1200;
    private int energy = 1200;

    private int t = 60;

    private GameObject bullet = null;
    private Image Gauge_Img;



    // Start is called before the first frame update
    void Start()
    {
        bullet = (GameObject)Resources.Load("Bullet");

        Gauge_Img = GameObject.Find("ENG").GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        if(t >= 60)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if(bullet != null)
                {
                    if(energy >= 240)
                    {
                        Instantiate(bullet, transform.position, transform.rotation);
                        t = 0;
                        energy -= 240;
                    }
                }
            }
        }
        else
        {
            t++;
        }

        if(energy < Max_energy)
        {
            energy += 1;
        }

        Gauge_Img.transform.localScale = new Vector3((energy / (float)Max_energy), 1, 1);

    }

    


}
