using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    machine parentMachine;
    spriteManager spriteManager;

    private void Start()
    {
        spriteManager = GameObject.FindGameObjectWithTag("SpriteManager").GetComponent<spriteManager>();
        parentMachine = transform.parent.GetComponent<machine>(); //machine of the holder
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(parentMachine.machineName == "Grinder") //if grinder
            {
                if (parentMachine.isHandle) //got handle
                {
                    if (gameObject.name == ("ButtonSingle") && !parentMachine.isUsing) //single shot btn
                    {
                        parentMachine.GetComponent<SpriteRenderer>().sprite = spriteManager.getSprite("Grinding Machine Single");
                        parentMachine.isOperateSingle = true;
                    }
                    else if (gameObject.name == ("ButtonDouble") && !parentMachine.isUsing) //double shot btn
                    {
                        parentMachine.GetComponent<SpriteRenderer>().sprite = spriteManager.getSprite("Grinding Machine Double");
                        parentMachine.isOperateDouble = true;
                    }
                }
                else
                {
                    Debug.Log("no handle");
                }
            }
            else if (parentMachine.machineName == "EspMachine") //is Espresso
            {
                if (parentMachine.isHandle) //got handle
                {
                    if (gameObject.name == ("ButtonSingle") && !parentMachine.isUsing) //single shot btn
                    {
                        parentMachine.GetComponent<SpriteRenderer>().sprite = spriteManager.getSprite("Espresso Machine Single");
                        parentMachine.isOperateSingle = true;
                    }
                    else if (gameObject.name == ("ButtonDouble") && !parentMachine.isUsing) //double shot btn
                    {
                        parentMachine.GetComponent<SpriteRenderer>().sprite = spriteManager.getSprite("Espresso Machine Double");
                        parentMachine.isOperateDouble = true;
                    }
                }
                else
                {
                    Debug.Log("no handle");
                }
            }
        }
    }
}
