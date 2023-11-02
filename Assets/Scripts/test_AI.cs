using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_AI : MonoBehaviour
{
    public Transform target; //target에 위치정보만 가져옴
    Rigidbody2D rigid;

    bool in_sight()
    {
        target = GetComponent<Transform>();
        if (Vector2.Distance(transform.position, target.position) < Monster.Instance.vision)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void wait()
    {
        Vector3[] vec = { Vector3.up, Vector3.down, Vector3.left, Vector3.right };
        int temp = Random.Range(0,3);
        transform.Translate(vec[temp] * Monster.Instance.speed * Time.deltaTime);
    }
    void move_to_target()
    {

    }
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(in_sight())
        {
            move_to_target();
        }
        else
        {
            wait();
        }
    }
}
