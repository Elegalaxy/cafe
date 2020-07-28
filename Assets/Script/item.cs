﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class item : MonoBehaviour
{
    spriteManager spriteManager;
    inventory inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<inventory>();
        spriteManager = GameObject.FindGameObjectWithTag("SpriteManager").GetComponent<spriteManager>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.GetComponent<SpriteRenderer>().sprite != null)
            {
                if (gameObject.GetComponent<SpriteRenderer>().sprite.name == "Handle" || gameObject.GetComponent<SpriteRenderer>().sprite.name == "Pitcher" || gameObject.GetComponent<SpriteRenderer>().sprite.name == "Plastic Cup")
                {
                    inventory.clickItem(gameObject.GetComponent<SpriteRenderer>().sprite);
                    gameObject.GetComponent<SpriteRenderer>().sprite = null;
                }
                else if (gameObject.tag != "Bin")
                {
                    inventory.clickItem(gameObject.GetComponent<SpriteRenderer>().sprite);
                }
                else if(gameObject.tag == "Bin")
                {
                    if (inventory.item.GetComponent<SpriteRenderer>().sprite.name == "Handle old coffee")
                    {
                        inventory.changeSprite(spriteManager.getSprite("Handle"));
                    }
                    else if (inventory.item.GetComponent<SpriteRenderer>().sprite.name == "Handle" || inventory.item.GetComponent<SpriteRenderer>().sprite.name == "Pitcher" || inventory.item.GetComponent<SpriteRenderer>().sprite.name == "Plastic Cup")
                    {
                        Debug.Log("Not Throwable");
                    }
                    else
                    {
                        inventory.clearItem();
                    }
                }

            }
        }
    }
}