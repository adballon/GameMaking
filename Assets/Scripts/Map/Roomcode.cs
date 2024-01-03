using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomcode : MonoBehaviour
{
    public static Roomcode Instance; 

    public Vector3 RoomCenter;
    public float RoomWidth; //방의 가로 크기 / 2
    public float RoomHeigth; //방의 세로 크기 / 2

    public float maxRoomwidth; //최대로 갈 수 있는 방의 가로 좌표
    public float maxRoomHeigth; //최대로 갈 수 있는 방의 세로 좌표
    public float minRoomwidth; //최소로 갈 수 있는 방의 가로 좌표
    public float minRoomheight; //최대로 갈 수 있는 방의 세로 좌표

    // 방에 달려있는 문 모음
    public Doorcode[] roomdoors;

    // 남은 몬스터 수
    // 스폰시킬 몬스터들
    // 카메라 고정 위치, 카메라 크기? 등

    public void open()
    {
        for(int i = 0; i < roomdoors.Length; i++)
        {
            roomdoors[i].SetActive(true);
        }
    }

    public void close()
    {
        for (int i = 0; i < roomdoors.Length; i++)
        {
            roomdoors[i].SetActive(false);
        }
    }

    void Start()
    {
        RoomCenter = transform.position;
        RoomWidth = roomdoors[3].transform.position.x;
        RoomHeigth = roomdoors[0].transform.position.y;
        
        maxRoomwidth = RoomCenter.x + RoomWidth;
        maxRoomHeigth = RoomCenter.y + RoomHeigth;

        minRoomwidth = RoomCenter.x - RoomWidth;
        minRoomheight = RoomCenter.y - RoomHeigth;
    }
    void Awake()
    {
        Instance = this;
    }
}
