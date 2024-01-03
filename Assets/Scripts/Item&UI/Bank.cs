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
        int amount = int.Parse(deposit.text); //�� ��¡�ҷ�

        if(amount <= Hero1.Instance.coin)
        {
            account += amount; //���� �� �� ���� ������ ���� �����ְ�
            Hero1.Instance.coin -= amount; //���� ������ �ִ� ���ο��� ���� �� �� ����
            volume.text = Hero1.Instance.coin.ToString(); //���� ������ �ִ� �� �ݿ�
            total.text = account.ToString(); //��¡�� �� �ݿ�
        }
        deposit.text = "0"; //��ǲ�ʵ� �ʱ�ȭ
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
