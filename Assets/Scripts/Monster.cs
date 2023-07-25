using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public string enemyname;
    public int maxhp;
    public int nowhp;
    public int atkdmg;
    public int atkspeed;
    public int atkrange;
    public int speed = 1;
    public float fieldOfVision;

    private void SetEnemyStatus(string t_enemyname, int t_maxhp, int t_atkdmg, int t_atkspeed, int t_atkrange, float t_fieldOfVision)
    {
        enemyname = t_enemyname;
        maxhp = t_maxhp;
        nowhp = maxhp;
        atkdmg = t_atkdmg;
        atkspeed = t_atkspeed;
        atkrange = t_atkrange;
        fieldOfVision = t_fieldOfVision;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetEnemyStatus("monster1", 100, 10, 1, 5, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
