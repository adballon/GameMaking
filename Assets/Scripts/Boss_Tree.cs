using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Tree : MonoBehaviour
{
    //보스마다 따로따로 독자적인 스크립트를 짤거임
    float hp, atk, defend, speed; //보스들의 변수는 hp, atk, ~~~로 고정
    string boss_name = "저주받은 나무"; //보스 이름 변수는 boss_name으로 고정
    //보스 이름은 상단에 체력바와 함께 표기
    public GameObject bullet_prefab; //공격모션에 사용될 총알 프리팹
    public GameObject target; //플레이어가 타겟
    Rigidbody2D rb;
    bool player_in_boss_room; //플레이어가 보스룸에 들어오는지 확인
    float timer; //시간 지연
    int waitingTime;
    void Start()
    {
        hp = 5000f; //일반 몹의 50배
        atk = 20f; //일반몹의 4배
        defend = 10f; //방어개념 추가
        speed = 0.2f; //나무보스답게 느림(일반몹의 5%)
        target = GameObject.FindWithTag("Player"); //target으로 player 찾기
        rb = GetComponent<Rigidbody2D>();
        //gameObject.SetActive(false); //일단 비활성화 해놓고 나중에 플레이어가 1스테이지에 있으면 보스룸에 활성화
        //정문이가 스테이지와 현재 방에 대한 정보를 얻을 수 있는 무언가를 만들어줘야지 구현가능
        player_in_boss_room = false;
        timer = 0f;
        waitingTime = 3;
    }
    void boss_move() //보스 움직임 구현
    {
        Vector2 v = target.transform.position - transform.position; //타겟에서 보스위치를 뺀 벡터2
        rb.MovePosition(rb.position + v.normalized * speed * Time.deltaTime); //리지바디를 이용한 움직임
        if (v.x < 0) //타겟이 왼쪽에 있을 때
        {
            transform.localScale = new Vector3(25, 25, 25); //바라보기
        }
        else //타겟이 오른쪽에 있을 때
        {
            transform.localScale = new Vector3(-25, 25, 25); //바라보기
        }
    }
    void boss_attack() //보스 공격 구현
    {
        timer += Time.deltaTime;
        if(timer > waitingTime)
        {
            GameObject bullet = Instantiate(bullet_prefab, rb.position, Quaternion.identity);
            timer = 0;
        }
    }
    void boss_active() //boss의 활성화 비활성화 및 플레이어가 보스룸에 들어왔는지 안왔는지 확인
    {
        //if(스테이지 == 1)
        //{
            //gameObject.SetActive(true);
        //}
        //else
        //{
            //gameObject.SetActive(false);
        //}
        //if(플레이어의 방위치 == 보스방)
        //{
            //player_in_boss_room = true;
        //}
        //else
        //{
            //player_in_boss_room = false;
        //}
        //*최적화 부분*
        //플레이어가 방을 나갔을때 active를 false로 하고 나가면됨
        //player_in_boss_room변수를 false로 만들어주고 나가면됨
        //그러면 else문이 사라져서 한프레임마다 else문을 안돌려줘도됨
    }
    void Update()
    {
        boss_active(); //보스의 활동 제어
        //if(player_in_boss_room) //플레이어가 보스룸에 들어가면
        //{
            boss_move(); //보스가 움직임
            boss_attack(); //보스가 때림
        //}
    }

    private void FixedUpdate()
    {
        
    }
}
