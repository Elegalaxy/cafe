using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class objPlace : MonoBehaviour
{
    //this script is for placing object
    inventory inventory;
    GameObject holder;

    string item_name = "", holder_name = "";

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<inventory>();
        holder = transform.GetChild(0).gameObject;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) // When hand got item
        {
            if(inventory.getHandle()) {
                GameObject item = inventory.transform.GetChild(0).gameObject;
                GameObject hold = item.transform.GetChild(0).gameObject;
                manageThing(item, hold);
            }
        }
    }

    void manageThing(GameObject item, GameObject hold) //use to place item
    {
        GetComponent<SpriteRenderer>().sprite = item.GetComponent<SpriteRenderer>().sprite;
        holder.GetComponent<SpriteRenderer>().sprite = hold.GetComponent<SpriteRenderer>().sprite;

        item_name = item.GetComponent<item>().item_name;
        holder_name = item.GetComponent<item>().getHolderName();
    }

    public void clearItem() {
        GetComponent<SpriteRenderer>().sprite = null;
        holder.GetComponent<SpriteRenderer>().sprite = null;
        item_name = "";
        holder_name = "";
    }

    public string getName(string type) {
        if(type == "item")
            return item_name;
        else if(type == "holder")
            return holder_name;

        return "";
    }
}
