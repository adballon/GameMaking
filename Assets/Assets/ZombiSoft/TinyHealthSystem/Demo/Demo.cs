//==============================================================
// Demo Buttons
//==============================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{
    public void Button1()
    {
        HealthySystem.Instance.TakeDamage(10f); // Take damage 10 points
    }
    public void Button2()
    {
        HealthySystem.Instance.HealDamage(10f); // Heal damage 10 points
    }
    public void Button3()
    {
        HealthySystem.Instance.UseMana(10f); // Decrease mana 10 points
    }
    public void Button4()
    {
        HealthySystem.Instance.RestoreMana(10f); // Increase mana 10 points
    }
    public void Button5()
    {
        HealthySystem.Instance.SetMaxHealth(10f); // Add 10 % to max health
    }
    public void Button6()
    {
        HealthySystem.Instance.SetMaxMana(10f); // Add 10 % to max mana
    }
}
