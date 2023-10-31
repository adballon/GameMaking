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
        height = Camera.main.orthographicSize; //ī�޶� ���ߴ� ����
        width = height * Screen.width / Screen.height; //ī�޶� ���ߴ� �ʺ�

        transform.position += new Vector3(0, 0, -10); //ī�޶� z��ǥ -10
    }

    void Update()
    {
        transform.position = Hero1.Instance.transform.position;
        transform.position += new Vector3(0, 0, -10);
    }
}