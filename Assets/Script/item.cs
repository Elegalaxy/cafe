using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    inventory inventory;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<inventory>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(gameObject.tag != "Bin")
            {
                inventory.clickItem(gameObject.GetComponent<SpriteRenderer>().sprite);
            }
            else
            {
                inventory.clearItem();
            }
            //Debug.Log(tag);
        }
    }
}
