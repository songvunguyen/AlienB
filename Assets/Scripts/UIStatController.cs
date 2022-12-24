using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIStatController : MonoBehaviour
{
    public Slider healthBar;
    public Slider shieldBar;
    public TextMeshProUGUI statBar;

    public void SetMaxHealth (float health){
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    public void SetHealth (float health){
        healthBar.value = health;
    }

    public void SetMaxShield (float shield){
        shieldBar.maxValue = shield;
        shieldBar.value = shield;
    }

    public void SetShield (float shield){
        shieldBar.value = shield;
    }

    public void SetStat (string stat){
        statBar.text = stat;
    }
}
