using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class objPlace : MonoBehaviour
{
    //this script is for placing object
    inventory inventory;
    machine parentMachine;
    spriteManager spriteManager;

    public SpriteRenderer place;

    private void Start()
    {
        spriteManager = GameObject.FindGameObjectWithTag("SpriteManager").GetComponent<spriteManager>();
        parentMachine = transform.parent.GetComponent<machine>(); //machine of the holder
        place = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>(); //holder
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<inventory>();
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (inventory.item.GetComponent<SpriteRenderer>().sprite != null) //if hand got thing
            {
                if(tag != "Untagged")
                {
                    if (parentMachine.tag == "Grinder") //if this is grinder
                    {
                        if (tag == "Handle" && inventory.item.GetComponent<SpriteRenderer>().sprite.name == "Handle") //if it is handle
                        {
                            manageThing();
                        }
                    }
                    else if (parentMachine.tag == "EspMachine") //if this is Espresso
                    {
                        if (tag == "Handle" && inventory.item.GetComponent<SpriteRenderer>().sprite.name == "Handle with coffee") //if it is handle
                        {
                            manageThing(spriteManager.getSprite("Espresso Machine Handle"));
                        }
                        else if (tag == "Milk" && inventory.item.GetComponent<SpriteRenderer>().sprite.name == "Pitcher") //if it is Pitcher
                        {
                            changeStat(spriteManager.getSprite("Pitcher in steam"));
                            inventory.item.GetComponent<SpriteRenderer>().sprite = null;
                        }
                    }
                    else
                    {
                        Debug.Log("Wrong item");
                    }
                }
                else
                {
                    manageThing();
                }
            }
            else //if hand got nothing
            {
                if(tag != "Untagged")
                {
                    if (!parentMachine.isUsing) //if machine is not using
                    {
                        if (parentMachine.GetComponent<SpriteRenderer>().sprite.name == "Espresso Machine Handle") //Espresso have handle
                        {
                            manageThing(spriteManager.getSprite("Espresso Machine"));
                            inventory.item.GetComponent<SpriteRenderer>().sprite = spriteManager.getSprite("Handle old coffee");
                        }
                        else
                        {
                            inventory.item.GetComponent<SpriteRenderer>().sprite = place.sprite; //take item back
                            place.sprite = null;
                        }
                    }
                    else
                    {
                        Debug.Log("Using");
                    }
                }
                else
                {
                    inventory.item.GetComponent<SpriteRenderer>().sprite = place.sprite; //take item back
                    place.sprite = null;
                }
            }
        }
    }

    public void changeStat(Sprite changeImg)
    {
        place.sprite = changeImg;
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

    void manageThing(Sprite img) //use to change machine sprite
    {
        parentMachine.GetComponent<SpriteRenderer>().sprite = img; //change sprite
        inventory.item.GetComponent<SpriteRenderer>().sprite = null; //set our hand to nothing
    }

}
