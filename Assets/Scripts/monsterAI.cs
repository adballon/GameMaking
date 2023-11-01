using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class MonsterAI : MonoBehaviour
{
    public GameObject target; //�÷��̾�� target
    Monster enemy; //���� ������ enemy
    Vector3 dir;
     public bool meet = false;

    public float knockbackspeed;
    public float knockbackpower;
    float curbackspeed = 0;
    public float delay = 3.0f;

    void OnCollisionEnter2D(Collision2D collision) //�÷��̾�� ������
    {
        if (collision.gameObject.tag == "Player" && knockbackpower <= 0.5f)
        {
<<<<<<< Updated upstream
            curbackspeed = knockbackspeed;      // �˹� �ӵ� �ʱⰪ ����
=======
            curbackspeed = 0;
            knockbackpower = 0.5f;
            curbackspeed = knockbackspeed + 3f;      // �˹� �ӵ� �ʱⰪ ����
>>>>>>> Stashed changes
            meet = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
        }
    }
    void getVec_dir()
    {
        dir = target.transform.position - transform.position;
    }
    void MoveToTarget()
    {
        if (meet == false)
        {
<<<<<<< Updated upstream
            getVec_dir(); //�������·� ��������
            transform.Translate(dir.normalized * enemy.speed * Time.deltaTime); //��ǥ�̵�
=======
            Vector3 move_dir = getVec_dir(); //�������·� ��������
            transform.Translate(move_dir.normalized * Monster.Instance.speed * Time.deltaTime); //��ǥ�̵�
            //Debug.Log(enemy.speed);
>>>>>>> Stashed changes
        }
        //else
        //{
        //    knockback();
        //}
    }
    void waiting()
    {
        int i = UnityEngine.Random.Range(0, 3);
        Debug.Log(i);
        switch(i)
        {
            case 0:
                transform.Translate(Vector3.down * Monster.Instance.speed * Time.deltaTime);
                break;
            case 1:
                transform.Translate(Vector3.up * Monster.Instance.speed * Time.deltaTime);
                break;
            case 2:
                transform.Translate(Vector3.left * Monster.Instance.speed * Time.deltaTime);
                break;
            case 3:
                transform.Translate(Vector3.right * Monster.Instance.speed * Time.deltaTime);
                break;
        }
    }

    private IEnumerator ExecuteWithDelay(float delayTime)
    {
        // n�� ���� showAttackRange �Լ� ����
        // n�� ���� ���
        waiting();
        yield return new WaitForSeconds(delayTime);
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
        getVec_dir();
        Vector3 back_dir;
<<<<<<< Updated upstream
        back_dir.x = -dir.x;
        back_dir.y = -dir.y;
        back_dir.z = -dir.z;
=======
        back_dir.x = -(kn_vec.x);
        back_dir.y = -(kn_vec.y);
        back_dir.z = -(kn_vec.z);
        float temp = back_dir.magnitude;
>>>>>>> Stashed changes

        curbackspeed -= Time.deltaTime * knockbackpower;
        knockbackpower += 0.01f;
        
        //Debug.Log(curbackspeed);
        if (curbackspeed <= 0)
        {
            knockbackpower = 0.5f;
            meet = false;
            return;
            //Debug.Log(curbackspeed);
        }
        else
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.MovePosition(transform.position + back_dir.normalized * curbackspeed * Time.deltaTime);
        }
    }
    bool in_sight()
    {
        //Debug.Log("this" + vec);
        //Debug.Log("target" + target.transform.position);
        //Debug.Log("distance" + Vector2.Distance(transform.position, vec));
        //Debug.Log("sight" + Monster.Instance.fieldOfVision);
        if (Vector2.Distance(transform.position, target.transform.position) < Monster.Instance.fieldOfVision)
        {
            
            return true;
        }
        else
        {
            return false;
        }
    }
    void invoke_wait()
    {

    }
    void Start()
    {
        enemy = GetComponent<Monster>(); //Monster�� ���� ������ enemy��
    }

    void Update()
    {
        FaceTarget();
<<<<<<< Updated upstream
        MoveToTarget();
        if(meet)
=======
        if(in_sight() == true) 
        {
            MoveToTarget();
        }
    }
    private void FixedUpdate()
    {
        if (meet)
        {
>>>>>>> Stashed changes
            knockback();
        }
    }
}
