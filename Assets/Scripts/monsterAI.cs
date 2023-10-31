using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public Transform target; //플레이어는 target
    Monster enemy; //몬스터 정보는 enemy
    private bool meet = false;

    private float knockbackspeed = 0.5f;
    private float knockbackpower = 0.5f;
    float curbackspeed = 0;

    void OnCollisionEnter2D(Collision2D collision) //플레이어와 만났냐
    {
        if (collision.gameObject.tag == "Player")
        {
            curbackspeed = knockbackspeed + 0.7f;      // 넉백 속도 초기값 설정
            meet = true;
        }
    }
    Vector3 getVec_dir()
    {
        Vector3 re_dir = target.transform.position - transform.position;
        return re_dir;
    }
    void MoveToTarget()
    {
        if (meet == false)
        {
            Vector3 move_dir = getVec_dir(); //백터형태로 가져오고
            transform.Translate(move_dir.normalized * Monster.Instance.speed * Time.deltaTime); //좌표이동
            Debug.Log(enemy.speed);
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
        Vector3 kn_vec = getVec_dir();
        Vector3 back_dir;
        back_dir.x = -kn_vec.x;
        back_dir.y = -kn_vec.y;
        back_dir.z = -kn_vec.z;

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
