using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class inventory : MonoBehaviour
{
    public GameObject item;
    public Camera cam;
    public Vector3 dis;
    public bool isHanding = false;

    void Update()
    {
        dis = cam.ScreenToWorldPoint(Input.mousePosition);
        dis.z = -1f;
        item.transform.position = dis;
    }
    public string clickItem()// function to return clicking item's name
    {
        return item.GetComponent<SpriteRenderer>().sprite.name;
    }

    public void clickItem(Sprite itemImg) //function to grab and put items
    {

        if (item.GetComponent<SpriteRenderer>().sprite == null)
        {
            item.GetComponent<SpriteRenderer>().sprite = itemImg;
        }
        else if (item.GetComponent<SpriteRenderer>().sprite == itemImg)
        {
            item.GetComponent<SpriteRenderer>().sprite = null;
        }
        else
        {
            Debug.Log("hand is full");
        }
    }

    public Sprite getItem()
    {
        return item.GetComponent<SpriteRenderer>().sprite;
    }

    public void clearItem()
    {
        item.GetComponent<SpriteRenderer>().sprite = null;
    }

    public void changeSprite(Sprite img)
    {
        item.GetComponent<SpriteRenderer>().sprite = img;
    }
}
