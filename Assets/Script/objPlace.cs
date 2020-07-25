using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objPlace : MonoBehaviour
{
    public inventory inventory;
    public SpriteRenderer place;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            place.sprite = inventory.getItem();
        }
    }
}
