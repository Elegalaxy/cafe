using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class orderShow : MonoBehaviour
{
    public orderClass orderClass;
    public GameObject[] orders;

    float orderTime = 2f; //max time for order
    float[] orderLast = {0f, 0f, 0f, 0f}; //record remaining time for each order
    string[] orderList;

    void Start()
    {
        orders = new GameObject[transform.childCount];
        orderList = new string[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            orders[i] = transform.GetChild(i).gameObject;
            orders[i].GetComponent<Text>().text = "";
        }
    }

    private void Update()
    {
        if (orderTime > 0)
        {
            orderTime -= Time.deltaTime;
            //Debug.Log(orderTime);
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                if (orders[i].GetComponent<Text>().text == "")
                {
                    string[,] currentOrder;
                    currentOrder = orderClass.getOrder();
                    //orders[i].GetComponent<Text>().text += currentOrder[0, 0] + " " + currentOrder[0, 1] + " " + currentOrder[0, 2];
                    orders[i].GetComponent<Text>().text += currentOrder[0, 0] + " " + currentOrder[0, 1];
                    orderList[i] = orders[i].GetComponent<Text>().text;
                    orderLast[i] = 3f;

                    /*for (int j = 0; j < currentOrder.GetLength(0); j++)
                    {
                        orders[i].GetComponent<Text>().text += currentOrder[j, 0] + " " + currentOrder[j, 1] + " " + currentOrder[j, 2];
                    }*/

                    orderTime = 1f;
                    break;
                }
            }
        }

        for(int i = 0; i < 4; i++)
        {
            if (orderLast[i] > 0)
            {
                orderLast[i] -= Time.deltaTime;
            }
            else
            {
                orders[i].GetComponent<Text>().text = "";
                //Debug.Log("Order Gone");
            }
        }
    }

    public string[] get_orderList() {
        return orderList;
    }
}