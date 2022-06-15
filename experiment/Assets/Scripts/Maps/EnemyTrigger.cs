//using System;
using System.Collections;
//using System.Collections.Generic;
//using System.Collections.Specialized;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public Region region;
    private GameManager gm;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }
   void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
         {
            double vc = 10 / 187.5f;
            double c = 8.5 / 187.5f;
            double sr = 6.75 / 187.5f;
            double r = 3.33 / 187.5f;
            double vr = 1.25 / 187.5f;

            double p = Random.Range(0.0f,300.0f); //Change second Number in order to change encounter percentage
            //cout << p << endl;                    Higher number means LOWER encounter rate. Was 100 changed to 300
            if (p < vr * 100)
            {
                if (gm != null)
                {
                    gm.EnterBattle(Rarity.VeryCommon, region);
                }
            }
            else if (p < r * 100)
            {
                if (gm != null)
                {
                    gm.EnterBattle(Rarity.VeryCommon,region);
                }
            }
            else if (p < sr * 100)
            {
                if (gm != null)
                {
                    gm.EnterBattle(Rarity.VeryCommon,region);
                }
            }
            else if (p < c * 100)
            {
                if (gm != null)
                {
                    gm.EnterBattle(Rarity.VeryCommon,region);
                }
            }
            else if (p < vc * 100)
            {
                if (gm != null)
                {
                    gm.EnterBattle(Rarity.VeryCommon,region);
                }
            }
        }
    }
}
