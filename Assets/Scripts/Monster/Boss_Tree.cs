using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Tree : MonoBehaviour
{
    //보스마다 따로따로 독자적인 스크립트를 짤거임
    public float hp, atk, defend, speed; //보스들의 변수는 hp, atk, ~~~로 고정
    string boss_name = "저주받은 나무"; //보스 이름 변수는 boss_name으로 고정
    //보스 이름은 상단에 체력바와 함께 표기
    public GameObject bullet_prefab; //공격모션에 사용될 총알 프리팹
    public GameObject target; //플레이어가 타겟
    Rigidbody2D rb;
    float timer; //시간 지연
    float waitingTime;
    int now_room; //보스룸은 visited가 12개 visited == 12
    public static Boss_Tree Instance;
    float delay_time;
    public Animator ani; //animation

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        hp = 1000f; //일반 몹의 10배
        atk = 20f; //일반몹의 4배
        defend = 10f; //방어개념 추가
        speed = 0.4f; //나무보스답게 느림(일반몹의 10%)
        target = GameObject.FindWithTag("Player"); //target으로 player 찾기
        rb = GetComponent<Rigidbody2D>();
        timer = 0f;
        waitingTime = 2.0f;
        delay_time = 0f;
        ani = GetComponent<Animator>();
        ani.SetBool("moving", false);
        ani.SetInteger("dir", 0);
    }
    void boss_move() //보스 움직임 구현
    {
        Vector2 v = target.transform.position - transform.position; //타겟에서 보스위치를 뺀 벡터2
        rb.MovePosition(rb.position + v.normalized * speed * Time.deltaTime); //리지바디를 이용한 움직임
        //밑 0 왼쪽 1 위쪽 2 오른쪽 3
        if(v.x < 0)
        {
            if(v.y >= 0)
            {
                if((v.y * v.y) >= (v.x * v.x))
                {
                    ani.SetInteger("dir", 2);
                }
                else
                {
                    ani.SetInteger("dir", 1);
                }
            }
            else
            {
                if((v.y * v.y) < (v.x * v.x))
                {
                    ani.SetInteger("dir", 1);
                }
                else
                {
                    ani.SetInteger("dir", 0);
                }
            }
        }
        else
        {
            if (v.y >= 0)
            {
                if ((v.y * v.y) >= (v.x * v.x))
                {
                    ani.SetInteger("dir", 2);
                }
                else
                {
                    ani.SetInteger("dir", 3);
                }
            }
            else
            {
                if ((v.y * v.y) < (v.x * v.x))
                {
                    ani.SetInteger("dir", 3);
                }
                else
                {
                    ani.SetInteger("dir", 0);
                }
            }
        }
    }

    void boss_attack()
    {
        Instantiate(bullet_prefab, rb.position, Quaternion.identity);
    }
    
    bool boss_active() //boss의 활성화 비활성화 및 플레이어가 보스룸에 들어왔는지 안왔는지 확인
    {
        now_room = RandomMapManager.Instance.visited.Count;
        if (now_room == 12)
        {
            return true;
        }
        return false;
    }
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            ani.SetBool("moving", false);
            delay_time += Time.deltaTime;
            if (delay_time > waitingTime - 1.5f)
            {
                boss_attack(); //총알생성
                timer = 0;
                delay_time = 0f;
            }
        }
        else
        {
            ani.SetBool("moving", true);
            boss_move(); //보스가 움직임
        }
        
        if (hp <= 0) //보스가 죽으면
        {
            Destroy(gameObject);
        }
    }
}
