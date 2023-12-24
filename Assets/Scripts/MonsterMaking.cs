using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMaking : MonoBehaviour
{
    public GameObject Monster;

    public int count = 10;                 //생성할 책(게임 오브젝트)의 개수
    private BoxCollider2D area;     //BoxCollider2D의 사이즈를 가져오기 위한 변수
    private List<GameObject> bookList = new List<GameObject>();		//생성한 책 오브젝트 리스트

    void Start()
    {
        area = GetComponent<BoxCollider2D>();
        for (int i = 0; i < count; i++) //count만큼 책 생성
        {
            Vector3 spawnPos = GetRandomPosition(); //랜덤 위치 return

            //원본, 위치, 회전값을 매개변수로 받아 오브젝트 복제
            GameObject instance = Instantiate(Monster, spawnPos, Quaternion.identity);
            //bookList.Add(instance); //오브젝트 관리를 위해 리스트에 add
        }
        area.enabled = false;
    }
    
    private Vector2 GetRandomPosition()
    {
        Vector2 basePosition = transform.position;  //오브젝트의 위치
        Vector2 size = area.size;                   //box colider2d, 즉 맵의 크기 벡터

        //x, y축 랜덤 좌표 얻기
        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);

        Vector2 spawnPos = new Vector2(posX, posY);

        return spawnPos;
    }

}