using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class inventory : MonoBehaviour
{
    public GameObject item;
    public ParticleSystem smoke;
    public Camera cam;
    public Vector3 dis;
    public bool isSmoke = false;
    public bool isHanding = false;

    void Update()
    {
        dis = cam.ScreenToWorldPoint(Input.mousePosition);
        dis.z = -1f;
        item.transform.position = dis;
    }

    public void clickItem(Sprite itemImg)
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

    public void startSmoke()
    {
        isHanding = true;
        Instantiate(smoke, gameObject.transform);
        isSmoke = true;
    }
}
