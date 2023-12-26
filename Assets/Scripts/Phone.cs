using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Phone : MonoBehaviour
{

    public RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector3(140, -300, 0);

    }

    void turn_on()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rt.anchoredPosition);
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (rt.anchoredPosition.y == -300)
            {
                rt.anchoredPosition = new Vector2(140, 280);
            }
            else
            {
                rt.anchoredPosition = new Vector2(140, -300);
            }
        }
    }
}