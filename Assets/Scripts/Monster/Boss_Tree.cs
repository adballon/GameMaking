using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Tree : MonoBehaviour
{
    //�������� ���ε��� �������� ��ũ��Ʈ�� ©����
    public float hp, atk, defend, speed; //�������� ������ hp, atk, ~~~�� ����
    string boss_name = "���ֹ��� ����"; //���� �̸� ������ boss_name���� ����
    //���� �̸��� ��ܿ� ü�¹ٿ� �Բ� ǥ��
    public GameObject bullet_prefab; //���ݸ�ǿ� ���� �Ѿ� ������
    public GameObject target; //�÷��̾ Ÿ��
    Rigidbody2D rb;
    float timer; //�ð� ����
    float waitingTime;
    int now_room; //�������� visited�� 12�� visited == 12
    public static Boss_Tree Instance;
    float delay_time;
    public Animator ani; //animation

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        hp = 1000f; //�Ϲ� ���� 10��
        atk = 20f; //�Ϲݸ��� 4��
        defend = 10f; //���� �߰�
        speed = 0.4f; //����������� ����(�Ϲݸ��� 10%)
        target = GameObject.FindWithTag("Player"); //target���� player ã��
        rb = GetComponent<Rigidbody2D>();
        timer = 0f;
        waitingTime = 2.0f;
        delay_time = 0f;
        ani = GetComponent<Animator>();
        ani.SetBool("moving", false);
        ani.SetInteger("dir", 0);
    }
    void boss_move() //���� ������ ����
    {
        Vector2 v = target.transform.position - transform.position; //Ÿ�ٿ��� ������ġ�� �� ����2
        rb.MovePosition(rb.position + v.normalized * speed * Time.deltaTime); //�����ٵ� �̿��� ������
        //�� 0 ���� 1 ���� 2 ������ 3
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
    
    bool boss_active() //boss�� Ȱ��ȭ ��Ȱ��ȭ �� �÷��̾ �����뿡 ���Դ��� �ȿԴ��� Ȯ��
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
                boss_attack(); //�Ѿ˻���
                timer = 0;
                delay_time = 0f;
            }
        }
        else
        {
            ani.SetBool("moving", true);
            boss_move(); //������ ������
        }
        
        if (hp <= 0) //������ ������
        {
            Destroy(gameObject);
        }
    }
}
