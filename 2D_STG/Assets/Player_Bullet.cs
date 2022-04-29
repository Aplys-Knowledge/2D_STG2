using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    private int cnt = 0;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float angle = transform.rotation.eulerAngles.z;
        float ang = angle * Mathf.Deg2Rad;

        Vector3 direction = new Vector3(Mathf.Sin(ang) * -80f, Mathf.Cos(ang) * 80f, 0);

        rb.AddForce(direction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(cnt > 10)
        {
            Destroy(gameObject);
        }
        cnt++;
    }
}
