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
    float init_range = 0.1f; //���ݹ��� �ʱⰪ
    public float saverange; //�ٲ� ���ݹ��� ���� ����
    bool chk = false; //���ݹ����� �ٲ���°�?
    float range; //���ݹ���
    public int arrow;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        arrow = 1;
        setActiveRange();
        for(int i = 0; i < Range.Length; i++)
        {
            Range[i].transform.localScale = new Vector3(init_range, init_range, 1);
        }
        range = init_range;
        saverange = Hero1.Instance.attack_range;
    }

    public void setActiveRange()
    {
        for (int i = 0; i < Range.Length; i++)
        {
            Range[i].SetActive(false);
        }
    }

    void checkRange()
    {
        if(saverange != Hero1.Instance.attack_range)
        {
            chk = true;
            saverange = Hero1.Instance.attack_range;
            range = saverange + init_range;
        }
    }



    void changeRange()
    {
        checkRange();
        Range[0].transform.localScale = new Vector3(init_range, range, 1); //����
        Range[1].transform.localScale = new Vector3(init_range, range, 1); //�Ʒ���
        Range[2].transform.localScale = new Vector3(range, init_range, 1); //����
        Range[3].transform.localScale = new Vector3(range, init_range, 1); //������

        if(chk)
        {
            chk = false;
            float positionvector = Hero1.Instance.attack_range/2;
            Range[0].transform.localPosition = new Vector3(0, (positionvector + 0.12f), 0); //����
            Range[1].transform.localPosition = new Vector3(0, -(positionvector + 0.2f), 0); //�Ʒ���
            Range[2].transform.localPosition = new Vector3(-(positionvector + 0.1f), -0.1f, 0); //����
            Range[3].transform.localPosition = new Vector3((positionvector + 0.1f), -0.1f, 0); //������
        }
    }

    public void showAttackRange()
    {
        Range[arrow - 1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        changeRange();
        arrow = Hero1.Instance.lastinput;
    }
}
