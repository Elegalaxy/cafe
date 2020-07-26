using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class item : MonoBehaviour
{
    inventory inventory;

    bool handleFull;

    private void Start()
    {
        handleFull = false;
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<inventory>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.GetComponent<SpriteRenderer>().sprite != null)
            {
                if (gameObject.GetComponent<SpriteRenderer>().sprite.name == "Handle")
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
                        handleFull = false;
                        inventory.changeSprite(inventory.handleEmpty);
                    }
                    else if (inventory.item.GetComponent<SpriteRenderer>().sprite.name == "Handle")
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
