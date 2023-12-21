using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class Hero_Attack : MonoBehaviour
{

    public static Hero_Attack Instance;
    Rigidbody2D rigid;

    public GameObject[] Range; //���ݹ��� �迭
    public Vector3[] init_position;
    public Vector3[] position;
    float init_range; //���ݹ��� �ʱⰪ
    float range; //���ݹ���
    public int arrow;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        arrow = 1;
        init_range = Hero1.Instance.attack_range * 0.1f;
        position = new Vector3[4];
        init_position = new Vector3[4];
        setActiveRange();

        Range[0].transform.localScale = new Vector3(0.1f, 0.1f, 1);
        Range[1].transform.localScale = new Vector3(0.1f, 0.1f, 1);
        Range[2].transform.localScale = new Vector3(0.1f, 0.18f, 1);
        Range[3].transform.localScale = new Vector3(0.1f, 0.18f, 1);

        for (int i = 0; i < Range.Length; i++)
        {
            position[i] = Range[i].transform.localPosition;
            Debug.Log(position[i]);
        }
        range = init_range;
    }

    public void setActiveRange()
    {
        for (int i = 0; i < Range.Length; i++)
        {
            Range[i].SetActive(false);
        }
    }

    bool checkRange()
    {
        if (range != Hero1.Instance.attack_range * 0.1f)
        {
            range = Hero1.Instance.attack_range * 0.1f;
            return true; 
        }
        else
        {
            return false;
        }
    }

    void changeRange()
    {
        float change = range - init_range;
        Range[0].transform.localScale = new Vector3(0.1f, range, 1);
        Range[1].transform.localScale = new Vector3(0.1f, range, 1);
        Range[2].transform.localScale = new Vector3(range, 0.18f, 1);
        Range[3].transform.localScale = new Vector3(range, 0.18f, 1);

        Range[0].transform.localPosition = position[0] + new Vector3(0, change / 2, 0);
        Range[1].transform.localPosition = position[1] + new Vector3(0, -change / 2, 0);
        Range[2].transform.localPosition = position[2] + new Vector3(-change / 2, 0, 0);
        Range[3].transform.localPosition = position[3] + new Vector3(change / 2, 0, 0);
    }

    public void showAttackRange()
    {
        Range[arrow - 1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(checkRange() == true)
        {
            Debug.Log(true);
            changeRange();
        }
        arrow = Hero1.Instance.lastinput;
    }
}

//���ݹ��� ���� �Ϸ�