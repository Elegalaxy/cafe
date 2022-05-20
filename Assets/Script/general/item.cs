using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class item : MonoBehaviour
{
    public bool placable = false;
    public bool have_item = false;
    public string item_name = "";
    string holder_name = "";

    inventory inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<inventory>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Sprite item = inventory.clickItem(gameObject);

            if(placable && have_item == false && item != null) { // Can be place, no item, got item back
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = item;
                holder_name = inventory.getName("item");
                have_item = true;
            }
        }
    }

    public Sprite getSprite(bool isChild = false) {
        if(isChild) {
            Sprite temp = transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null; // Remove item on holder
            have_item = false;
            return temp;
        }

        return GetComponent<SpriteRenderer>().sprite;
    }

    public string getHolderName() {
        return holder_name;
    }
}
