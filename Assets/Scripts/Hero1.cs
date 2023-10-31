using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Hero1 : MonoBehaviour
{
    public GameObject hero;

    public static Hero1 Instance;

    public float attack = 5f; //공격력
    public float attack_range = 0f;
    public float speed = 5f;  //스피드
    public float defend = 5f;  //방어력
    public float luck = 5f;  //운
    public float maxManaPoint = 100f;  //최대 마나
    public float maxhitPoint = 100f;  //최대 체력
    
    
    public float hitPoint = 50f;  //현재 체력   
    public float manaPoint = 50f; //현재 마나
    public float regenhit = 0.1f;  //체력 리젠
    public float regemana = 0.1f;  //마나 리젠

    public int lastinput = 1;
    public float delayTime = 0.5f;
    Vector2 movement = new Vector2();

    Rigidbody2D rigid;

    public Animator animator;

    public string animator_state = "AnimationState";
    //string isAttack = "isAttack";
    
    

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
        
        if(collision.gameObject.tag == "Portal")
        {
            transform.position = new Vector3(0, 100, 0);
            Destroy(collision.gameObject);
        }

        if (HealthySystem.Instance.hitPoint == 0)
        {
            Destroy(hero);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(0, 0, 0);
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        animator.SetInteger(animator_state, (int)States.front);
        animator.SetBool("isMove", false);
    }

    private IEnumerator ExecuteWithDelay(float delayTime)
    {
        // n초 동안 showAttackRange 함수 실행
        Hero_Attack.Instance.showAttackRange();

        // n초 동안 대기
        yield return new WaitForSeconds(delayTime);

        Hero_Attack.Instance.setActiveRange();
        //코루틴 종료
        StopCoroutine(ExecuteWithDelay(delayTime));
    }

// Update is called once per frame
void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) //공격키를 눌렀다
        {
            animator.SetTrigger("Attack");
            StartCoroutine(ExecuteWithDelay(delayTime));
        }
        else
        {
            ani_move();
        }

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

    private void ani_move()
    {
        if (movement.x < 0)
        {
            animator.SetInteger(animator_state, (int)States.left);
            animator.SetBool("isMove", true);
            lastinput = (int)States.left;
        }
        else if (movement.x > 0)
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
    }
}
