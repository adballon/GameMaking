using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public Transform target;
    Monster enemy;
    Vector3 dir;
    bool meet = false;
    void OnCollisionEnter2D(Collision2D collision) //�÷��̾�� ������
    {
        if (collision.gameObject.tag == "Player")
        {
            knockback();
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
            getVec_dir(); //�������·� ��������
            transform.Translate(dir.normalized * enemy.speed * Time.deltaTime); //��ǥ�̵�
        }
    }
    void FaceTarget()
    {
        if (target.position.x - transform.position.x < 0) // Ÿ���� ���ʿ� ���� ��
        {
            transform.localScale = new Vector3(-3, 3, 3);
        }
        else // Ÿ���� �����ʿ� ���� ��
        {
            transform.localScale = new Vector3(3, 3, 3);
        }
    }
    void knockback()
    {
        meet = true;
        getVec_dir();
        Vector3 back_dir;
        back_dir.x = -dir.x;
        back_dir.y = -dir.y;
        back_dir.z = -dir.z;
        transform.Translate(back_dir.normalized * 100f * Time.deltaTime);
        meet = false;
    }
    void Start()
    {
        enemy = GetComponent<Monster>();
    }

    void Update()
    {
        FaceTarget();
        MoveToTarget();
    }
}
