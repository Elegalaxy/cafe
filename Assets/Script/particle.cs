using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    ParticleSystem system;
    inventory inventory;
    float startTime = 2.7f;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<inventory>();
        system = gameObject.GetComponent<ParticleSystem>();
        gameObject.GetComponent<ParticleSystem>().Simulate(startTime);
        system.Play();
    }

    private void Update()
    {
        if (inventory.isHanding)
        {
            gameObject.transform.position = transform.parent.GetComponent<inventory>().dis;
        }
    }
}
