//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BaseEnemy : MonoBehaviour
{
    public string EnemyName;
    public Sprite image;
    public Region regionfound;
    public attribute type;
    public Rarity rarity;
    public UnitStat unitstat;
    public int HP;
    private int maxHP;
    public Stat AttackStat;
    public Stat DefStat;
    public Animator battlestance;
   // public GameManager gm;
    //public BattleManager bm;

    //public HealthBar health;


    public bool canEvolve;
    public EnemyEvolution evolveTo;

    private int level;


    // Start is called before the first frame update
    void Start()
    {
        maxHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMember(BaseEnemy be)
    {
        this.EnemyName = be.EnemyName;
        this.image = be.image;
        this.regionfound = be.regionfound;
        this.type = be.type;
        this.rarity = be.rarity;
        this.HP = be.HP;
        this.maxHP = be.maxHP;
        this.AttackStat = be.AttackStat;
        this.DefStat = be.DefStat;
        this.unitstat = be.unitstat;
        this.canEvolve = be.canEvolve;
        this.evolveTo = be.evolveTo;
        this.level = be.level;
        //this.battlestance = be.battlestance;
    }
    public int TakeDamage(BaseEnemy defender, int power, attribute type, UnitStat atstat)
    {
        bool supereffective = false;
        int basedamage = Mathf.FloorToInt(power * 100  /((25 + defender.unitstat.DefenseStat)*5) + power*.25f);
        int max = (int)((1+ (.01*((200 + basedamage) / (5 + .25*basedamage)))) * basedamage);
        int min = (int)((1 -( .01 * ((200 + basedamage) / (5 + .25*basedamage)))) * basedamage);

        int damagetaken = Random.Range(min, max + 1);
        if(damagetaken <=0)
        {
            damagetaken = 1;
        }

        if (type == attribute.Fire && defender.type == attribute.Grass|| type == attribute.Grass && defender.type == attribute.Water|| type == attribute.Water && defender.type == attribute.Fire)
        {
            supereffective = true;
            damagetaken = Mathf.FloorToInt(damagetaken * 1.25f);
        }
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

public enum Rarity
{
    VeryCommon, Common, SemiRare, Rare, VeryRare
}
public enum attribute
{
    Fire,
    Water,
    Grass,
    None
}





[System.Serializable]
public class EnemyEvolution
{
    public BaseEnemy nextEvo;
    public int level;
}
[System.Serializable]
public class UnitStat
{
    public int AttackStat;
    public int DefenseStat;
    public int SpeedStat;
    public int MagicAttackStat;
    public int MagicDefenseStat;
    public int EvasionStat;
    public int Luck;

}


