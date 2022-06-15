//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseAlly : MonoBehaviour
{
    public string AllyName;
    public Sprite image;
    public Allytype type;
    public int HP;
    public int maxHP;
    public Stat DefStat;
    public Stat AttStat;
    public UnitStat stats;
    //public BattleManager bm;
    //public GameManager gm;

    public int level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddMember(BaseAlly ba)
    {
        this.AllyName = ba.AllyName;
        this.image = ba.image;
        this.type = ba.type;
        this.HP = ba.HP;
        this.maxHP = ba.maxHP;
        this.AttStat = ba.AttStat;
        this.DefStat = ba.DefStat;
        this.stats = ba.stats;
        
        this.level = ba.level;
        //this.battlestance = ba.battlestance;
    }
    public int TakeDamageAlly(BaseAlly defender, int power, attribute type, UnitStat atstat)
    {
   
        bool supereffective = false;
        int basedamage = Mathf.FloorToInt(power * 100  /((25 + defender.stats.DefenseStat)*5) + power*.25f);
        int max = (int)((1+ (.01*((200 + basedamage) / (5 + .25*basedamage)))) * basedamage);
        int min = (int)((1 -( .01 * ((200 + basedamage) / (5 + .25*basedamage)))) * basedamage);
      
        int damagetaken = Random.Range(min, max + 1);
        if (damagetaken <= 0)
        {
            damagetaken = 1;
        }

        /*if (type == attribute.Fire && defender.type == attribute.Grass || type == attribute.Grass && defender.type == attribute.Water || type == attribute.Water && defender.type == attribute.Fire)
        {
            supereffective = true;
            damagetaken = Mathf.FloorToInt(damagetaken * 1.25f);
        }*/

        bool crit = false;
       int critical = Random.Range(1, 101);
        if (atstat.Luck >= critical)
        {
            damagetaken = Mathf.FloorToInt(damagetaken * 1.5f);
        }

        HP -= damagetaken;
        if (HP < 0) { HP = 0; }

        return damagetaken;
    }

}



public enum Allytype
{
    Mage,
    Thief,
    Gunslinger,
    Warrior,
    Archer
}


[System.Serializable]
public class AllyEvolution
{
    public BaseAlly nextEvo;
    public int levelUpLevel;
}