using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{

    public Vector2 cameraChange;
    public Vector2 cameramin;
    public Vector2 cameramax;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needtext;
    public string name_of_place;
    public GameObject text;
    public Text placetext;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            cam.max.x = cameramax.x;
            cam.max.y = cameramax.y;
            cam.min.x = cameramin.x;
            cam.min.y = cameramin.y;
            collision.transform.position += playerChange;

            if (needtext)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }
    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placetext.text = name_of_place;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}
