using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    List<BaseAlly> ownedAllies = new List<BaseAlly>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class OwnedAllies
{
    public string Name;
    public BaseAlly ally;
    public int level;
    public List<Moves> moves = new List<Moves>();
}
    