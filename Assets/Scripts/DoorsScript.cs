using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using System;


public class DoorsScript : MonoBehaviour
{
    [SerializeField] private Transform[] Destinations;
    public Transform GetDestination()
    {
        //Određuje kroz koja vrata ćete izaći nakon što ste pritisnuli tipku F
        int Random = UnityEngine.Random.Range(0, 12);
        if (Random >= 8)
        {
            Debug.Log(Random);
            Score.instance.AddPoint();
            return Destinations[8];
        }
        Debug.Log(Random);
        return Destinations[Random];

    }

}
