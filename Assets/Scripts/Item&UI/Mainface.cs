using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class Mainface : MonoBehaviour
{

    public Button bank;
    public Button info;
    public Button back_bank;
    public Button back_info;
    public GameObject mainface;
    public GameObject Bankface;
    public GameObject Infoface;

    
    public void Bank()
    {
        mainface.SetActive(false);
        Bankface.SetActive(true);
    }

    public void Info()
    {
        mainface.SetActive(false);
        Infoface.SetActive(true);
    }

    public void turn_on()
    {
        mainface.SetActive(true);
        Bankface.SetActive(false);
        Infoface.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        turn_on();
        bank.onClick.AddListener(Bank);
        info.onClick.AddListener(Info);
        back_bank.onClick.AddListener(turn_on);
        back_info.onClick.AddListener(turn_on);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
