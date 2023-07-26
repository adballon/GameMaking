using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public Transform target;
    Monster enemy;
    
    void MoveToTarget()
    {
        Vector3 dir = target.transform.position - transform.position; //�������·� ��������
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime); //��ǥ�̵�
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
