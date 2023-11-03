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
    public bool meet = false;

    public float knockbackspeed;
    public float knockbackpower;
    float curbackspeed = 0;
    public float delay = 3.0f;
    bool waiting_exe = false;
    int j;

    public int ran()
    {
        return UnityEngine.Random.Range(0, 4); //������ �ּ����� ~ �ִ����� -1
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
            transform.Translate(dir.normalized * Monster.Instance.speed * Time.deltaTime); //��ǥ�̵�
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
    } //�����̵��ϳ� �ù�


    private IEnumerator ExecuteWithDelay(float delayTime)
    {
        // n�� ���� showAttackRange �Լ� ����
        // n�� ���� ���
        j = ran(); //���� �Լ�
        yield return new WaitForSeconds(delayTime);
        waiting_exe = false;
        //�ڷ�ƾ ����
        StopCoroutine(ExecuteWithDelay(delayTime));
    }
    void FaceTarget()
    {
        if (target.transform.position.x - transform.position.x < 0) // Ÿ���� ���ʿ� ���� ��
        {
            transform.localScale = new Vector3(-5, 5, 5);
        }
        else // Ÿ���� �����ʿ� ���� ��
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