using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text hp;
    public int HP;

    public void SetMaxHealth( int Maxhealth)
    {
        slider.maxValue = Maxhealth;
        slider.value = Maxhealth;

        gradient.Evaluate(1);
           fill.color = gradient.Evaluate(1);
    }
    public void SetHealth(int health)
    {
        
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        
    }
    void Update()
    {

        
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void AddMember(HealthBar b)
    {
        //this.slider = b.slider;
        //this.gradient = b.gradient;
        //this.fill = b.fill;
        //this.hp = b.hp;
        //this.HP = b.HP;
    }
    public void Destruction()
    {
        Destroy(this.gameObject);
    }
  
}
