using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float height;
    float width;

    float CarHeight;
    float CarWidth;

    void Start()
    {
        height = Camera.main.orthographicSize; //카메라가 비추는 높이
        width = height * Screen.width / Screen.height; //카메라가 비추는 너비

        transform.position += new Vector3(0, 0, -10); //카메라 z좌표 -10
    }

    void Update()
    {
        transform.position = Hero1.Instance.transform.position;
        transform.position += new Vector3(0, 0, -10);
    }
}