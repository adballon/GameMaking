using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public static item Instance;

    public float attack_up = 0; //���ݷ� ����
    public float defense_up = 0; //���� ����
    public float speed_up = 0; //�ӵ� ����
    public float luck_up = 0; //�� ����
    public float hit_up = 0; //ü�� ����
    public float mana_up = 0; //���� ����

    void Awake()
    {
        Instance = this;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("true");
            Destroy(gameObject);
            Hero1.Instance.attack += attack_up;
            Hero1.Instance.defend += defense_up;
            Hero1.Instance.speed += speed_up;
            Hero1.Instance.hitPoint += hit_up;
            Hero1.Instance.manaPoint += mana_up;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
