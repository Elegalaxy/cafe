using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public inventory inventory;
    private void OnMouseEnter()
    {
        Debug.Log(tag);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            inventory.clickItem(gameObject.GetComponent<SpriteRenderer>().sprite);
        }
    }
}
