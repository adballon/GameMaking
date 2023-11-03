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
    public bool meet = false;

    public float knockbackspeed;
    public float knockbackpower;
    float curbackspeed = 0;
    public float delay = 3.0f;
    bool waiting_exe = false;
    int j;

    public int ran()
    {
        return UnityEngine.Random.Range(0, 4); //랜덤은 최소정수 ~ 최대정수 -1
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
    void waiting()
    {
        switch (j)
        {
            case 0:
                rb.MovePosition(rb.position + Vector2.up * Monster.Instance.speed * 2 * Time.deltaTime);
                break;
            case 1:
                rb.MovePosition(rb.position + Vector2.down * Monster.Instance.speed * 2 * Time.deltaTime);
                break;
            case 2:
                rb.MovePosition(rb.position + Vector2.left * Monster.Instance.speed * 2 * Time.deltaTime);
                break;
            case 3:
                rb.MovePosition(rb.position + Vector2.right * Monster.Instance.speed * 2 * Time.deltaTime);
                break;

        }
    } //순간이동하네 시발


    private IEnumerator ExecuteWithDelay(float delayTime)
    {
        // n초 동안 showAttackRange 함수 실행
        // n초 동안 대기
        j = ran(); //랜덤 함수
        yield return new WaitForSeconds(delayTime);
        waiting_exe = false;
        //코루틴 종료
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

    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Instance = this;
    }

    void Update()
    {
        FaceTarget();
        if (!meet)
        {
            if (in_sight() == true)
            {
                MoveToTarget();
            }
            else
            {
                if (waiting_exe == false)
                {
                    waiting_exe = true;
                    StartCoroutine(ExecuteWithDelay(delay));
                }
                waiting();
            }
        }
    }

    private void FixedUpdate()
    {
        if(meet)
        {
            knockback();
        }
    }

}