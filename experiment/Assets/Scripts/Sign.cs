using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


public class Sign : MonoBehaviour
{

public GameObject dialogbox;
    public Text dialogText;
    public string dialog;
    public bool PlayerinRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("return")) && PlayerinRange)

        {
            UnityEngine.Debug.Log("Space pushed and player in range");
            if (dialogbox.activeInHierarchy)
            {
                dialogbox.SetActive(false);
                
            }
            else{
                dialogbox.SetActive(true);
                dialogText.text = dialog;
                }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerinRange = true;
            UnityEngine.Debug.Log("Player in range");
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerinRange = false;
            dialogbox.SetActive(false);
        }
    }
}
