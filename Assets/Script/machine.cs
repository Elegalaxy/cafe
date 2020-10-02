using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class machine : MonoBehaviour
{
    public spriteManager spriteManager;
    public musicManager musicManager;

    public string machineName;
    GameObject[] holder;

    public bool isUsing;
    public bool isOperateSingle;
    public bool isOperateDouble;
    public bool isHandle;

    float operateTime;
    int indNum;
    float orgOperateTime = 3f;
    GameObject milkButton;

    //Espresso
    public bool isMilk;
    public bool milkBtn;
    public bool isPitcher;
    public ParticleSystem smoke;

    float milkTime;
    float orgMilkTime = 4f;
    Sprite currentSprite;

    void Start()
    {
        milkButton = GameObject.Find("MilkButton").transform.GetChild(0).gameObject;
        machineName = gameObject.tag;
        indNum = transform.childCount; //get child item num

        isUsing = false;
        isHandle = false;
        isOperateSingle = false; //single and double shot
        isOperateDouble = false;
        isMilk = false;
        milkBtn = false;
        isPitcher = false;

        operateTime = orgOperateTime;
        milkTime = orgMilkTime;

        holder = new GameObject[indNum]; //initial holder array

        for (int i = 0; i < indNum; i++)
        {
            holder[i] = transform.GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        if (machineName == "Grinder") //if grinder
        {
            if (holder[0].GetComponent<objPlace>().place.sprite != null)
            {
                if (holder[0].GetComponent<objPlace>().place.sprite.name == "Handle") //if have handle
                {
                    isHandle = true;
                }
            }

            if (isHandle)
            {
                if (isOperateSingle && operateTime > 0) //single shot
                {
                    //if ()
                    {

                    }
                    isUsing = true;
                    operateTime -= Time.deltaTime;
                }
                else if (isOperateDouble && operateTime > -2f) //double shot
                {
                    isUsing = true;
                    operateTime -= Time.deltaTime;
                }
                else if (operateTime <= -2f || operateTime <= 0) //when finish grind
                {
                    holder[0].GetComponent<objPlace>().changeStat(spriteManager.getSprite("Handle with coffee"));
                    gameObject.GetComponent<SpriteRenderer>().sprite = spriteManager.getSprite("Grinding Machine");
                    AudioSource.PlayClipAtPoint(musicManager.getMusic("grinder off"), transform.position);
                    isHandle = false;
                    isOperateSingle = false;
                    isOperateDouble = false;
                    isUsing = false;
                    operateTime = orgOperateTime;
                }
            }
        }
        else if (machineName == "EspMachine") //if Espresso machine
        {
            if (gameObject.GetComponent<SpriteRenderer>().sprite.name == "Espresso Machine Handle") //have handle
            {
                isHandle = true;
            }

            if (isOperateSingle && operateTime > 0) //single shot
            {
                isUsing = true;
                operateTime -= Time.deltaTime;
            }
            else if (isOperateDouble && operateTime > -2f) //double shot
            {
                isUsing = true;
                operateTime -= Time.deltaTime;
            }
            else if ((isOperateDouble && operateTime <= -2f) || (isOperateSingle && operateTime <= 0)) //Espress finish
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteManager.getSprite("Espresso Machine Handle");

                //cups
                currentSprite = holder[2].GetComponent<objPlace>().place.sprite;
                switch (currentSprite.name)
                {
                    case "M":
                        holder[2].GetComponent<objPlace>().place.sprite = spriteManager.getSprite("SIM");
                        break;
                    case "LC":
                        holder[2].GetComponent<objPlace>().place.sprite = spriteManager.getSprite("SILC");
                        break;
                    case "CC":
                        holder[2].GetComponent<objPlace>().place.sprite = spriteManager.getSprite("SICC");
                        break;
                    case "ESC":
                        holder[2].GetComponent<objPlace>().place.sprite = spriteManager.getSprite("SIESC");
                        break;
                    case "TLG":
                        holder[2].GetComponent<objPlace>().place.sprite = spriteManager.getSprite("SITLG");
                        break;
                    case "TKG":
                        holder[2].GetComponent<objPlace>().place.sprite = spriteManager.getSprite("SITKG");
                        break;
                    default:
                        Debug.Log("Cup lose");
                        break;
                }

                isHandle = false;
                isOperateSingle = false;
                isOperateDouble = false;
                isUsing = false;
                operateTime = orgOperateTime;
            }

            //milk
            if (holder[1].GetComponent<objPlace>().place.sprite != null)
            {
                if (holder[1].GetComponent<objPlace>().place.sprite.name == "Pitcher") //if have pitcher
                {
                    isPitcher = true;
                }

                if (isPitcher)
                {
                    if (milkTime > 0 && milkBtn) //milk time
                    {
                        isMilk = true;
                        milkTime -= Time.deltaTime;
                    }
                    else if (milkTime <= 0) //when finish steam
                    {
                        holder[1].GetComponent<objPlace>().changeStat(spriteManager.getSprite("Pitcher with milk"));
                        Instantiate(smoke, holder[1].transform);
                        milkButton.SetActive(false);
                        isPitcher = false;
                        isMilk = false;
                        milkBtn = false;
                        milkTime = orgMilkTime;
                    }
                }
            }
        }
    }
}
