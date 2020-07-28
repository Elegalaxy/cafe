﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCam : MonoBehaviour
{
    public GameObject cam;
    public GameObject[] screensObj = new GameObject[4];

    Vector3[] screens = new Vector3[4];

    int screenInd;

    private void Start() //get screen positions
    {
        screenInd = 0;
        for (int i = 0; i < 4; i++)
        {
            screens[i] = screensObj[i].transform.position;
            screens[i].z -= 10;
        }
    }

    public void move(bool left) //move screen depend on index
    {
        if (left)
        {
            if (screenInd < 3)
            {
                screenInd += 1;
            }
            else
            {
                screenInd = 0;
            }
        }
        else
        {
            if (screenInd > 0)
            {
                screenInd -= 1;
            }
            else
            {
                screenInd = 3;
            }
        }
        //Debug.Log(screenInd);
        cam.transform.position = screens[screenInd];
    }
}