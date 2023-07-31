using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomcode : MonoBehaviour
{
    // 이 방에 한번이라도 들어갔는지
    public bool isEnter = false;

    // 방에 달려있는 문 모음
    public Doorcode[] roomdoors;

    // 남은 몬스터 수
    // 스폰시킬 몬스터들
    // 카메라 고정 위치, 카메라 크기? 등

    private void Start()
    {
        Debug.Log(gameObject.name + " " + roomdoors.Length);
    }
}
