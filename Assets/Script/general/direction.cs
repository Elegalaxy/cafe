using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class direction : MonoBehaviour, IPointerEnterHandler
{
    public moveCam move;
    public bool left = true;
    public void OnPointerEnter(PointerEventData eventData) //get mouse enter and see move left or right
    {
        move.move(left);
    }
}
