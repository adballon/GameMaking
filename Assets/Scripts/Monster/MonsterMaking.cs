using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMaking : MonoBehaviour
{
    public GameObject Monster;
    public Roomcode room;

    public int mon_cnt = 0;
    public int count = 10;                 //������ å(���� ������Ʈ)�� ����
    private BoxCollider2D area;     //BoxCollider2D�� ����� �������� ���� ����
    public List<GameObject> monList = new List<GameObject>();		//������ å ������Ʈ ����Ʈ

    void Start()
    {
        area = GetComponent<BoxCollider2D>();
        makeMonster();
        area.enabled = false;
    }


    public void init()
    {
        for(int i = 0; i < monList.Count; i++)
        {
            Destroy(monList[i]);
        }
        monList.Clear();
    }
    public  void makeMonster()
    {
        for (int i = 0; i < count; i++) //count��ŭ å ����
        {
            Vector3 spawnPos = GetRandomPosition(); //���� ��ġ return

            //����, ��ġ, ȸ������ �Ű������� �޾� ������Ʈ ����
            GameObject instance = Instantiate(Component_management.Instance.monster[0], spawnPos, Quaternion.identity);
            monList.Add(instance); //������Ʈ ������ ���� ����Ʈ�� add
        }
    }
    
    private Vector2 GetRandomPosition()
    {
        Vector2 basePosition = transform.position;  //������Ʈ�� ��ġ
        Vector2 size = area.size;                   //box colider2d, �� ���� ũ�� ����

        //x, y�� ���� ��ǥ ���
        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);

        Vector2 spawnPos = new Vector2(posX, posY);

        return spawnPos;
    }

    bool check_monster()
    {
        if(monList.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void clear_list()
    {
        for(int i = 0;i < monList.Count;i++)
        {
            if (monList[i] == null)
            {
                monList.RemoveAt(i);
            }
        }
    }

    void Update()
    {
        clear_list();
        mon_cnt = monList.Count;
        if(check_monster())
        {
            room.open();
        }
        else
        {
            room.close();
        }
    }
}


