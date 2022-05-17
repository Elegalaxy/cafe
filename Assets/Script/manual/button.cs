using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    machine parentMachine;
    spriteManager spriteManager;
    musicManager musicManager;
    GameObject btn;

    private void Start()
    {
        if(name == "MilkButton")
        {
            btn = transform.GetChild(0).gameObject;
            btn.SetActive(false);
        }
        spriteManager = GameObject.FindGameObjectWithTag("SpriteManager").GetComponent<spriteManager>();
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<musicManager>();
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
                        AudioSource.PlayClipAtPoint(musicManager.getMusic("grind 3.5"), transform.position);
                        parentMachine.GetComponent<SpriteRenderer>().sprite = spriteManager.getSprite("Grinding Machine Single");
                        parentMachine.isOperateSingle = true;
                    }
                    else if (gameObject.name == ("ButtonDouble") && !parentMachine.isUsing) //double shot btn
                    {
                        AudioSource.PlayClipAtPoint(musicManager.getMusic("grind 5.5"), transform.position);
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
                        AudioSource.PlayClipAtPoint(musicManager.getMusic("espresso 3.5"), transform.position);
                        parentMachine.GetComponent<SpriteRenderer>().sprite = spriteManager.getSprite("Espresso Machine Single");
                        parentMachine.isOperateSingle = true;
                    }
                    else if (gameObject.name == ("ButtonDouble") && !parentMachine.isUsing) //double shot btn
                    {
                        AudioSource.PlayClipAtPoint(musicManager.getMusic("espresso 5.5"), transform.position);
                        parentMachine.GetComponent<SpriteRenderer>().sprite = spriteManager.getSprite("Espresso Machine Double");
                        parentMachine.isOperateDouble = true;
                    }
                }
                
                if (parentMachine.isPitcher)
                {
                    if (gameObject.name == "MilkButton" && !parentMachine.milkBtn)
                    {
                        parentMachine.startMilk();
                    }
                }

                if(gameObject.name == "WaterButton") {
                    parentMachine.startWater();
                }
            }
        }
    }
}
