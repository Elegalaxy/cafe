using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderClass : MonoBehaviour
{

    public class order
    {
        static System.Random rand = new System.Random();

        public string[] orderPaper;
        string[] shotsList = { "Single", "Double" };
        string[] coffeeList = { "Shot", "Long Black", "Latte", "Mocha", "Cappucinno" };
        string[] tempList = { "Hot", "Cold" };

        int shot = 1, coffee = 4, temp = 1;
        int shotInd, coffeeInd, tempInd = 0;

        public order()
        {
            shotInd = rand.Next(0, shot+1);
            if(shotInd == 1)
            {
                coffeeInd = rand.Next(0, 2);
                if(coffeeInd == 1)
                {
                    tempInd = rand.Next(0, temp+1);
                }
                takeOrder(shotInd, coffeeInd, tempInd);
            }
            else
            {
                coffeeInd = rand.Next(0, coffee+1);
                if(coffeeInd != 0)
                {
                    tempInd = rand.Next(0, temp+1);
                }
                takeOrder(shotInd, coffeeInd, tempInd);
            }
        }

        void takeOrder(int s, int c, int t)
        {
            orderPaper = new string[3];
            orderPaper[0] = shotsList[s];
            orderPaper[1] = coffeeList[c];
            orderPaper[2] = tempList[t];
        }
    }

    public order currentOrder;
    int loop = 10;

    void Start()
    {
        for(int i = 0; i < loop; i++)
        {
            currentOrder = new order();
            string[] orderNow = currentOrder.orderPaper;
            Debug.Log(orderNow[0] +" "+ orderNow[1] + " "+ orderNow[2]);
        }
    }

    void Update()
    {
        
    }
}
