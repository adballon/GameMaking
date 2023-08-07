using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public Transform target; //플레이어는 target
    Monster enemy; //몬스터 정보는 enemy
    Vector3 dir;
    bool meet = false;

    public float knockbackspeed;
    public float knockbackpower;
    float curbackspeed = 0;

    void OnCollisionEnter2D(Collision2D collision) //플레이어와 만났냐
    {
        if (collision.gameObject.tag == "Player")
        {
            meet = true;
            curbackspeed = knockbackspeed;      // 넉백 속도 초기값 설정
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
            getVec_dir(); //백터형태로 가져오고
            transform.Translate(dir.normalized * enemy.speed * Time.deltaTime); //좌표이동
        }
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
    void knockback()
    {

        getVec_dir();
        Vector3 back_dir;
        back_dir.x = -dir.x;
        back_dir.y = -dir.y;
        back_dir.z = -dir.z;
        //transform.Translate(back_dir.normalized * 100f * Time.deltaTime);

        curbackspeed -= Time.deltaTime * knockbackpower;
        transform.Translate(back_dir * curbackspeed * Time.deltaTime);
        //Debug.Log(curbackspeed);

        if (curbackspeed < 0)
            meet = false;
    }
    void Start()
    {
        enemy = GetComponent<Monster>(); //Monster에 대한 정보를 enemy에
    }

    void Update()
    {
        FaceTarget();
        MoveToTarget();
        if(meet)
            knockback();
    }
}
