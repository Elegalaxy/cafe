using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class spriteManager : MonoBehaviour
{
    public Sprite[] spriteList;

    public Sprite getSprite(string spriteName)
    {
        for(int i = 0; i < spriteList.Length; i++)
        {
            if (spriteList[i].name == spriteName)
            {
                return spriteList[i];
            }
        }
        Debug.Log("Undefined sprite: " + spriteName);
        return null;
    }
}
