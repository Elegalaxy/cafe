using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class inventory : MonoBehaviour
{
    GameObject item;
    public Camera cam;
    Vector3 dis;
    bool isHanding = false;

    void Update()
    {
        if(isHanding) {
            dis = cam.ScreenToWorldPoint(Input.mousePosition);
            dis.z = -1f;
            item.transform.position = dis;
        }
    }

    public GameObject clickItem(GameObject i) //function to grab and put items
    {
        int count = transform.childCount;

        if(count == 0) { // Hand no item
            Instantiate(i, transform);
            item = transform.GetChild(0).gameObject;
            item.transform.localScale = new Vector3(1f, 1f, 1f);
            isHanding = true;
        } else if(count != 0) { // If holding something
            if(i.GetComponent<objPlace>() == null) { // If its not holder
                clearItem(); // Remove item
            }

            if(i.GetComponent<objPlace>() != null) { // There is a place holder
                return item; // Return item to holder
            }
        }

        return null;
    }

    public void clearItem()
    {
        isHanding = false;
        Destroy(transform.GetChild(0).gameObject);
        item = null;
    }

    public bool getHandle() {
        return isHanding;
    }

    public Vector3 getPos() {
        return dis;
    }
}
