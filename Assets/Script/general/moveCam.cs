using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCam : MonoBehaviour
{
    GameObject cam;
    GameObject[] screensObj = new GameObject[4];
    GameObject orderUI;

    Vector3[] screens = new Vector3[4];

    int screenInd;

    private void Start() //get screen positions
    {
        // Find objs
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        screensObj = GameObject.FindGameObjectsWithTag("Screen");
        orderUI = GameObject.FindGameObjectWithTag("OrderUI");

        screenInd = 0;
        for (int i = 0; i < 4; i++)
        {
            screens[i] = screensObj[i].transform.position;
            screens[i].z -= 10;
        }
    }

    private void Update()
    {
        if(screenInd == 0)
        {
            orderUI.GetComponent<CanvasGroup>().alpha = 1f;
        }
        else
        {
            orderUI.GetComponent<CanvasGroup>().alpha = 0f;
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
