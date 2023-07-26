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
        Vector3 dir = target.transform.position - transform.position; //백터형태로 가져오고
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime); //좌표이동
    }

    void FaceTarget()
    {
        if (target.position.x - transform.position.x < 0) // 타겟이 왼쪽에 있을 때
        {
            transform.localScale = new Vector3(-3, 3, 3);
        }
        else // 타겟이 오른쪽에 있을 때
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
