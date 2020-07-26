using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class machine : MonoBehaviour
{
    string machineName;
    int holdNum;

    //grinder
    bool isGrind;
    bool isHandle;
    float grindTime;

    public objPlace[] holder;
    public Sprite grinded;

    void Start()
    {
        machineName = gameObject.tag;
        holdNum = holder.Length;

        if (machineName == "Grinder")
        {
            grindTime = 3f;
            isGrind = false;
            isHandle = false;
        }
    }

    private void Update()
    {
        if (holder[0].place.sprite != null) //need to change to check by name
        {
            isGrind = true;
            isHandle = true;
        }
        if (isHandle && isGrind)
        {
            if(grindTime > 0)
            {
                grindTime -= Time.deltaTime;
                Debug.Log(grindTime);
            }
            else
            {
                holder[0].GetComponent<objPlace>().changeStat(grinded);
                isHandle = false;
                isGrind = false;
            }
        }
    }

    public void operate()
    {
        if(machineName == "Grinder")
        {

        }
    }
}
