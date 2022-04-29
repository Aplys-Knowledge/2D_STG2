using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Player : MonoBehaviour
{

    private GameObject playerObject;

    private Rigidbody2D rb;
    private float v;
    private float h;

    private Vector3 charaV;

    private float moveSpeed = 10.0f;
   

    private void Ini(GameObject player)
    {
        playerObject = player;

        rb = GetComponent<Rigidbody2D>();

        

    }

    private void Rigid_Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        float moveX = h * moveSpeed * Time.fixedDeltaTime;
        float moveY = v * moveSpeed * Time.fixedDeltaTime;

        charaV = new Vector3(moveX, moveY, 0);

        rb.AddForce(charaV);

        Vector3 target_pos = new Vector3(transform.position.x + moveX, transform.position.y + moveY, 0);

        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, target_pos - transform.position);

        if(Mathf.Abs(h) >= 0.01f || Mathf.Abs(v) >= 0.01f)
        {
            rb.angularVelocity = 0.0f;

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.01f);
        }
    }





    // Start is called before the first frame update
    void Start()
    {
        Ini(this.gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigid_Move();
    }
}
