using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{
    public int respawn;
    float cnt = 1;
    float time = 0;
    public string next_scene;
    public TextMeshProUGUI clock;

    void next()
    {
        SceneManager.LoadScene(next_scene);
    }
    // Start is called before the first frame update
    void Start()
    {
        clock.text = "respawn time : " + respawn;
    }

    // Update is called once per frame
    void Update()
    {
        
        time += Time.deltaTime;
        if(time >= cnt)
        {
            time = 0;
            respawn--;
            if (respawn < 0)
            {
                next();
            }
            else
            {
                clock.text = "respawn time : " + respawn;
            }
            
        }


    }
}
