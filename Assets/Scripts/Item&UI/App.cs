using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class App : MonoBehaviour
{

    public Button bank;
    public Button info;

    public void Bank()
    {
        Debug.Log("Bank");
    }

    public void Info()
    {
        Debug.Log("Info");
    }


    // Start is called before the first frame update
    void Start()
    {
        bank.onClick.AddListener(Bank);
        info.onClick.AddListener(Info);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
