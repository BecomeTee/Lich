using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lewer : MonoBehaviour
{
    [SerializeField] Sprite[] spritesLawer;

    [SerializeField] public AudioSource LewerSound;


    [SerializeField] private GameObject platform;

    public bool Used = false;
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = spritesLawer[0];
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            GetComponent<SpriteRenderer>().sprite = spritesLawer[1];
            TurnOnFollow();
        }
    }
    public void TurnOnFollow()
    {
        LewerSound.Play();
        platform.GetComponent<PointWayFollowing>().enabled = true;
        Used = true;
    }
}
