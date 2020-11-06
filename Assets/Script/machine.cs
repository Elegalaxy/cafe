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
    //Milk
    public bool milkBtn;
    public bool isPitcher;

    float milkTime;
    float orgMilkTime = 4f;
    Sprite currentSprite;

    //hot water
    public bool waterBtn;
    public bool isWaterCup;

    float waterTime;
    float orgWaterTime = 4f;

    void Start()
    {
        if(name == "Espresso Machine") milkButton = GameObject.Find("MilkButton").transform.GetChild(0).gameObject;
        machineName = gameObject.tag;
        indNum = transform.childCount; //get child item num

        isUsing = false;
        isHandle = false;
        isOperateSingle = false; //single and double shot
        isOperateDouble = false;
        milkBtn = false;
        isPitcher = false;
        waterBtn = false;
        isWaterCup = false;

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
                if (holder[1].GetComponent<objPlace>().place.sprite.name == "Pitcher in Steam") //if have pitcher
                {
                    isPitcher = true;
                }

                if (isPitcher)
                {
                    if(milkBtn && milkTime > 0) {
                        milkTime -= Time.deltaTime;
                    }
                    else if (milkTime <= 0) //when finish steam
                    {
                        holder[1].GetComponent<objPlace>().changeStat(spriteManager.getSprite("Pitcher with milk"));
                        milkButton.SetActive(false);
                        isPitcher = false;
                        milkBtn = false;
                    }
                }
            }

            //hot water
            if(holder[3].GetComponent<objPlace>().place.sprite != null && holder[1].GetComponent<objPlace>().place.sprite.name == "Plastic Cup") {
                if(waterBtn && waterTime > 0) {
                    waterTime -= Time.deltaTime;
                }else if(waterTime <= 0) {
                    holder[3].GetComponent<objPlace>().changeStat(spriteManager.getSprite("Pitcher with milk"));
                    //milkButton.SetActive(false);
                    isWaterCup = false;
                    waterBtn = false;
                }
            }
        }
    }

    public void startMilk() {
        milkTime = orgMilkTime;
        milkButton.SetActive(true);
        milkBtn = true;
    }

    public void startWater() {
        waterTime = orgWaterTime;
        //milkButton.SetActive(true);
        waterBtn = true;
    }
}
