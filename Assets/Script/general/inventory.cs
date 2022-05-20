using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class inventory : MonoBehaviour
{
    GameObject item, holder;
    string item_name, holder_name;

    public Camera cam;
    Vector3 dis;
    bool isHanding = false;

    void Start() {
        item = transform.GetChild(0).gameObject;
        holder = item.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if(isHanding) {
            dis = cam.ScreenToWorldPoint(Input.mousePosition);
            dis.z = -1f;
            item.transform.position = dis;
        }
    }

    public Sprite clickItem(GameObject i) //function to grab and put items
    {
        if(item.GetComponent<SpriteRenderer>().sprite == null) { // Hand no item
            /*Instantiate(i, transform);
            item = transform.GetChild(0).gameObject;
            item.transform.localScale = new Vector3(1f, 1f, 1f);*/

            item i_item = i.GetComponent<item>();
            item.GetComponent<SpriteRenderer>().sprite = i_item.getSprite();

            if(i_item != null && i_item.placable == true && i_item.have_item == true) { // Item placable and have item
                holder.GetComponent<SpriteRenderer>().sprite = i_item.getSprite(true);
            }

            isHanding = true;
        } else { // If holding something
            Sprite temp = item.GetComponent<SpriteRenderer>().sprite; // Get current item
            clearItem(); // Remove item

            if(i.GetComponent<item>() != null && i.GetComponent<item>().placable == true) { // Placable and not place holder
                /*Instantiate(i, transform); // Get plate
                item = transform.GetChild(0).gameObject;
                item.transform.localScale = new Vector3(1f, 1f, 1f);

                Instantiate(temp, item.transform); // Put cur item on plate
                temp = transform.GetChild(0).gameObject;
                temp.transform.localScale = new Vector3(1f, 1f, 1f);*/

                return temp;
            }

        }

        return null;
    }

    public void clearItem()
    {
        isHanding = false;
        item_name = "";
        holder_name = "";
        item.GetComponent<SpriteRenderer>().sprite = null;
        holder.GetComponent<SpriteRenderer>().sprite = null;
    }

    public bool getHandle() {
        return isHanding;
    }

    public Vector3 getPos() {
        return dis;
    }

    public void setName(string n, string type) {
        if(type == "item")
            item_name = n;
        else if(type == "holder")
            holder_name = n;
    }

    public string getName(string type) {
        if(type == "item")
            return item_name;
        else if(type == "holder")
            return holder_name;

        return "";
    }
}
