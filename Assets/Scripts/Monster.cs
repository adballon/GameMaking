using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public static Monster Instance;
    float max_hp = 100;
    float now_hp;
    int atk_dmg = 5;
    int atk_range = 3;
    public int speed = 4;
    public float fieldOfVision = 30;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        now_hp = max_hp;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
