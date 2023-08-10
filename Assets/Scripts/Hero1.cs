using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class Hero1 : MonoBehaviour
{
    public GameObject hero;

    public static Hero1 Instance;

    public float attack = 5f;
    public float speed = 5f;
    public float hitPoint = 50f;
    public float maxhitPoint = 100f;
    public float manaPoint = 50f;
    public float maxManaPoint = 100f;
    public float healPoint = 0.1f;
    public float regemana = 0.1f;

    Vector2 movement = new Vector2();

    Rigidbody2D rigid;

    Animator animator;

    public bool MoveRoom = false; //문에 닿아서 다음 방으로 가는가

    string animator_state = "AnimationState";
    //string isMove = "isMove";
    int lastinput = 0;

    void Awake()
    {
        Instance = this;
    }

    enum States
    {
        back = 1,
        front = 2,
        left = 3,
        right = 4
    }

    enum Attack
    {
        back = 5,
        front = 6,
        left = 7,
        right = 8
    }

    public void TakeDamage(float Damage) //데미지 입는 함수
    {
        hitPoint -= Damage;
        if (hitPoint < 1)
            hitPoint = 0;
    }

        private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            TakeDamage(5);
            //Debug.Log(HealthySystem.Instance.hitPoint);
        }

        if(HealthySystem.Instance.hitPoint == 0)
        {
            Destroy(hero);
        }

        if(collision.gameObject.tag == "Door")
        {
            MoveRoom = true;
            TakeDamage(5);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(0, 0, 0);
        rigid= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        animator.SetInteger(animator_state, (int)States.front);
        animator.SetBool("isMove", false);
        Debug.Log(HealthySystem.Instance.maxManaPoint);
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
            animator.SetBool("isMove", true);
            lastinput = (int)States.left;
        }
        else if(movement.x > 0)
        {
            animator.SetInteger(animator_state, (int)States.right);
            animator.SetBool("isMove", true);
            lastinput = (int)States.right;
        }
        else if (movement.y < 0)
        {
            animator.SetInteger(animator_state, (int)States.front);
            animator.SetBool("isMove", true);
            lastinput = (int)States.front;

        }
        else if (movement.y > 0)
        {
            animator.SetInteger(animator_state, (int)States.back);
            animator.SetBool("isMove", true);
            lastinput = (int)States.back;
        }
        else
        {
            animator.SetBool("isMove", false);
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            animator.SetTrigger("Attacktrigger");
            
            if (lastinput == (int)States.left)
            {
                animator.SetInteger(animator_state, (int)Attack.left);
            }
            else if (lastinput == (int)States.right)
            {
                animator.SetInteger(animator_state, (int)Attack.right);
            }
            else if (lastinput == (int)States.front)
            {
                animator.SetInteger(animator_state, (int)Attack.front);

            }
            else if (lastinput == (int)States.back)
            {
                animator.SetInteger(animator_state, (int)Attack.back);
            }
        }
    }
}
