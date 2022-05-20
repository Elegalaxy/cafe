using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderClass : MonoBehaviour
{

    public class order
    {
        //public string[,] orderList;
        public string[] orderList;
        public string orderName;
        string[] cakesList = {"chocolate cake", "matcha cake", "pudding", "rainbow cake", "strawberry cake", "cupcake"};
        /*string[] shotsList = { "Single", "Single" }; //double shot
        string[] coffeeList = { "Shot", "Long Black", "Latte", "Mocha", "Cappucinno", "Chocolate"};
        string[] tempList = { "Hot", "Ice" };*/

        int orderNumber;
        int orderNum = 1;
        int totalItem = 5;
        /*int shot = 1, coffee = 5, temp = 1;
        int shotInd, coffeeInd, tempInd = 0;*/

        public order()
        {
            orderNumber = Random.Range(0, orderNum);
            for(int i = 0; i <= orderNumber; i++)
            {
                /*shotInd = Random.Range(0, shot+1);
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
                }*/
                int itemInd = Random.Range(0, totalItem+1);
                takeOrder(itemInd, orderNumber);
            }
        }

        /*void takeOrder(int s, int c, int t, int n)
        {
            orderList = new string[n+1,2];
            orderList[n, 0] = tempList[t];
            orderList[n, 1] = coffeeList[c];
        }*/

        void takeOrder(int i, int n) {
            orderList = new string[n + 1];
            orderList[n] = cakesList[i];
        }
    }

    public order currentOrder;
    public string[] getOrder()
    {
        currentOrder = new order();
        string[] orderNow = currentOrder.orderList;
        return orderNow;
    }
}
