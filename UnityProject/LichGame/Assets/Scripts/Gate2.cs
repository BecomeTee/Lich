using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate2 : MonoBehaviour
{
    [SerializeField] Sprite[] spritesGates;

    public int keyCollected = 0;

    [SerializeField] private int neededKeys;

    private void Update()
    {
        ChangeGateLvl();
        if (Input.GetKeyUp(KeyCode.E) && keyCollected == neededKeys)
        {
            Debug.Log("NextLvl");
            LoadNextLvl();
        }
    }
    public void LoadNextLvl()
    {
        SceneManager.LoadScene("Final");
    }

    public void ChangeGateLvl()
    {
        if (keyCollected == 3)
        {
            Debug.Log("Lock = 0");
            GetComponent<SpriteRenderer>().sprite = spritesGates[0];
            return;
        }
        else if (keyCollected == 2)
        {
            Debug.Log("Lock = 1");
            GetComponent<SpriteRenderer>().sprite = spritesGates[1];
            return;
        }
        else if (keyCollected == 1)
        {
            Debug.Log("Lock = 2");
            GetComponent<SpriteRenderer>().sprite = spritesGates[2];
            return;
        }
        else if (keyCollected <= 0)
        {
            Debug.Log("Lock = 3");
            GetComponent<SpriteRenderer>().sprite = spritesGates[3];
            return;
        }

        /*if (keyCollected == 1)
        {
            //Debug.Log("Lock = 0");
            GetComponent<SpriteRenderer>().sprite = spritesGates[0];
            return;
        }
        else if (keyCollected <= 0)
        {
            //Debug.Log("Lock = 1");
            GetComponent<SpriteRenderer>().sprite = spritesGates[1];
            return;
        }*/

    }
}
