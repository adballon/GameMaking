using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public Transform target;
    Monster enemy;
    float max(float a, float b)
    {
        if (a > b)
            return a;
        else
            return b;
    }
    float distance;

    void MoveToTarget()
    {
        float dir_x = target.position.x - transform.position.x;
        float dir_y = target.position.y - transform.position.y;
        float Max = max(dir_x, dir_y);
        if (dir_x < 0)
        {
            if (dir_x / Max > 0.5f)
                dir_x = -1 * dir_x / Max;
        }
        else
        {
            if (dir_x / Max > 0.5f)
                dir_x = dir_x / Max;
        }
        if (dir_y < 0)
        {
            if (dir_y / Max > 0.5f)
                dir_y = -1 * dir_y / Max;
        }
        else
        {
            if (dir_y / Max > 0.5f)
                dir_y = dir_y / Max;
        }
        transform.Translate(new Vector2(dir_x, dir_y) * enemy.speed * Time.deltaTime);
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
        distance = Vector3.Distance(transform.position, target.position);
        FaceTarget();
        MoveToTarget();
    }
}
