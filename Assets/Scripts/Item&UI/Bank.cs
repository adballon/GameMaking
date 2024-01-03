using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    public TextMeshProUGUI volume;
    public Button savebtn;
    public TMP_InputField deposit;
    public TextMeshProUGUI total;
    int account;
    // Start is called before the first frame update
    void Start()
    {
        account = 0;
        deposit.text = "0";
        total.text = account.ToString();
        volume.text = Hero1.Instance.coin.ToString();
        savebtn.onClick.AddListener(save_coin);
    }

    void save_coin()
    {
        int amount = int.Parse(deposit.text); //얼마 저징할래

        if(amount <= Hero1.Instance.coin)
        {
            account += amount; //저장 한 값 기존 저장한 값과 합쳐주고
            Hero1.Instance.coin -= amount; //현재 가지고 있는 코인에서 저장 할 양 제거
            volume.text = Hero1.Instance.coin.ToString(); //현재 가지고 있는 양 반영
            total.text = account.ToString(); //저징한 값 반영
        }
        deposit.text = "0"; //인풋필드 초기화
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
