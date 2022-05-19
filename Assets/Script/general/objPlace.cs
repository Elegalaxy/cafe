using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class objPlace : MonoBehaviour
{
    //this script is for placing object
    inventory inventory;
    List<item> items;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<inventory>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && inventory.transform.childCount != 0) // When hand got item
        {
            GameObject item = inventory.clickItem(gameObject);
            if(item != null && transform.childCount == 0) { // Get item and put in child
                manageThing(item);
            } else {
                Debug.Log("Full");
            }
        }
    }

    void manageThing(GameObject item) //use to place item
    {
        Instantiate(item, transform);
        transform.GetChild(0).localScale = new Vector3(1f, 1f, 1f); // Reset scale
    }

    public void clearItem() {
        Destroy(transform.GetChild(0).gameObject);
    }
}
