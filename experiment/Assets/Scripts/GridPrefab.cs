using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPrefab : MonoBehaviour
{
    public GameObject prefab;
    public float gridx= 25;
    public float gridy =24;
    public float spacing = 1;
    // Start is called before the first frame update
    void Start()
    {
        for (int y = 0; y < gridy; y++)
        {
            for(int x = 0; x < gridx; x++)
            {
                Vector3 pos = new Vector3(x, 0, y);
                Instantiate(prefab, pos, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
