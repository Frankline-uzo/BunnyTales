//using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
//using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject battleCamera;
    public GameObject player;
    public Canvas battle;

    public List<BaseEnemy> allEnemies = new List<BaseEnemy>();
    public List<Moves> allMoves = new List<Moves>();
    public List<BaseAlly> allAllies = new List<BaseAlly>();

    public Transform Enemypodium1;
    public Transform Enemypodium2;
    public Transform Enemypodium3;
    public Transform Enemypodium4;
    public Transform Enemypodium5;

    public Transform HeroPodium1;
    public Transform HeroPodium2;
    public Transform HeroPodium3;
    public Transform HeroPodium4;

    public GameObject Robbie;

    public HealthBar filledhealth;
    

    public GameObject emptymonster;
    public GameObject healthbar1;
    public GameObject healthbar2;
    public GameObject healthbar3;
    public GameObject healthbar4;
    public GameObject healthbar5;

    public Sprite grassland;
    public int numEnemies;
   
    public BattleManager bm;
    public Animator animator;
    public BaseEnemy[] inbattle = new BaseEnemy[5];
    public BaseAlly[] ALLIES = new BaseAlly[4];
    
    public HealthBar[] enemyhealth = new HealthBar[5];
    public HealthBar[] ehealthicon = new HealthBar[5];

    public HealthBar[] playerhealth = new HealthBar[4];
    
    // Start is called before the first frame update
    void Start()
    {
        playerCamera.SetActive(true);
        battleCamera.SetActive(false);
        ALLIES[0].HP = ALLIES[0].maxHP;
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    

    public void EnterBattle(Rarity rarity, Region region)
    {
    playerCamera.SetActive(false);
    battleCamera.SetActive(true);
    player.GetComponent<playermovement>().isAllowedToMove = false;

        GameObject rob = Instantiate(Robbie, HeroPodium1.transform.position, Quaternion.identity) as GameObject;
        HealthBar barR = Instantiate(filledhealth, HeroPodium1.transform.position, Quaternion.identity) as HealthBar;
        barR.transform.parent = battle.transform;
        barR.transform.localScale = new Vector3(1f, 1f, 0f);
        barR.transform.Translate(0, -.3f, 0);

        //barR.AddMember(filledhealth);
        rob.transform.Translate(.7f, .8f, 0);
        rob.transform.parent = HeroPodium1;
        rob.GetComponent<SpriteRenderer>().sortingOrder = 2;
        //BaseAlly tempal = rob.AddComponent<BaseAlly>() as BaseAlly;
        //tempal.AddMember(allAllies[0]);
        playerhealth[0] = barR;
        


        //ALLIES[0] = tempal;
        playerhealth[0].SetMaxHealth(ALLIES[0].maxHP);
        playerhealth[0].SetHealth(ALLIES[0].HP);
        if (region == Region.Grassy)
        {
        numEnemies = Random.Range(1, 3);
        }
        else if(region == Region.Forest)
        {
            numEnemies = Random.Range(2, 4);
        }
        else if(region == Region.Sandy)
        {
            numEnemies = Random.Range(3, 5);
        }
        else if (region == Region.Cold)
            {
            numEnemies = Random.Range(4, 6);
        }
        BaseEnemy battleeneemy;
        battleeneemy = GetRandomEnemyFromList(GetEnemyByRarity(rarity));

        Debug.Log(battleeneemy.name);

    
        GameObject denemy3 = Instantiate(emptymonster, Enemypodium3.transform.position, Quaternion.identity) as GameObject;
        HealthBar bar3 = Instantiate(filledhealth, Enemypodium3.transform.position, Quaternion.identity) as HealthBar;
        bar3.transform.parent = battle.transform;
        bar3.transform.localScale =new Vector3(1f, 1f, 0f);
        bar3.transform.Translate(0, -.3f, 0);
        
        bar3.AddMember(filledhealth);
        ehealthicon[2] = bar3;
        denemy3.transform.Translate(0,.6f,0);
        denemy3.transform.parent = Enemypodium3;

        HealthBar health3 = bar3;//.AddComponent<HealthBar>() as HealthBar;
        //Debug.Log(deneemy.name);
        BaseEnemy tempen = denemy3.AddComponent<BaseEnemy>() as BaseEnemy;
        tempen.AddMember(battleeneemy);
        health3.AddMember(filledhealth);
        
        denemy3.GetComponent<SpriteRenderer>().sprite = battleeneemy.image;
        denemy3.GetComponent<SpriteRenderer>().sortingOrder = 2;
        
        //animator = denemy.GetComponent<Animator>();
       animator = battleeneemy.battlestance;
        inbattle[2] = tempen;
        
        enemyhealth[2] = health3;
        enemyhealth[2].SetMaxHealth(inbattle[2].HP);

        if (numEnemies == 2)
        {
            BaseEnemy battleeneemy2;
            battleeneemy2 = GetRandomEnemyFromList(GetEnemyByRarity(rarity));

            Debug.Log(battleeneemy2.name);

            
            GameObject denemy1 = Instantiate(emptymonster, Enemypodium1.transform.position, Quaternion.identity) as GameObject;
            HealthBar bar1 = Instantiate(filledhealth, Enemypodium1.transform.position, Quaternion.identity) as HealthBar;
            bar1.transform.parent = battle.transform;
            bar1.transform.localScale = new Vector3(1f, 1f, 0f);
            bar1.transform.Translate(0, -.3f, 0);

            bar1.AddMember(filledhealth);
            ehealthicon[0] = bar1;
            HealthBar health1 = bar1;
            enemyhealth[0] = health1;
            
            denemy1.transform.Translate(0, .6f, 0);
            denemy1.transform.parent = Enemypodium1;

            //Debug.Log(deneemy.name);
            BaseEnemy tempen2 = denemy1.AddComponent<BaseEnemy>() as BaseEnemy;
            tempen2.AddMember(battleeneemy2);

            denemy1.GetComponent<SpriteRenderer>().sprite = battleeneemy2.image;
            denemy1.GetComponent<SpriteRenderer>().sortingOrder = 2;

            inbattle[0] = tempen2;
            
            inbattle[2] = tempen;
            Debug.Log("Enemy health 0:");
            Debug.Log(enemyhealth[0]);
            Debug.Log("inbattle 0 HP");
            Debug.Log(inbattle[0].HP);
            enemyhealth[0].SetMaxHealth(inbattle[0].HP);
            enemyhealth[2].SetMaxHealth(inbattle[2].HP);
        }
        else if(numEnemies == 3)
        {
            BaseEnemy battleeneemy2;
            battleeneemy2 = GetRandomEnemyFromList(GetEnemyByRarity(rarity));

            Debug.Log(battleeneemy2.name);


            GameObject denemy1 = Instantiate(emptymonster, Enemypodium1.transform.position, Quaternion.identity) as GameObject;
            HealthBar bar1 = Instantiate(filledhealth, Enemypodium1.transform.position, Quaternion.identity) as HealthBar;
            bar1.transform.parent = battle.transform;
            bar1.transform.localScale = new Vector3(1f, 1f, 0f);
            bar1.transform.Translate(0, -.3f, 0);

            bar1.AddMember(filledhealth);
            ehealthicon[0] = bar1;
            HealthBar health1 = bar1;
            enemyhealth[0] = health1;
            denemy1.transform.Translate(0, .6f, 0);
            denemy1.transform.parent = Enemypodium1;

            //Debug.Log(deneemy.name);
            BaseEnemy tempen2 = denemy1.AddComponent<BaseEnemy>() as BaseEnemy;
            tempen2.AddMember(battleeneemy2);

            denemy1.GetComponent<SpriteRenderer>().sprite = battleeneemy2.image;
            denemy1.GetComponent<SpriteRenderer>().sortingOrder = 2;



            ///-----------------------------------------------------------------------------------------------


            BaseEnemy battleeneemy3;
            battleeneemy3 = GetRandomEnemyFromList(GetEnemyByRarity(rarity));

            Debug.Log(battleeneemy3.name);


            GameObject denemy5 = Instantiate(emptymonster, Enemypodium5.transform.position, Quaternion.identity) as GameObject;
            HealthBar bar5 = Instantiate(filledhealth, Enemypodium5.transform.position, Quaternion.identity) as HealthBar;
            bar5.transform.parent = battle.transform;
            bar5.transform.localScale = new Vector3(1f, 1f, 0f);
            bar5.transform.Translate(0, -.3f, 0);

            bar5.AddMember(filledhealth);
            ehealthicon[4] = bar5;
            HealthBar health5 = bar5;
            enemyhealth[4] = health5;
            denemy5.transform.Translate(0, .6f, 0);
            denemy5.transform.parent = Enemypodium5;
            //Debug.Log(deneemy.name);
            BaseEnemy tempen3 = denemy5.AddComponent<BaseEnemy>() as BaseEnemy;
            tempen3.AddMember(battleeneemy3);

            denemy5.GetComponent<SpriteRenderer>().sprite = battleeneemy3.image;
            denemy5.GetComponent<SpriteRenderer>().sortingOrder = 2;


            inbattle[0] = tempen2;
            inbattle[2] = tempen;
            inbattle[4] = tempen3;
            enemyhealth[0].SetMaxHealth(inbattle[0].HP);
            enemyhealth[2].SetMaxHealth(inbattle[2].HP);
            enemyhealth[4].SetMaxHealth(inbattle[4].HP);


        }
        else if(numEnemies == 4)
        {
            BaseEnemy battleeneemy2;
            battleeneemy2 = GetRandomEnemyFromList(GetEnemyByRarity(rarity));

            Debug.Log(battleeneemy2.name);


            GameObject denemy1 = Instantiate(emptymonster, Enemypodium1.transform.position, Quaternion.identity) as GameObject;
            HealthBar bar1 = Instantiate(filledhealth, Enemypodium1.transform.position, Quaternion.identity) as HealthBar;
            bar1.transform.parent = battle.transform;
            bar1.transform.localScale = new Vector3(1f, 1f, 0f);
            bar1.transform.Translate(0, -.3f, 0);

            bar1.AddMember(filledhealth);
            ehealthicon[0] = bar1;
            HealthBar health1 = bar1;
            enemyhealth[0] = health1;
            denemy1.transform.Translate(0, .6f, 0);
            denemy1.transform.parent = Enemypodium1;

            //Debug.Log(deneemy.name);
            BaseEnemy tempen2 = denemy1.AddComponent<BaseEnemy>() as BaseEnemy;
            tempen2.AddMember(battleeneemy2);

            denemy1.GetComponent<SpriteRenderer>().sprite = battleeneemy2.image;
            denemy1.GetComponent<SpriteRenderer>().sortingOrder = 2;


            //--------------------------------------------------------------------------------------------



            BaseEnemy battleeneemy3;
            battleeneemy3 = GetRandomEnemyFromList(GetEnemyByRarity(rarity));

            Debug.Log(battleeneemy3.name);


            GameObject denemy5 = Instantiate(emptymonster, Enemypodium5.transform.position, Quaternion.identity) as GameObject;
            HealthBar bar5 = Instantiate(filledhealth, Enemypodium5.transform.position, Quaternion.identity) as HealthBar;
            bar5.transform.parent = battle.transform;
            bar5.transform.localScale = new Vector3(1f, 1f, 0f);
            bar5.transform.Translate(0, -.3f, 0);

            bar5.AddMember(filledhealth);
            ehealthicon[4] = bar5;
            HealthBar health5 = bar5;
            enemyhealth[4] = health5;
            denemy5.transform.Translate(0, .6f, 0);
            denemy5.transform.parent = Enemypodium5;
            //Debug.Log(deneemy.name);
            BaseEnemy tempen3 = denemy5.AddComponent<BaseEnemy>() as BaseEnemy;
            tempen3.AddMember(battleeneemy3);

            denemy5.GetComponent<SpriteRenderer>().sprite = battleeneemy3.image;
            denemy5.GetComponent<SpriteRenderer>().sortingOrder = 2;


            //--------------------------------------------------------------------------------------------------------


            BaseEnemy battleeneemy4;
            battleeneemy4 = GetRandomEnemyFromList(GetEnemyByRarity(rarity));

            Debug.Log(battleeneemy4.name);


            GameObject denemy2 = Instantiate(emptymonster, Enemypodium2.transform.position, Quaternion.identity) as GameObject;
            HealthBar bar2 = Instantiate(filledhealth, Enemypodium2.transform.position, Quaternion.identity) as HealthBar;
            bar2.transform.parent = battle.transform;
            bar2.transform.localScale = new Vector3(1f, 1f, 0f);
            bar2.transform.Translate(0, -.3f, 0);

            bar2.AddMember(filledhealth);
            ehealthicon[1] = bar2;
            HealthBar health2 = bar2;
            enemyhealth[1] = health2;
            denemy2.transform.Translate(0, .6f, 0);
            denemy2.transform.parent = Enemypodium2;
            //Debug.Log(deneemy.name);
            BaseEnemy tempen4 = denemy2.AddComponent<BaseEnemy>() as BaseEnemy;
            tempen4.AddMember(battleeneemy4);

            denemy2.GetComponent<SpriteRenderer>().sprite = battleeneemy4.image;
            denemy2.GetComponent<SpriteRenderer>().sortingOrder = 2;
            
            
            inbattle[0] = tempen2;
            inbattle[1] = tempen4;
            inbattle[2] = tempen;
            inbattle[4] = tempen3;
            enemyhealth[0].SetMaxHealth(inbattle[0].HP);
            enemyhealth[2].SetMaxHealth(inbattle[2].HP);
            enemyhealth[4].SetMaxHealth(inbattle[4].HP);
            enemyhealth[1].SetMaxHealth(inbattle[1].HP);
            
        }
        else if(numEnemies == 5)
        {
            BaseEnemy battleeneemy2;
            battleeneemy2 = GetRandomEnemyFromList(GetEnemyByRarity(rarity));

            Debug.Log(battleeneemy2.name);


            GameObject denemy1 = Instantiate(emptymonster, Enemypodium1.transform.position, Quaternion.identity) as GameObject;
            HealthBar bar1 = Instantiate(filledhealth, Enemypodium1.transform.position, Quaternion.identity) as HealthBar;
            bar1.transform.parent = battle.transform;
            bar1.transform.localScale = new Vector3(1f, 1f, 0f);
            bar1.transform.Translate(0, -.3f, 0);

            bar1.AddMember(filledhealth);
            ehealthicon[0] = bar1;
            HealthBar health1 = bar1;
            enemyhealth[0] = health1;
            denemy1.transform.Translate(0, .6f, 0);
            denemy1.transform.parent = Enemypodium1;

            //Debug.Log(deneemy.name);
            BaseEnemy tempen2 = denemy1.AddComponent<BaseEnemy>() as BaseEnemy;
            tempen2.AddMember(battleeneemy2);

            denemy1.GetComponent<SpriteRenderer>().sprite = battleeneemy2.image;
            denemy1.GetComponent<SpriteRenderer>().sortingOrder = 2;


            //--------------------------------------------------------------------------------------------



            BaseEnemy battleeneemy3;
            battleeneemy3 = GetRandomEnemyFromList(GetEnemyByRarity(rarity));

            Debug.Log(battleeneemy3.name);


            GameObject denemy5 = Instantiate(emptymonster, Enemypodium5.transform.position, Quaternion.identity) as GameObject;
            HealthBar bar5 = Instantiate(filledhealth, Enemypodium5.transform.position, Quaternion.identity) as HealthBar;
            bar5.transform.parent = battle.transform;
            bar5.transform.localScale = new Vector3(1f, 1f, 0f);
            bar5.transform.Translate(0, -.3f, 0);

            bar5.AddMember(filledhealth);
            ehealthicon[4] = bar5;
            HealthBar health5 = bar5;
            enemyhealth[4] = health5;
            denemy5.transform.Translate(0, .6f, 0);
            denemy5.transform.parent = Enemypodium5;
            //Debug.Log(deneemy.name);
            BaseEnemy tempen3 = denemy5.AddComponent<BaseEnemy>() as BaseEnemy;
            tempen3.AddMember(battleeneemy3);

            denemy5.GetComponent<SpriteRenderer>().sprite = battleeneemy3.image;
            denemy5.GetComponent<SpriteRenderer>().sortingOrder = 2;


            //--------------------------------------------------------------------------------------------------------


            BaseEnemy battleeneemy4;
            battleeneemy4 = GetRandomEnemyFromList(GetEnemyByRarity(rarity));

            Debug.Log(battleeneemy4.name);


            GameObject denemy2 = Instantiate(emptymonster, Enemypodium2.transform.position, Quaternion.identity) as GameObject;
            HealthBar bar2 = Instantiate(filledhealth, Enemypodium2.transform.position, Quaternion.identity) as HealthBar;
            bar2.transform.parent = battle.transform;
            bar2.transform.localScale = new Vector3(1f, 1f, 0f);
            bar2.transform.Translate(0, -.3f, 0);

            bar2.AddMember(filledhealth);
            ehealthicon[1] = bar2;
            HealthBar health2 = bar2;
            enemyhealth[1] = health2;
            denemy2.transform.Translate(0, .6f, 0);
            denemy2.transform.parent = Enemypodium2;
            //Debug.Log(deneemy.name);
            BaseEnemy tempen4 = denemy2.AddComponent<BaseEnemy>() as BaseEnemy;
            tempen4.AddMember(battleeneemy4);

            denemy2.GetComponent<SpriteRenderer>().sprite = battleeneemy4.image;
            denemy2.GetComponent<SpriteRenderer>().sortingOrder = 2;


            //------------------------------------------------------------------------------------------


            BaseEnemy battleeneemy5;
            battleeneemy5 = GetRandomEnemyFromList(GetEnemyByRarity(rarity));

            Debug.Log(battleeneemy5.name);


            GameObject denemy4 = Instantiate(emptymonster, Enemypodium4.transform.position, Quaternion.identity) as GameObject;
            HealthBar bar4 = Instantiate(filledhealth, Enemypodium4.transform.position, Quaternion.identity) as HealthBar;
            bar4.transform.parent = battle.transform;
            bar4.transform.localScale = new Vector3(1f, 1f, 0f);
            bar4.transform.Translate(0, -.3f, 0);

            bar4.AddMember(filledhealth);
            ehealthicon[3] = bar4;
            HealthBar health4 = bar4;
            enemyhealth[3] = health4;
            denemy4.transform.Translate(0, .6f, 0);
            denemy4.transform.parent = Enemypodium4;
            //Debug.Log(deneemy.name);
            BaseEnemy tempen5 = denemy4.AddComponent<BaseEnemy>() as BaseEnemy;
            tempen5.AddMember(battleeneemy5);

            denemy4.GetComponent<SpriteRenderer>().sprite = battleeneemy5.image;
            denemy4.GetComponent<SpriteRenderer>().sortingOrder = 2;


            //populate the array
            inbattle[0] = tempen2;
            inbattle[1] = tempen4;
            inbattle[2] = tempen;
            inbattle[3] = tempen5;
            inbattle[4] = tempen3;
            enemyhealth[0].SetMaxHealth(inbattle[0].HP);
            enemyhealth[2].SetMaxHealth(inbattle[2].HP);
            enemyhealth[4].SetMaxHealth(inbattle[4].HP);
            enemyhealth[1].SetMaxHealth(inbattle[1].HP);
            enemyhealth[3].SetMaxHealth(inbattle[3].HP);
        }



        /* inbattle[1] = denemy1;
         inbattle.Add(denemy)*/
        int defen = inbattle[2].unitstat.DefenseStat;
        Debug.Log(inbattle[2]);
        StartCoroutine(bm.StartScreen());
       
        //bm.ChangeMenu(BattleMenu.Selection);
       
    }
    public List<BaseEnemy> GetEnemyByRarity(Rarity rarity)
    {
       
        List<BaseEnemy> returnEnemy = new List<BaseEnemy>();
        

        foreach (BaseEnemy enemy in allEnemies)
        {
            if (enemy.rarity == rarity)
                returnEnemy.Add(enemy);
            Debug.Log(returnEnemy[0]);
        }
        return returnEnemy;
    }

    public BaseEnemy GetRandomEnemyFromList(List<BaseEnemy> enemyList)
    {
        /*Debug.Log(enemyList.Count);
        Debug.Log("Before base enemy");
        Debug.Log("after base enemy");*/
        //Debug.Log(enemyList.Count);
        int monsterIndex = Random.Range(0, enemyList.Count);
       //Debug.Log(monsterIndex);
       GameObject obj = new GameObject();
         BaseEnemy monster = obj.AddComponent<BaseEnemy>();
        //BaseEnemy monster = new BaseEnemy();
        Destroy(obj);
        monster = enemyList[monsterIndex];
        return monster;
    }
 }

[System.Serializable]
public class Moves
{
    string Name;
    public MoveType category;
    public int ManaCost;
    public float power;
    public string movesummary;
    public attribute element;
    public int unlockedAt;
    //public float accuracy;
    //public Stat moveStat;
    //public MoveType moveType;

}
[System.Serializable]
public class Stat
{
    public float minimum;
    public float maximum;
}
public enum MoveType
{
    physical,special,status
}
