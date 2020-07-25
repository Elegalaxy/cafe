using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    public GameObject item;
    public Camera cam;

    void Update()
    {
        Vector3 dis = cam.ScreenToWorldPoint(Input.mousePosition);
        dis.z = -1f;
        item.transform.position = dis;
    }

    public void clickItem(Sprite itemImg)
    {
        item.GetComponent<SpriteRenderer>().sprite = itemImg;
    }

    public Sprite getItem()
    {
        return item.GetComponent<SpriteRenderer>().sprite;
    }
}
