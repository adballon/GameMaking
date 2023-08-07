using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMaking : MonoBehaviour
{
    public GameObject Monster;

    public int count = 10;                 //������ å(���� ������Ʈ)�� ����
    private BoxCollider2D area;     //BoxCollider2D�� ����� �������� ���� ����
    private List<GameObject> bookList = new List<GameObject>();		//������ å ������Ʈ ����Ʈ

    void Start()
    {
        area = GetComponent<BoxCollider2D>();
        StartCoroutine("Spawn", 20);
    }

    //���� ������Ʈ�� �����Ͽ� scene�� �߰�
    private IEnumerator Spawn(float delayTime)
    {
        for (int i = 0; i < count; i++) //count��ŭ å ����
        {
            Vector3 spawnPos = GetRandomPosition(); //���� ��ġ return

            //����, ��ġ, ȸ������ �Ű������� �޾� ������Ʈ ����
            GameObject instance = Instantiate(Monster, spawnPos, Quaternion.identity);
            bookList.Add(instance); //������Ʈ ������ ���� ����Ʈ�� add
        }
        area.enabled = false;
        yield return new WaitForSeconds(delayTime);   //�ֱ� : 20��

        for (int i = 0; i < count; i++) //å ����
            Destroy(bookList[i].gameObject);

        bookList.Clear();           //bookList ����
        area.enabled = true;
        StartCoroutine("Spawn", 20);    //å �ٽ� ����
    }

    //BoxCollider2D ���� ������ ��ġ�� return
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

}