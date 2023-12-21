using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class MonsterAI : MonoBehaviour
{
    public static MonsterAI Instance;
    public GameObject target; //플레이어는 target
    Rigidbody2D rb;
    Vector3 dir;
    Vector3 prepos;
    public bool meet = false;

    public float knockbackspeed;
    public float knockbackpower;
    float curbackspeed = 0;
    public float delay = 3.0f;
    bool waiting_exe = false;
    public int dire = 0;

    //public Animator animator;
    //public String WalkingState = "WalkState";
    //public String isMove = "isMove";

    //enum State
    //{
    //    front = 0,
    //    back = 1,
    //    left = 2,
    //    right = 3
    //}

    public int random()
    {
        return UnityEngine.Random.Range(0, 4);
    }
    public void knockBack_init()
    {
        curbackspeed = knockbackspeed;      // 넉백 속도 초기값 설정
        curbackspeed = 0;
        knockbackpower = 0.5f;
        curbackspeed = knockbackspeed + 3f;      // 넉백 속도 초기값 설정
        meet = true;
    }

    void OnCollisionEnter2D(Collision2D collision) //플레이어와 만났냐
    {
        if (collision.gameObject.tag == "Player" && knockbackpower <= 0.5f)
        {
            knockBack_init();
        }
    }

    Vector3 getVec_dir()
    {
        return target.transform.position - transform.position;
    }
    void MoveToTarget()
    {
        if (meet == false)
        {
            dir = getVec_dir(); //백터형태로 가져오고
            transform.Translate(dir.normalized * Monster.Instance.speed * Time.deltaTime); //좌표이동
        }
    }
    void waiting(int j)
    {
        switch (j)
        {
            case 0:
                rb.MovePosition(rb.position + Vector2.up * Monster.Instance.speed * 3 * Time.deltaTime);
                //animator.SetInteger(WalkingState, (int)State.back);
                break;
            case 1:
                rb.MovePosition(rb.position + Vector2.down * Monster.Instance.speed * 3 * Time.deltaTime);
                //animator.SetInteger(WalkingState, (int)State.front);
                break;
            case 2:
                rb.MovePosition(rb.position + Vector2.left * Monster.Instance.speed * 3 * Time.deltaTime);
                //animator.SetInteger(WalkingState, (int)State.left);
                break;
            case 3:
                rb.MovePosition(rb.position + Vector2.right * Monster.Instance.speed * 3 * Time.deltaTime);
                //animator.SetInteger(WalkingState, (int)State.right);
                break;

        }
    } //순간이동 안한다 XD


    private IEnumerator ExecuteWithDelay(float delayTime)
    {
        dire = random();
        yield return new WaitForSeconds(delayTime);
        waiting_exe = false;
        //animator.SetBool(isMove, false);
        StopCoroutine(ExecuteWithDelay(delayTime));
    }
    void FaceTarget()
    {
        if (target.transform.position.x - transform.position.x < 0) // 타겟이 왼쪽에 있을 때
        {
            transform.localScale = new Vector3(-5, 5, 5);
        }
        else // 타겟이 오른쪽에 있을 때
        {
            transform.localScale = new Vector3(5, 5, 5);
        }
    }
    void knockback()
    {
        dir = getVec_dir();
        Vector3 back_dir;
        back_dir.x = -dir.x;
        back_dir.y = -dir.y;
        back_dir.z = -dir.z;
        float temp = back_dir.magnitude;

        curbackspeed -= Time.deltaTime * knockbackpower;
        knockbackpower += 0.01f;

        if (curbackspeed <= 0)
        {
            knockbackpower = 0.5f;
            meet = false;
            return;
        }
        else
        {
            rb.MovePosition(transform.position + back_dir.normalized * curbackspeed * Time.deltaTime);
        }
    }
    bool in_sight()
    {
        if (Vector2.Distance(transform.position, target.transform.position) < Monster.Instance.vision)
        {

            return true;
        }
        else
        {
            return false;
        }
    }
    void Start()
    {
        //animator.SetBool(isMove, false);
        //animator.SetInteger(WalkingState, 0);
        target = GameObject.FindWithTag("Player");
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Instance = this;
    }

    void Update()
    {
        FaceTarget();
        if (!meet) //안 만났다
        {
            if (in_sight() == true) //시야 안에 있다?
            {
                MoveToTarget(); //그럼 글로 가
            }
            else //시야 안에 없어
            {
                if (waiting_exe == false) //지금 움직이고 있는 상태가 아니다?
                {
                    waiting_exe = true; //움직일 수 있는 상태를 만들어 주고
                    //animator.SetBool(isMove, true);
                    StartCoroutine(ExecuteWithDelay(delay)); //3초 세
                }
                else //움직일 수 있는 상태다
                {
                    waiting(dire); //움직여
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (meet)
        {
            knockback();
        }
    }

}

//게임 상태를 알려주는 스크립트 필요?
//인터럽트(캐릭터가 죽었는지 살았는지)