using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public BattleMenu currentMenu;
    public GameManager gm;
    public int deadEnemies;
    public EncounterState state;
    public int[] Turn = new int[9] {-10,-10, -10, -10, -10, -10, -10, -10, -10};

    [Header("Selection")]
    public GameObject SelectionMenu;
    public GameObject selectioninfo;
    public Text selectionInfotext;
    public Text Attack;
    private string AttackT;
    public Text Run;
    private string runT;
    public Text Items;
    private string ItemsT;
    public Text Skills;
    private string SkillsT;
    public ACTION action;

    [Space(10)]
    [Header("Skills")]
    public GameObject skillsMenu;
    public GameObject skills2Menu;
    public GameObject skillsDetails;
    public Text Summary;

    public Text Manacost;
    public Text skillType;
    public Text power;
    public Text Skill1;
    private string Skill1T;
    public Text Skill2;
    private string Skill2T;
    public Text Skill3; 
    private string Skill3T;
    public Text Next;
    private string NextT;
    public Text Skill4;
    private string Skill4T;
    public Text Skill5;
    private string Skill5T;
    public Text Skill6;
    private string Skill6T;
    public Text Skill7;
    private string Skill7T;
    public int turnindex;
    


    [Header("EnemySelection")]
    public GameObject EBB1;
    public GameObject EBBF1;
    public GameObject EBB2;
    public GameObject EBBF2;
    public GameObject EBB3;
    public GameObject EBBF3;
    public GameObject EBB4;
    public GameObject EBBF4;
    public GameObject EBB5;
    public GameObject EBBF5;


    [Header("Info")]
    public GameObject infoMenu;
    public Text infoText;
    private string infoTextT;

    [Header("Misc")]
    public int currentSelection;

    public void ChangeMenu(BattleMenu m)
    {

        currentMenu = m;
        currentSelection = 0;
        switch (m)
        {
            case BattleMenu.Selection:
                SelectionMenu.gameObject.SetActive(true);
                selectioninfo.gameObject.SetActive(true);
                skillsMenu.gameObject.SetActive(false);
                skills2Menu.gameObject.SetActive(false);
                skillsDetails.gameObject.SetActive(false);
                infoMenu.gameObject.SetActive(false);

                EBB1.gameObject.SetActive(false);
                EBBF1.gameObject.SetActive(false);
                EBB2.gameObject.SetActive(false);
                EBBF2.gameObject.SetActive(false);
                EBB3.gameObject.SetActive(false);
                EBBF3.gameObject.SetActive(false);
                EBB4.gameObject.SetActive(false);
                EBBF4.gameObject.SetActive(false);
                EBB5.gameObject.SetActive(false);
                EBBF5.gameObject.SetActive(false);
                break;

            case BattleMenu.Skills:
                SelectionMenu.gameObject.SetActive(false);
                selectioninfo.gameObject.SetActive(false);
                skillsMenu.gameObject.SetActive(true);
                skills2Menu.gameObject.SetActive(false);
                skillsDetails.gameObject.SetActive(true);
                infoMenu.gameObject.SetActive(false);

                EBB1.gameObject.SetActive(false);
                EBBF1.gameObject.SetActive(false);
                EBB2.gameObject.SetActive(false);
                EBBF2.gameObject.SetActive(false);
                EBB3.gameObject.SetActive(false);
                EBBF3.gameObject.SetActive(false);
                EBB4.gameObject.SetActive(false);
                EBBF4.gameObject.SetActive(false);
                EBB5.gameObject.SetActive(false);
                EBBF5.gameObject.SetActive(false);
                break;

            case BattleMenu.Info:
                SelectionMenu.gameObject.SetActive(false);
                selectioninfo.gameObject.SetActive(false);
                skillsMenu.gameObject.SetActive(false);
                skills2Menu.gameObject.SetActive(false);
                skillsDetails.gameObject.SetActive(false);
                infoMenu.gameObject.SetActive(true);

                EBB1.gameObject.SetActive(false);
                EBBF1.gameObject.SetActive(false);
                EBB2.gameObject.SetActive(false);
                EBBF2.gameObject.SetActive(false);
                EBB3.gameObject.SetActive(false);
                EBBF3.gameObject.SetActive(false);
                EBB4.gameObject.SetActive(false);
                EBBF4.gameObject.SetActive(false);
                EBB5.gameObject.SetActive(false);
                EBBF5.gameObject.SetActive(false);
                break;
            case BattleMenu.Skills2:
                SelectionMenu.gameObject.SetActive(false);
                selectioninfo.gameObject.SetActive(false);
                skillsMenu.gameObject.SetActive(false);
                skills2Menu.gameObject.SetActive(true);
                skillsDetails.gameObject.SetActive(true);
                infoMenu.gameObject.SetActive(false);

                EBB1.gameObject.SetActive(false);
                EBBF1.gameObject.SetActive(false);
                EBB2.gameObject.SetActive(false);
                EBBF2.gameObject.SetActive(false);
                EBB3.gameObject.SetActive(false);
                EBBF3.gameObject.SetActive(false);
                EBB4.gameObject.SetActive(false);
                EBBF4.gameObject.SetActive(false);
                EBB5.gameObject.SetActive(false);
                EBBF5.gameObject.SetActive(false);
                break;
            case BattleMenu.EnemySelection:
                SelectionMenu.gameObject.SetActive(false);
                selectioninfo.gameObject.SetActive(false);
                skillsMenu.gameObject.SetActive(false);
                skills2Menu.gameObject.SetActive(false);
                skillsDetails.gameObject.SetActive(false);
                infoMenu.gameObject.SetActive(true);

                EBB1.gameObject.SetActive(false);
                EBBF1.gameObject.SetActive(false);
                EBB2.gameObject.SetActive(false);
                EBBF2.gameObject.SetActive(false);
                EBB3.gameObject.SetActive(false);
                EBBF3.gameObject.SetActive(false);
                EBB4.gameObject.SetActive(false);
                EBBF4.gameObject.SetActive(false);
                EBB5.gameObject.SetActive(false);
                EBBF5.gameObject.SetActive(false);
                break;
            case BattleMenu.Victory:
                SelectionMenu.gameObject.SetActive(false);
                selectioninfo.gameObject.SetActive(false);
                skillsMenu.gameObject.SetActive(false);
                skills2Menu.gameObject.SetActive(false);
                skillsDetails.gameObject.SetActive(false);
                infoMenu.gameObject.SetActive(true);

                EBB1.gameObject.SetActive(false);
                EBBF1.gameObject.SetActive(false);
                EBB2.gameObject.SetActive(false);
                EBBF2.gameObject.SetActive(false);
                EBB3.gameObject.SetActive(false);
                EBBF3.gameObject.SetActive(false);
                EBB4.gameObject.SetActive(false);
                EBBF4.gameObject.SetActive(false);
                EBB5.gameObject.SetActive(false);
                EBBF5.gameObject.SetActive(false);
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AttackT = Attack.text;
        ItemsT = Items.text;
        SkillsT = Skills.text;
        runT = Run.text;
        Skill1T = Skill1.text;
        Skill2T = Skill2.text;
        Skill3T = Skill3.text;
        NextT = Next.text;
        Skill4T = Skill4.text;
        Skill5T = Skill5.text;
        Skill6T = Skill6.text;
        Skill7T = Skill7.text;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentMenu == BattleMenu.EnemySelection)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (currentSelection < 5)
                {
                    currentSelection++;
                }

            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (currentSelection > 1)
                {
                    currentSelection--;
                }

            }
            if (currentSelection == 0)
            {
                currentSelection = 1;
            }
        }
        else { 
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentSelection == 1 || currentSelection == 2)
            {
                currentSelection++;
                currentSelection++;
            }

        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentSelection == 3 || currentSelection == 4)
            {
                currentSelection--;
                currentSelection--;
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentSelection == 2 || currentSelection == 4)
            {
                currentSelection--;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentSelection == 1 || currentSelection == 3)
            {
                currentSelection++;
            }
        }
        if (currentSelection == 0)
        {
            currentSelection = 1;
        }
    }
        if (Input.GetKeyDown("return"))
        {
            if (currentMenu == BattleMenu.Selection)
            {
                switch (currentSelection)
                {
                    case 1:
                        action = ACTION.Attack;
                        ChangeMenu(BattleMenu.EnemySelection);
                        break;
                    case 2:
                        
                        ChangeMenu(BattleMenu.Skills);
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                }
            }
            if (currentMenu == BattleMenu.Skills)
            {
                switch (currentSelection) 
                { 
                case 1:
                        ChangeMenu(BattleMenu.EnemySelection);
                        break;
                case 2:
                        ChangeMenu(BattleMenu.EnemySelection);

                        break;
                  case 3:
                        ChangeMenu(BattleMenu.EnemySelection);
                        break;
                case 4:
                    ChangeMenu(BattleMenu.Skills2);
                 break;
                }
            }
            if (currentMenu == BattleMenu.Skills2)
            {
                switch (currentSelection)
                {
                    case 1:
                        ChangeMenu(BattleMenu.EnemySelection);
                        break;
                    case 2:
                        ChangeMenu(BattleMenu.EnemySelection);
                        break;
                    case 3:
                        ChangeMenu(BattleMenu.EnemySelection);
                        break;
                    case 4:
                        ChangeMenu(BattleMenu.EnemySelection);
                        break;
                }
            }
            if(currentMenu == BattleMenu.EnemySelection)
            {
                switch (currentSelection)
                {
                    case 1:
                        if (gm.inbattle[0] != null && action == ACTION.Attack)
                        {
                            ChangeMenu(BattleMenu.Info);
                            StartCoroutine(DisplayText("Enemy 1 is being attacked", 1));
                            int damage = gm.inbattle[0].TakeDamage(gm.inbattle[0], gm.ALLIES[turnindex].stats.AttackStat, attribute.None, gm.ALLIES[turnindex].stats);
                            gm.enemyhealth[0].SetHealth(gm.inbattle[0].HP);
                            Debug.Log(damage);
                            Debug.Log(gm.inbattle[0].HP);
                            if(gm.inbattle[0].HP == 0)
                            {
                                deadEnemies++;
                                gm.inbattle[0] = null;
                                Turn[4] = -10;
                                if (gm.Enemypodium1.transform.GetChild(0) != null)
                                {

                                    foreach (Transform child in gm.Enemypodium1.transform)
                                        Destroy(child.gameObject);
                                }
                                gm.ehealthicon[0].Destruction();
                                gm.enemyhealth[0].Destruction();

                            }
                            checkend();
                            StartCoroutine(NextTurn());
                        }
                        break;
                    case 2:
                        if (gm.inbattle[1] != null)
                        {

                        }
                        break;
                    case 3:
                        if (gm.inbattle[2] != null && action == ACTION.Attack)
                        {
                            ChangeMenu(BattleMenu.Info);
                            StartCoroutine(DisplayText("Enemy 3 is being attacked", 1));
                            int damage = gm.inbattle[2].TakeDamage(gm.inbattle[2], gm.ALLIES[turnindex].stats.AttackStat, attribute.None, gm.ALLIES[turnindex].stats);
                            gm.enemyhealth[2].SetHealth(gm.inbattle[2].HP);
                           //gm.ehealthicon[2].SetHealth(gm.inbattle[2].HP);
                            Debug.Log(damage);
                            Debug.Log(gm.inbattle[2].HP);
                            if (gm.inbattle[2].HP == 0)
                            {
                                deadEnemies++;
                                gm.inbattle[2] = null;
                                Turn[6] = -10;
                                if (gm.Enemypodium3.GetChild(0) != null)
                                {
                                    Debug.Log(gm.Enemypodium3.GetChild(0));
                                    foreach (Transform child in gm.Enemypodium3.transform)
                                        Destroy(child.gameObject);
                                }
                                gm.ehealthicon[2].Destruction();
                                gm.enemyhealth[2].Destruction();
                               

                            }
                            checkend();
                            StartCoroutine(NextTurn());
                        }
                        break;
                    case 4:
                        if (gm.inbattle[3] != null)
                        {

                        }
                        break;
                    case 5:
                        if (gm.inbattle[4] != null)
                        {

                        }
                        break;
                }
               
            }

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentMenu == BattleMenu.Skills)
            {
                ChangeMenu(BattleMenu.Selection);
            }
            if (currentMenu == BattleMenu.Skills2)
            {
                ChangeMenu(BattleMenu.Skills);
            }
            if(currentMenu == BattleMenu.EnemySelection)
            {
                ChangeMenu(BattleMenu.Selection);
            }
        }

     

        switch (currentMenu)
        {
            case BattleMenu.Skills:
                action = ACTION.Skill;
                switch (currentSelection)
                {
                    case 1:
                        Skill1.text = "⇒" + Skill1T;
                        Skill2.text = Skill2T;
                        Skill3.text = Skill3T;
                        Next.text = NextT;
                        break;
                    case 2:
                        Skill1.text = Skill1T;
                        Skill2.text = "⇒" +Skill2T;
                        Skill3.text = Skill3T;
                        Next.text = NextT;
                        break;
                    case 3:
                        Skill1.text = Skill1T;
                        Skill2.text = Skill2T;
                        Skill3.text = "⇒" +Skill3T;
                        Next.text = NextT;
                        break;
                    case 4:
                        Skill1.text = Skill1T;
                        Skill2.text = Skill2T;
                        Skill3.text = Skill3T;
                        Next.text = "⇒" + NextT;
                        break;
                }
                break;
            case BattleMenu.Skills2:

                action = ACTION.Skill;
                switch (currentSelection)
                {
                    case 1:
                        Skill4.text = "⇒" + Skill4T;
                        Skill5.text = Skill5T;
                        Skill6.text = Skill6T;
                        Skill7.text = Skill7T;
                        break;
                    case 2:
                        Skill4.text = Skill4T;
                        Skill5.text = "⇒" + Skill5T;
                        Skill6.text = Skill6T;
                        Skill7.text = Skill7T;
                        break;
                    case 3:
                        Skill4.text = Skill4T;
                        Skill5.text = Skill5T;
                        Skill6.text = "⇒" + Skill6T;
                        Skill7.text = Skill7T;
                        break;
                    case 4:
                        Skill4.text = Skill4T;
                        Skill5.text = Skill5T;
                        Skill6.text = Skill6T;
                        Skill7.text = "⇒" + Skill7T;
                        break;
                }

                break;
            case BattleMenu.Selection:
                action = ACTION.None;
                switch (currentSelection)
                {
                    case 1:
                        Attack.text = "⇒" + AttackT;
                        Skills.text = SkillsT;
                        Items.text = ItemsT;
                        Run.text = runT;
                        break;
                    case 2:
                        Attack.text =  AttackT;
                        Skills.text = "⇒" + SkillsT;
                        Items.text = ItemsT;
                        Run.text = runT;
                        break;
                    case 3:
                        Attack.text = AttackT;
                        Skills.text = SkillsT;
                        Items.text =  "⇒" +ItemsT;
                        Run.text = runT;
                        break;
                    case 4:
                        Attack.text = AttackT;
                        Skills.text = SkillsT;
                        Items.text = ItemsT;
                        Run.text = "⇒" + runT;
                        break;

                     
                }
                break;
            case BattleMenu.EnemySelection:
                infoText.text = "Who Do You Want To Select? :";
                switch (currentSelection)
                {
                    case 1:
                        EBB1.gameObject.SetActive(true);
                        EBBF1.gameObject.SetActive(true);
                        EBB2.gameObject.SetActive(false);
                        EBBF2.gameObject.SetActive(false);
                        EBB3.gameObject.SetActive(false);
                        EBBF3.gameObject.SetActive(false);
                        EBB4.gameObject.SetActive(false);
                        EBBF4.gameObject.SetActive(false);
                        EBB5.gameObject.SetActive(false);
                        EBBF5.gameObject.SetActive(false);
                        break;
                    case 2:
                        EBB1.gameObject.SetActive(false);
                        EBBF1.gameObject.SetActive(false);
                        EBB2.gameObject.SetActive(true);
                        EBBF2.gameObject.SetActive(true);
                        EBB3.gameObject.SetActive(false);
                        EBBF3.gameObject.SetActive(false);
                        EBB4.gameObject.SetActive(false);
                        EBBF4.gameObject.SetActive(false);
                        EBB5.gameObject.SetActive(false);
                        EBBF5.gameObject.SetActive(false);
                        break;
                    case 3:
                        EBB1.gameObject.SetActive(false);
                        EBBF1.gameObject.SetActive(false);
                        EBB2.gameObject.SetActive(false);
                        EBBF2.gameObject.SetActive(false);
                        EBB3.gameObject.SetActive(true);
                        EBBF3.gameObject.SetActive(true);
                        EBB4.gameObject.SetActive(false);
                        EBBF4.gameObject.SetActive(false);
                        EBB5.gameObject.SetActive(false);
                        EBBF5.gameObject.SetActive(false);
                        break;
                    case 4:
                        EBB1.gameObject.SetActive(false);
                        EBBF1.gameObject.SetActive(false);
                        EBB2.gameObject.SetActive(false);
                        EBBF2.gameObject.SetActive(false);
                        EBB3.gameObject.SetActive(false);
                        EBBF3.gameObject.SetActive(false);
                        EBB4.gameObject.SetActive(true);
                        EBBF4.gameObject.SetActive(true);
                        EBB5.gameObject.SetActive(false);
                        EBBF5.gameObject.SetActive(false);
                        break;
                    case 5:
                        EBB1.gameObject.SetActive(false);
                        EBBF1.gameObject.SetActive(false);
                        EBB2.gameObject.SetActive(false);
                        EBBF2.gameObject.SetActive(false);
                        EBB3.gameObject.SetActive(false);
                        EBBF3.gameObject.SetActive(false);
                        EBB4.gameObject.SetActive(false);
                        EBBF4.gameObject.SetActive(false);
                        EBB5.gameObject.SetActive(true);
                        EBBF5.gameObject.SetActive(true);
                        break;
                }
            
                break;
            case BattleMenu.Victory:
                StartCoroutine(DisplayText("WELL SLAP ME WITH A ROOSTER AND BIRTH MY UNBORN CHILD YOU'VE DONE IT!!!!", 3));
                break;
            case BattleMenu.Start:
                StartCoroutine(DisplayText("An Enemy Approaches You...", 3));
                break;
            case BattleMenu.EnemyTurn:
              //  StartCoroutine(DisplayText("Its the Enemies turn!", 2));

                break;
        }
       
    }

    public void checkend()
    {
        if (gm.numEnemies == deadEnemies)
        {
            //apply Experience

            //end the battle
            deadEnemies = 0;
            ChangeMenu(BattleMenu.Victory);
            
            StartCoroutine(victoryscreen());
            gm.player.GetComponent<playermovement>().isAllowedToMove = true;
            SelectionMenu.gameObject.SetActive(false);
            selectioninfo.gameObject.SetActive(false);
            skillsMenu.gameObject.SetActive(false);
            skills2Menu.gameObject.SetActive(false);
            skillsDetails.gameObject.SetActive(false);
            
            EBB1.gameObject.SetActive(false);
            EBBF1.gameObject.SetActive(false);
            EBB2.gameObject.SetActive(false);
            EBBF2.gameObject.SetActive(false);
            EBB3.gameObject.SetActive(false);
            EBBF3.gameObject.SetActive(false);
            EBB4.gameObject.SetActive(false);
            EBBF4.gameObject.SetActive(false);
            EBB5.gameObject.SetActive(false);
            EBBF5.gameObject.SetActive(false);


           
            if (gm.Enemypodium2.transform.GetChild(0) != null)
            {
                Destroy(gm.Enemypodium3.GetChild(0));
            }
            
            if (gm.Enemypodium4.transform.GetChild(0) != null)
            {
                Destroy(gm.Enemypodium4.GetChild(0));
            }
            if (gm.Enemypodium5.transform.GetChild(0) != null)
            {
                Destroy(gm.Enemypodium5.GetChild(0));
            }


        }
    }
    public IEnumerator victoryscreen()
    {
        gm.playerhealth[0].Destruction();
        //infoMenu.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(3f);
        foreach (Transform child in gm.HeroPodium1.transform)
            Destroy(child.gameObject);
        infoMenu.gameObject.SetActive(false);
        gm.playerCamera.SetActive(true);
        gm.battleCamera.SetActive(false);
    }
    public IEnumerator StartScreen()
    {
        ChangeMenu(BattleMenu.Start);
        
        SelectionMenu.gameObject.SetActive(false);
        selectioninfo.gameObject.SetActive(false);
        skillsMenu.gameObject.SetActive(false);
        skills2Menu.gameObject.SetActive(false);
        skillsDetails.gameObject.SetActive(false);
        infoMenu.gameObject.SetActive(true);

        EBB1.gameObject.SetActive(false);
        EBBF1.gameObject.SetActive(false);
        EBB2.gameObject.SetActive(false);
        EBBF2.gameObject.SetActive(false);
        EBB3.gameObject.SetActive(false);
        EBBF3.gameObject.SetActive(false);
        EBB4.gameObject.SetActive(false);
        EBBF4.gameObject.SetActive(false);
        EBB5.gameObject.SetActive(false);
        EBBF5.gameObject.SetActive(false);
        
        
        Debug.Log("Immediately before setup turn");
        SetupTurn();
        
        Debug.Log("immediately after setup turn");
        
        yield return new WaitForSeconds(3f);
        infoMenu.gameObject.SetActive(false);
        Debug.Log(Turn[0]);
        Debug.Log(Turn[1]);
        Debug.Log(Turn[2]);
        Debug.Log(Turn[3]);
        Debug.Log(Turn[4]);
        Debug.Log(Turn[5]);
        Debug.Log(Turn[6]);
        Debug.Log(Turn[7]);
        Debug.Log(Turn[8]);
        StartCoroutine(NextTurn());
        Debug.Log("End of start screen Coroutine");
       // ChangeMenu(BattleMenu.Selection);
    }
    public void SetupTurn()
    {
        int numchar = 0;
        foreach(BaseAlly ally in gm.ALLIES){
            if(ally != null)
            {
                numchar++;
            }
        }
        switch (numchar) {
            case 1:
                Turn[0] = (int)Mathf.Floor(gm.ALLIES[0].stats.SpeedStat / 3);
                while(checkopen(Turn[0],0) != true)
                {
                    Turn[0]--;
                }
                
                break;
            case 2:
                Turn[1] = (int)Mathf.Floor(gm.ALLIES[1].stats.SpeedStat / 3);
                while (checkopen(Turn[1],1) != true)
                {
                    Turn[1]--;
                }

                break;
            case 3:
                Turn[2] = (int)Mathf.Floor(gm.ALLIES[2].stats.SpeedStat / 3);
                while (checkopen(Turn[2],2) != true)
                {
                    Turn[2]--;
                }
                break;
            case 4:
                Turn[3] = (int)Mathf.Floor(gm.ALLIES[3].stats.SpeedStat / 3);
                while (checkopen(Turn[3],3) != true)
                {
                    Turn[3]--;
                }
                break;

        }
        switch (gm.numEnemies)
        {
            case 1:
            
                Turn[6] = (int)Mathf.Floor(gm.inbattle[2].unitstat.SpeedStat / 3);
                while (checkopen(Turn[6],6) != true)
                {
                    Turn[6]--;
                }
                
                break;
            case 2:
                Turn[6] = (int)Mathf.Floor(gm.inbattle[2].unitstat.SpeedStat / 3);
                while (checkopen(Turn[6],6) != true)
                {
                    Turn[6]--;
                }

                
                Turn[4] = (int)Mathf.Floor(gm.inbattle[0].unitstat.SpeedStat / 3);
                while (checkopen(Turn[4],4) != true)
                {
                    Turn[4]--;
                }

                break;
            case 3:
                Turn[6] = (int)Mathf.Floor(gm.inbattle[2].unitstat.SpeedStat / 3);
                while (checkopen(Turn[6],6) != true)
                {
                    Turn[6]--;
                }

               
                Turn[4] = (int)Mathf.Floor(gm.inbattle[0].unitstat.SpeedStat / 3);
                while (checkopen(Turn[4],4) != true)
                {
                    Turn[4]--;
                }

                
                Turn[8] = (int)Mathf.Floor(gm.inbattle[4].unitstat.SpeedStat / 3);
                while (checkopen(Turn[8],8) != true)
                {
                    Turn[8]--;
                }

                break;
            case 4:
                Turn[6] = (int)Mathf.Floor(gm.inbattle[2].unitstat.SpeedStat / 3);
                while (checkopen(Turn[6],6) != true)
                {
                    Turn[6]--;
                }

               
                Turn[4] = (int)Mathf.Floor(gm.inbattle[0].unitstat.SpeedStat / 3);
                while (checkopen(Turn[4],4) != true)
                {
                    Turn[4]--;
                }

                
                Turn[8] = (int)Mathf.Floor(gm.inbattle[4].unitstat.SpeedStat / 3);
                while (checkopen(Turn[8],8) != true)
                {
                    Turn[8]--;
                }

                
                Turn[5] = (int)Mathf.Floor(gm.inbattle[1].unitstat.SpeedStat / 3);
                while (checkopen(Turn[5],5) != true)
                {
                    Turn[5]--;
                }

                break;
            case 5:
                Turn[6] = (int)Mathf.Floor(gm.inbattle[2].unitstat.SpeedStat / 3);
                while (checkopen(Turn[6],6) != true)
                {
                    Turn[6]--;
                }

                
                Turn[4] = (int)Mathf.Floor(gm.inbattle[0].unitstat.SpeedStat / 3);
                while (checkopen(Turn[4],4) != true)
                {
                    Turn[4]--;
                }

               
                Turn[8] = (int)Mathf.Floor(gm.inbattle[4].unitstat.SpeedStat / 3);
                while (checkopen(Turn[8],8) != true)
                {
                    Turn[8]--;
                }

               
                Turn[5] = (int)Mathf.Floor(gm.inbattle[1].unitstat.SpeedStat / 3);
                while (checkopen(Turn[5],5) != true)
                {
                    Turn[5]--;
                }

                
                Turn[7] = (int)Mathf.Floor(gm.inbattle[3].unitstat.SpeedStat / 3);
                while (checkopen(Turn[7],7) != true)
                {
                    Turn[7]--;
                }

                break;
        }
        return;
        
    }
    public IEnumerator NextTurn()
    {
        StartCoroutine(DisplayText("Next Turn is being Decided",1));
        
        int index = -1;
        bool decided = false;
        yield return new WaitForSeconds(0);
        while (decided == false)
        {
            for (int i = 0; i < 9; i++)
            {
                if (Turn[i] != -10)
                {
                    Turn[i]++;
                    if (Turn[i] >= 35)
                    {
                        decided = true;
                        index = i;
                        break;




                    }
                }
            }
            if (decided == true)
            {
            break;
            }
        }
        
        Debug.Log("turn has been decided; index: ");
        Debug.Log(index);
        turnindex = index;
        if (index < 4)
        {
            StartCoroutine(DisplayText("Character " + index + "s Turn!", 2));
            
            Turn[turnindex] = (int)Mathf.Floor(gm.ALLIES[turnindex].stats.SpeedStat/3);
            while (checkopen(Turn[turnindex], turnindex) != true)
            {
                Turn[turnindex]--;
            }
            ChangeMenu(BattleMenu.Selection);
            yield return new WaitForSeconds(0);
        }
        else
        {
            
            StartCoroutine(DisplayText("Enemy " + (index -3) + "s Turn!", 2));
            Turn[turnindex] = (int)Mathf.Floor(gm.inbattle[turnindex-4].unitstat.SpeedStat / 3);
            while (checkopen(Turn[turnindex], turnindex) != true)
            {
                Turn[turnindex]--;
            }
            SelectionMenu.gameObject.SetActive(false);
            selectioninfo.gameObject.SetActive(false);
            skillsMenu.gameObject.SetActive(false);
            skills2Menu.gameObject.SetActive(false);
            skillsDetails.gameObject.SetActive(false);
            infoMenu.gameObject.SetActive(true);

            EBB1.gameObject.SetActive(false);
            EBBF1.gameObject.SetActive(false);
            EBB2.gameObject.SetActive(false);
            EBBF2.gameObject.SetActive(false);
            EBB3.gameObject.SetActive(false);
            EBBF3.gameObject.SetActive(false);
            EBB4.gameObject.SetActive(false);
            EBBF4.gameObject.SetActive(false);
            EBB5.gameObject.SetActive(false);
            EBBF5.gameObject.SetActive(false);
            BaseEnemy enemy;
            switch (index)
            {
                case 4:
                    enemy = gm.inbattle[0];
                    infoText.text = enemy.EnemyName + "'s Turn!";
                    yield return new WaitForSeconds(2f);
                    ChangeMenu(BattleMenu.EnemyTurn);
                    StartCoroutine(EnemyTurn(index));
                    break;
                case 5:
                    enemy = gm.inbattle[1];
                    infoText.text = enemy.EnemyName + "'s Turn!";
                    yield return new WaitForSeconds(2f);
                    ChangeMenu(BattleMenu.EnemyTurn);
                    StartCoroutine(EnemyTurn(index));
                    break;

                case 6:
                    enemy = gm.inbattle[2];
                    infoText.text = enemy.EnemyName + "'s Turn!";
                    yield return new WaitForSeconds(2f);
                    ChangeMenu(BattleMenu.EnemyTurn);
                    StartCoroutine(EnemyTurn(index));
                    break;

                case 7:
                    enemy = gm.inbattle[3];
                    infoText.text = enemy.EnemyName + "'s Turn!";
                    yield return new WaitForSeconds(2f);
                    ChangeMenu(BattleMenu.EnemyTurn);
                    StartCoroutine(EnemyTurn(index));
                    break;
                case 8:
                    enemy = gm.inbattle[4];
                    infoText.text = enemy.EnemyName + "'s Turn!";
                    yield return new WaitForSeconds(2f);
                    ChangeMenu(BattleMenu.EnemyTurn);
                    StartCoroutine(EnemyTurn(index));
                    break;
            }

        }
    }
    
    public IEnumerator EnemyTurn(int index)
    {
        Debug.Log("Inside of enemy turn");
        index = index - 4;
        int damage = gm.ALLIES[0].TakeDamageAlly(gm.ALLIES[0], gm.inbattle[index].unitstat.AttackStat, attribute.None, gm.inbattle[index].unitstat);
        Debug.Log("damage done" + damage);
        gm.playerhealth[0].SetHealth(gm.ALLIES[0].HP);
        StartCoroutine(DisplayText("Enemy did " + damage + " Points of Damage", 2));
        StartCoroutine(NextTurn());
        yield return new WaitForSeconds(0);
    }
    public bool checkopen(int n, int index)
        {
        bool open = true;
        for(int i = 0; i <9;i++)
        {
            if(Turn[i] == n && index !=i)
            {
                open = false;
                return open;
            }
        }
        return open;
        }
    public IEnumerator DisplayText(string tex,int sec)
    {
        SelectionMenu.gameObject.SetActive(false);
        selectioninfo.gameObject.SetActive(false);
        skillsMenu.gameObject.SetActive(false);
        skills2Menu.gameObject.SetActive(false);
        skillsDetails.gameObject.SetActive(false);
        infoMenu.gameObject.SetActive(true);

        EBB1.gameObject.SetActive(false);
        EBBF1.gameObject.SetActive(false);
        EBB2.gameObject.SetActive(false);
        EBBF2.gameObject.SetActive(false);
        EBB3.gameObject.SetActive(false);
        EBBF3.gameObject.SetActive(false);
        EBB4.gameObject.SetActive(false);
        EBBF4.gameObject.SetActive(false);
        EBB5.gameObject.SetActive(false);
        EBBF5.gameObject.SetActive(false);
        infoText.text = tex;
        yield return new WaitForSeconds(sec);
       // infoMenu.gameObject.SetActive(false);

    }
    public IEnumerator DisplayText(string tex)
    {
        SelectionMenu.gameObject.SetActive(false);
        selectioninfo.gameObject.SetActive(false);
        skillsMenu.gameObject.SetActive(false);
        skills2Menu.gameObject.SetActive(false);
        skillsDetails.gameObject.SetActive(false);
        infoMenu.gameObject.SetActive(true);

        EBB1.gameObject.SetActive(false);
        EBBF1.gameObject.SetActive(false);
        EBB2.gameObject.SetActive(false);
        EBBF2.gameObject.SetActive(false);
        EBB3.gameObject.SetActive(false);
        EBBF3.gameObject.SetActive(false);
        EBB4.gameObject.SetActive(false);
        EBBF4.gameObject.SetActive(false);
        EBB5.gameObject.SetActive(false);
        EBBF5.gameObject.SetActive(false);
        infoText.text = tex;
        yield return new WaitForSeconds(2);
       // infoMenu.gameObject.SetActive(false);
    }
}

public enum BattleMenu
{
    Selection,
    Skills,
    Skills2,
    Items,
    Attack,
    Info,
    EnemySelection,
    Victory,
    Defeat,
    Start,
    EnemyTurn
}

public enum ACTION
{
    Attack,
    Skill,
    Item,
    None
}

public enum EncounterState { PLAYERTURN, ENEMYTURN, DEFEAT}