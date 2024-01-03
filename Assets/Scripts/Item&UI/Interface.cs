using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public GameObject page_1;
    public GameObject page_2;

    public Button Next;
    public Button Previous;

    public TextMeshProUGUI max_hp;
    public TextMeshProUGUI max_mana;
    public TextMeshProUGUI attack;
    public TextMeshProUGUI attack_range;
    public TextMeshProUGUI defend;
    public TextMeshProUGUI speed;
    public TextMeshProUGUI luck;
    public TextMeshProUGUI stage;

    public TextMeshProUGUI attack_txt;
    public TextMeshProUGUI mana_txt;
    public TextMeshProUGUI hit_txt;
    public TextMeshProUGUI defend_txt;
    public TextMeshProUGUI speed_txt;
    public TextMeshProUGUI luck_txt;

    public static Interface Instance;

    

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        hero_stat_update();
        item_update();
        Next.onClick.AddListener(next);
        Previous.onClick.AddListener(previous);
        page_1.SetActive(true);
        page_2.SetActive(false);
    }

    

    void hero_stat_update()
    {
        max_hp.text = "최대체력 : " + Hero1.Instance.attack;
        max_mana.text = "최대마나 : " + Hero1.Instance.attack;
        attack.text = "공격력 : " + Hero1.Instance.attack;
        attack_range.text = "공격범위 : " + Hero1.Instance.attack_range;
        defend.text = "방어력 : " + Hero1.Instance.defend;
        speed.text = "이동속도 : " + Hero1.Instance.speed;
        luck.text = "운 : " + Hero1.Instance.luck;
        stage.text = "Stage : " + Hero1.Instance.stage;
    }

    void item_update()
    {
        attack_txt.text = Hero1.Instance.item_cnt[0].ToString();
        mana_txt.text = Hero1.Instance.item_cnt[1].ToString();
        hit_txt.text = Hero1.Instance.item_cnt[2].ToString();
        defend_txt.text = Hero1.Instance.item_cnt[3].ToString();
        speed_txt.text = Hero1.Instance.item_cnt[4].ToString();
        luck_txt.text = Hero1.Instance.item_cnt[5].ToString();
    }

    void next()
    {
        page_1.SetActive(false);
        page_2.SetActive(true);
    }

    void previous()
    {
        page_1.SetActive(true);
        page_2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        hero_stat_update();
        item_update();
    }
}