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

    public int[] item_cnt = new int[6];

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
        cnt_init();
    }

    void hero_stat_update()
    {
        max_hp.text = "MAX_HP : " + Hero1.Instance.attack;
        max_mana.text = "MAX_MP : " + Hero1.Instance.attack;
        attack.text = "ATTACK : " + Hero1.Instance.attack;
        attack_range.text = "ATK_RANGE : " + Hero1.Instance.attack_range;
        defend.text = "DEFEND : " + Hero1.Instance.defend;
        speed.text = "SPEED : " + Hero1.Instance.speed;
        luck.text = "LUCK : " + Hero1.Instance.luck;
        stage.text = "STAGE : " + Hero1.Instance.stage;
    }

    void item_update()
    {
        attack_txt.text = item_cnt[0].ToString();
        mana_txt.text = item_cnt[1].ToString();
        hit_txt.text = item_cnt[2].ToString();
        defend_txt.text = item_cnt[3].ToString();
        speed_txt.text = item_cnt[4].ToString();
        luck_txt.text = item_cnt[5].ToString();
    }


    void cnt_init()
    {
        for (int i = 0; i < item_cnt.Length; i++)
        {
            item_cnt[i] = 0;
        }
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