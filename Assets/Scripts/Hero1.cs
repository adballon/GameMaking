using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class Hero1 : MonoBehaviour
{
    public GameObject hero;

    public float attack = 5f;
    public float speed = 5f;

    Vector2 movement = new Vector2();

    Rigidbody2D rigid;

    Animator animator;

    string animator_state = "AnimationState";
    string isMove = "isMove";

    enum States
    {
        back = 1,
        front = 2,
        left = 3,
        right = 4
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

        animator.SetInteger(animator_state, (int)States.front);
        animator.SetBool(isMove, false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        rigid.velocity = movement * speed;
    }

    private void UpdateState()
    {
        if(movement.x < 0)
        {
            animator.SetInteger(animator_state, (int)States.left);
            animator.SetBool(isMove, true);
        }
        else if(movement.x > 0)
        {
            animator.SetInteger(animator_state, (int)States.right);
            animator.SetBool(isMove, true);
        }
        else if (movement.y < 0)
        {
            animator.SetInteger(animator_state, (int)States.front);
            animator.SetBool(isMove, true);
        }
        else if (movement.y > 0)
        {
            animator.SetInteger(animator_state, (int)States.back);
            animator.SetBool(isMove, true);
        }
        else
        {
            animator.SetBool(isMove, false);
        }
    }
}
