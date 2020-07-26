using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objPlace : MonoBehaviour
{
    //this script is for placing object
    inventory inventory;
    public SpriteRenderer place;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<inventory>();
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (inventory.item.GetComponent<SpriteRenderer>().sprite != null) //if hand got thing
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
            else //if hand got nothing
            {
                inventory.item.GetComponent<SpriteRenderer>().sprite = place.sprite; //take item back
                place.sprite = null;
            }
        }
    }
}
