using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class orderShow : MonoBehaviour
{
    public orderClass orderClass;
    public GameObject[] orders;
    public GameObject scoreBoard;
    public orderPlacer orderPlacers;

    int score = 0;
    float orderTime = 5f; //max time for order
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
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                if (orders[i].GetComponent<Text>().text == "")
                {
                    string[] currentOrder;
                    currentOrder = orderClass.getOrder();
                    
                    for(int j = 0; j < currentOrder.Length; j++) {
                        orders[i].GetComponent<Text>().text += currentOrder[j] + "\n";
                    }

                    orderList[i] = orders[i].GetComponent<Text>().text;
                    orderPlacers.updateList();
                    orderLast[i] = 10f;

                    /*for (int j = 0; j < currentOrder.GetLength(0); j++)
                    {
                        orders[i].GetComponent<Text>().text += currentOrder[j, 0] + " " + currentOrder[j, 1] + " " + currentOrder[j, 2];
                    }*/

                    orderTime = 5f;
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

    /*string translateOrder(string order) {
        switch(order) {
            case "Hot Long Black":
                return "Long Black";
            case "Hot Latte":
                return "Latte";
            case "Hot Mocha":
                return "Mocha";
            case "Hot Cappucinno":
                return "Cappucinno";
            case "Hot Chocolate":
                return "Hot Chocolate";
            case "Ice Long Black":
                return "Ice Long Black";
            case "Ice Latte":
                return "Ice Latte";
            case "Ice Mocha":
                return "Ice Mocha";
            case "Ice Cappucinno":
                return "Ice Cappucinno";
            case "Ice Chocolate":
                return "Ice Chocolate";
            case "Hot Shot":
                return "Shot";
            default:
                return " ";
        }
    }*/

    public string[] get_orderList() {
        return orderList;
    }

    public void correctOrder(int ind) {
        orders[ind].GetComponent<Text>().text = "";
        orderList[ind] = "";
        orderPlacers.updateList();
        score += 100;
        updateScore(score);
        Debug.Log(score);
    }

    void updateScore(int s) {
        scoreBoard.GetComponent<Text>().text = "Score: " + s.ToString();
    }
}