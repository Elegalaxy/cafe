using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderClass : MonoBehaviour
{

    public class order
    {
        public string[,] orderList;
        string[] shotsList = { "Single", "Double" };
        string[] coffeeList = { "Shot", "Shot Long Black", "Shot Latte", "Shot Mocha", "Shot Cappucinno" };
        string[] tempList = { "Hot", "Cold" };

        int orderNumber;
        int shot = 1, coffee = 4, temp = 1, orderNum = 1;
        int shotInd, coffeeInd, tempInd = 0;

        public order()
        {
            orderNumber = Random.Range(0, orderNum);
            //Debug.Log("orderNum " + orderNumber);
            for(int i = 0; i <= orderNumber; i++)
            {
                shotInd = Random.Range(0, shot+1);
                if (shotInd == 1)
                {
                    coffeeInd = Random.Range(0, 2);
                    if (coffeeInd == 1)
                    {
                        tempInd = Random.Range(0, temp+1);
                    }
                    takeOrder(shotInd, coffeeInd, tempInd, orderNumber);
                }
                else
                {
                    coffeeInd = Random.Range(0, coffee+1);
                    if (coffeeInd != 0)
                    {
                        tempInd = Random.Range(0, temp+1);
                    }
                    takeOrder(shotInd, coffeeInd, tempInd, orderNumber);
                }
            }
        }

        void takeOrder(int s, int c, int t, int n)
        {
            orderList = new string[n+1,3];
            orderList[n, 0] = shotsList[s];
            orderList[n, 1] = coffeeList[c];
            orderList[n, 2] = tempList[t];
        }
    }

    public order currentOrder;
    public string[,] getOrder()
    {
        currentOrder = new order();
        string[,] orderNow = currentOrder.orderList;
        for(int i = 0; i < orderNow.GetLength(0); i++)
        {
            //Debug.Log(orderNow[i, 0] + " " + orderNow[i, 1] + " " + orderNow[i, 2]);
        }
        return orderNow;
    }
}
