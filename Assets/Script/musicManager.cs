using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    public AudioClip[] musicList;

    public AudioClip getMusic(string name)
    {
        for (int i = 0; i < musicList.Length; i++)
        {
            if (musicList[i].name == name)
            {
                return musicList[i];
            }
        }
        Debug.Log("Undefined sprite: " + name);
        return null;
    }
}
