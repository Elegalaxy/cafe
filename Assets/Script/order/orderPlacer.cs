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
            if(transform.GetChild(i).GetComponent<objPlace>() != null) placer[i] = transform.GetChild(i).GetComponent<objPlace>();
        }
    }

    private void Update() {
        for(int i = 0; i < placer.Length; i++) {
            if(placer[i].GetComponent<objPlace>().place.sprite != null) {
                if(checkOrder(i)) {
                    order.correctOrder(i);
                    placer[i].place.sprite = null;
                }
            }
        }
    }

    public void updateList() {
        orderList = order.get_orderList();
    }

    bool checkOrder(int ind) {
        //Debug.Log(placer[ind].GetComponent<objPlace>().place.sprite.name);
        if(orderList[ind] == placer[ind].GetComponent<objPlace>().place.sprite.name) {
            return true;
        }
        return false;
    }
}
