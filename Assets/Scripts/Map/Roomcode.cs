using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomcode : MonoBehaviour
{
    // 이 방에 한번이라도 들어갔는지
    public bool isEnter = false;

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

    void Start()
    {
        Debug.Log(gameObject.name + " " + roomdoors.Length);
        RoomCenter = this.gameObject.transform.position;
        maxRoomHeigth = RoomCenter.y + RoomHeigth;
        maxRoomwidth = RoomCenter.x + RoomWidth;
        minRoomheight = RoomCenter.y - RoomHeigth;
        minRoomwidth = RoomCenter.x - RoomWidth;
    }
}
