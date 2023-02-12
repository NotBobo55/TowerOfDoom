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
        int Random = UnityEngine.Random.Range(0, 12);
        if (Random >= 8)
        {
            Score.instance.AddPoint();
            return Destinations[8];
        }
        return Destinations[Random];
    }

}
