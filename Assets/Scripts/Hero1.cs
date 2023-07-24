using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero1 : MonoBehaviour
{
    public GameObject hero;

    public float attack = 5f;
    public float speed = 5f;

    Vector2 movement = new Vector2();

    Rigidbody2D rigid;

    Animator animator;

    string animator_state = "animate_state";

    enum State
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            HealthySystem.Instance.TakeDamage(5);
            Debug.Log(HealthySystem.Instance.hitPoint);
        }

        if(HealthySystem.Instance.hitPoint == 0)
        {
            Destroy(hero);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        rigid= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        rigid.velocity = movement * speed;
    }
}
