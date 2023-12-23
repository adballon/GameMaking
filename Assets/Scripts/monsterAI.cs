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
    public GameObject target; //�÷��̾�� target
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
    float meet_range = 0.5f;

    public Animator animator;
    public String WalkingState = "WalkState";
    public String isMove = "isMove";


    public int random()
    {
        return UnityEngine.Random.Range(0, 4);
    }
    public void knockBack_init()
    {
        curbackspeed = knockbackspeed;      // �˹� �ӵ� �ʱⰪ ����
        curbackspeed = 0;
        knockbackpower = 0.5f;
        curbackspeed = knockbackspeed + 3f;      // �˹� �ӵ� �ʱⰪ ����
        meet = true;
    }

    void OnCollisionEnter2D(Collision2D collision) //�÷��̾�� ������
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
            dir = getVec_dir(); //�������·� ��������
            Debug.Log(dir.x );
            transform.Translate(dir.normalized * Monster.Instance.speed * Time.deltaTime); //��ǥ�̵�

            if(dir.x > -meet_range && dir.x < meet_range) 
            {
                if (dir.y > 0)
                {
                    animator.SetInteger(WalkingState, 1);
                }
                else
                {
                    animator.SetInteger(WalkingState, 0);
                }
            }
            if(dir.x < -meet_range)
            {
                animator.SetInteger(WalkingState, 2);
            }
            if (dir.x > meet_range)
            {
                animator.SetInteger(WalkingState, 3);
            }
        }
    }
    void waiting(int j)
    {
        switch (j)
        {
            case 0:
                rb.MovePosition(rb.position + Vector2.down * Monster.Instance.speed * 3 * Time.deltaTime);
                break;
            case 1:
                rb.MovePosition(rb.position + Vector2.up * Monster.Instance.speed * 3 * Time.deltaTime);
                break;
            case 2:
                rb.MovePosition(rb.position + Vector2.left * Monster.Instance.speed * 3 * Time.deltaTime);
                break;
            case 3:
                rb.MovePosition(rb.position + Vector2.right * Monster.Instance.speed * 3 * Time.deltaTime);
                break;
        }
        animator.SetInteger(WalkingState, j);
    } //�����̵� ���Ѵ� XD


    private IEnumerator ExecuteWithDelay(float delayTime)
    {
        dire = random();
        yield return new WaitForSeconds(delayTime); //3�� ��ٷ� �ְ�
        waiting_exe = false; //�׸� ��������
        StopCoroutine(ExecuteWithDelay(delayTime));
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
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player");
        animator.SetBool(isMove, false);
        animator.SetInteger(WalkingState, 0);
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Instance = this;
    }

    void Update()
    {
        if (!meet) //�� ������
        {
            animator.SetBool(isMove, true);
            if (in_sight() == true) //�þ� �ȿ� �ִ�?
            {
                MoveToTarget(); //�׷� �۷� ��
            }
            else //�þ� �ȿ� ����
            {
                if (waiting_exe == false) //���� �����̰� �ִ� ���°� �ƴϴ�?
                {
                    waiting_exe = true; //������ �� �ִ� ���¸� ����� �ְ�
                    StartCoroutine(ExecuteWithDelay(delay)); //3�� ���� ������
                }
                else //������ �� �ִ� ���´�
                {
                    waiting(dire); //������
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (meet)
        {
            animator.SetBool (isMove, false);
            knockback();
        }
    }

}

//���� ���¸� �˷��ִ� ��ũ��Ʈ �ʿ�?
//���ͷ�Ʈ(ĳ���Ͱ� �׾����� ��Ҵ���)