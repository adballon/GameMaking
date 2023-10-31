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

    public GameObject[] Range; //공격범위 배열
    float init_range = 0.1f; //공격범위 초기값
    public float saverange; //바뀐 공격범위 스탯 저장
    bool chk = false; //공격범위가 바뀌었는가?
    float range; //공격범위
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
        Range[0].transform.localScale = new Vector3(init_range, range, 1); //위쪽
        Range[1].transform.localScale = new Vector3(init_range, range, 1); //아래쪽
        Range[2].transform.localScale = new Vector3(range, init_range, 1); //왼쪽
        Range[3].transform.localScale = new Vector3(range, init_range, 1); //오른쪽

        if(chk)
        {
            chk = false;
            float positionvector = Hero1.Instance.attack_range/2;
            Range[0].transform.localPosition = new Vector3(0, (positionvector + 0.12f), 0); //위쪽
            Range[1].transform.localPosition = new Vector3(0, -(positionvector + 0.2f), 0); //아래쪽
            Range[2].transform.localPosition = new Vector3(-(positionvector + 0.1f), -0.1f, 0); //왼쪽
            Range[3].transform.localPosition = new Vector3((positionvector + 0.1f), -0.1f, 0); //오른쪽
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
