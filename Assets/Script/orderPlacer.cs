using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderPlacer : MonoBehaviour
{
    public orderShow order;

    string[] orderList; //all the orders
    objPlace[] placer; //all the placers

    private void Start() {
        updateList();
        placer = new objPlace[4];
        for(int i = 0; i < transform.childCount; i++) {
            if(transform.GetChild(i).GetComponent<objPlace>() != null) placer[i] = transform.GetChild(i).GetComponent<objPlace>();
        }
    }

    public void updateList() {
        orderList = order.get_orderList();
    }

    bool checkOrder(int ind) {
        /*switch() {

        }*/
        return true;
    }
}
