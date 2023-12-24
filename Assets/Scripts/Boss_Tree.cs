using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Tree : MonoBehaviour
{
    //�������� ���ε��� �������� ��ũ��Ʈ�� ©����
    float hp, atk, defend, speed; //�������� ������ hp, atk, ~~~�� ����
    string boss_name = "���ֹ��� ����"; //���� �̸� ������ boss_name���� ����
    //���� �̸��� ��ܿ� ü�¹ٿ� �Բ� ǥ��
    public GameObject bullet_prefab; //���ݸ�ǿ� ���� �Ѿ� ������
    public GameObject target; //�÷��̾ Ÿ��
    Rigidbody2D rb;
    bool player_in_boss_room; //�÷��̾ �����뿡 �������� Ȯ��
    float timer; //�ð� ����
    int waitingTime;
    void Start()
    {
        hp = 5000f; //�Ϲ� ���� 50��
        atk = 20f; //�Ϲݸ��� 4��
        defend = 10f; //���� �߰�
        speed = 0.2f; //����������� ����(�Ϲݸ��� 5%)
        target = GameObject.FindWithTag("Player"); //target���� player ã��
        rb = GetComponent<Rigidbody2D>();
        //gameObject.SetActive(false); //�ϴ� ��Ȱ��ȭ �س��� ���߿� �÷��̾ 1���������� ������ �����뿡 Ȱ��ȭ
        //�����̰� ���������� ���� �濡 ���� ������ ���� �� �ִ� ���𰡸� ���������� ��������
        player_in_boss_room = false;
        timer = 0f;
        waitingTime = 3;
    }
    void boss_move() //���� ������ ����
    {
        Vector2 v = target.transform.position - transform.position; //Ÿ�ٿ��� ������ġ�� �� ����2
        rb.MovePosition(rb.position + v.normalized * speed * Time.deltaTime); //�����ٵ� �̿��� ������
        if (v.x < 0) //Ÿ���� ���ʿ� ���� ��
        {
            transform.localScale = new Vector3(25, 25, 25); //�ٶ󺸱�
        }
        else //Ÿ���� �����ʿ� ���� ��
        {
            transform.localScale = new Vector3(-25, 25, 25); //�ٶ󺸱�
        }
    }
    void boss_attack() //���� ���� ����
    {
        timer += Time.deltaTime;
        if(timer > waitingTime)
        {
            GameObject bullet = Instantiate(bullet_prefab, rb.position, Quaternion.identity);
            timer = 0;
        }
    }
    void boss_active() //boss�� Ȱ��ȭ ��Ȱ��ȭ �� �÷��̾ �����뿡 ���Դ��� �ȿԴ��� Ȯ��
    {
        //if(�������� == 1)
        //{
            //gameObject.SetActive(true);
        //}
        //else
        //{
            //gameObject.SetActive(false);
        //}
        //if(�÷��̾��� ����ġ == ������)
        //{
            //player_in_boss_room = true;
        //}
        //else
        //{
            //player_in_boss_room = false;
        //}
        //*����ȭ �κ�*
        //�÷��̾ ���� �������� active�� false�� �ϰ� �������
        //player_in_boss_room������ false�� ������ְ� �������
        //�׷��� else���� ������� �������Ӹ��� else���� �ȵ����൵��
    }
    void Update()
    {
        boss_active(); //������ Ȱ�� ����
        //if(player_in_boss_room) //�÷��̾ �����뿡 ����
        //{
            boss_move(); //������ ������
            boss_attack(); //������ ����
        //}
    }

    private void FixedUpdate()
    {
        
    }
}
