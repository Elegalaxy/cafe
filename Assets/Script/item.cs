using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class item : MonoBehaviour
{
    inventory inventory;
    public bool placable = false;
    objPlace placeholder;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<inventory>();
        if(placable) {
            placeholder = GetComponent<objPlace>();
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            inventory.clickItem(gameObject);
        }
    }
}
