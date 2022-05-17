using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class objPlace : MonoBehaviour
{
    //this script is for placing object
    inventory inventory;
    List<item> items;

    public SpriteRenderer place;

    private void Start()
    {
        place = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>(); //holder
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<inventory>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(inventory.item.GetComponent<SpriteRenderer>().sprite != null) //if hand got thing
            {

            }
        }
    }

    void manageThing() //use to place item
    {
        if (place.sprite != null)
        {
            Debug.Log("The place is full");
        }
        else
        {
            place.sprite = inventory.getItem(); //place item
            inventory.item.GetComponent<SpriteRenderer>().sprite = null; //set our hand to nothing
        }
    }

    void takeBack()
    {
        inventory.item.GetComponent<SpriteRenderer>().sprite = place.sprite; //take item back
        place.sprite = null;
    }
}
