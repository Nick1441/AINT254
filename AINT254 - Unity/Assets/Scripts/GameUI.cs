using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Slider HealthBar;
    // Start is called before the first frame update

    public void UpdateHealthbar(int Health)
    {
        HealthBar.value = Health;
    }
}
