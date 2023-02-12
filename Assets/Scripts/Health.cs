using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static float CurrentHealth = 5f;
    public Image FillImage;
    public Text DeathImage;
    public bool death = false;
    [SerializeField] private Slider slider;
    private void Start()
    {
        slider.value = 1;
    }
    void Awake()
    {
        FillImage.enabled = true;
    }
    public void TakeDamage()
    {
        CurrentHealth -= 1;
    }
    
    void Update()
    {
        if (CurrentHealth >= 6)
            CurrentHealth = 5;
        float FillValue = CurrentHealth / 5;
        slider.value = FillValue;
        if (slider.value <= slider.minValue)
        {
            FillImage.enabled = false;
        }
        else
        {
            FillImage.enabled = true;
        }
        
    }

}




