using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderPlacer : MonoBehaviour
{
    public orderShow order;

    string[] orderList; //all the orders
    objPlace[] placer; //all the placers

    private void Start() {
        placer = new objPlace[4];
        for(int i = 0; i < transform.childCount; i++) {
            placer[i] = transform.GetChild(i).GetChild(0).GetComponent<objPlace>();
        }
    }

    private void Update() {
        for(int i = 0; i < placer.Length; i++) {
            if(placer[i].GetComponent<objPlace>().getName("item") != "") {
                if(checkOrder(i)) {
                    order.correctOrder(i);
                    placer[i].clearItem();
                }
            }
        }
    }

    public void updateList() {
        orderList = order.get_orderList();
    }

    bool checkOrder(int ind) {
        objPlace item = placer[ind].GetComponent<objPlace>();
        string name = item.getName("item");

        if(item.getName("holder") != "") {
            name = item.getName("holder");
        }

        if(orderList[ind] == name) {
            return true;
        }
        return false;
    }
}
