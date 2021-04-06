//canvas screen space overlay
//canvas - slider : no interactable, transition vavigation none

// in enemy/player
// public HealthBar HealthBar;

//in start player/enemy
//HealthBar.SetHealth(Hitpoints, MaxHitpoints);

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 offset;

    public void SetHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(health<maxHealth);
        slider.value=health;
        slider.maxValue=maxHealth;
        slider.fillRect.GetComponentInChildren<Image>().color= Color.Lerp(low, high, slider.normalizedValue);
    }

    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }

    
}