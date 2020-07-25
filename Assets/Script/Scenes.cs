using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    int indexMax = 2;
    public void Play(int index)
    {
        if(index <= indexMax)
        {
            SceneManager.LoadScene(index);
        }
        else
        {
            Debug.Log("Please add scenes into build setting");
        }
    }
}
