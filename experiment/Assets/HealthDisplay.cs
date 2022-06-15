using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    
    private int health = 100;
    public Text healthtext;
    public HealthBar bar;
    public Slider slider;
    public Gradient colo;
 
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {

        healthtext.text = "HEALTH : " + health;
        //healthtext.color = colo.Evaluate(slider.normalizedValue);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            health = health - 5;
        }
    }
}
