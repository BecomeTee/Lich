using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupsCounter : MonoBehaviour
{

    public int counter = 0;
    [SerializeField] Sprite[] spritesKeys;
    [SerializeField] private GameObject KeyBar;

    [SerializeField] public AudioSource CollectSound;

    private void Start()
    {
        ChangeKeysBar();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            counter++;
            ChangeKeysBar();
            CollectSound.Play();

            Debug.Log("Собранно " + counter + " ключей");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lewer"))
        {
            if (!collision.gameObject.GetComponent<Lewer>().Used)
            {
                //Debug.Log("Рычааааааааааааааааааааг");
                collision.gameObject.GetComponent<Lewer>().enabled = true;
            }
        }

        if (collision.gameObject.CompareTag("Gate"))
        {
            Debug.Log("Двеееерь!!!!!!");
            collision.gameObject.GetComponent<Gate>().enabled = true;
            collision.gameObject.GetComponent<Gate>().keyCollected = counter;
        }

        if (collision.gameObject.CompareTag("Gate2"))
        {
            Debug.Log("Двеееерь!!!!!!");
            
            collision.gameObject.GetComponent<Gate2>().enabled = true;
            collision.gameObject.GetComponent<Gate2>().keyCollected = counter;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lewer"))
        {
            //Debug.Log("Не рычаг");
            collision.gameObject.GetComponent<Lewer>().enabled = false;
        }

        if (collision.gameObject.CompareTag("Gate"))
        {
            //Debug.Log("Не рычаг");
            collision.gameObject.GetComponent<Gate>().enabled = false;
        }
    }

    private void ChangeKeysBar()
    {
        if (counter == 0)
        {
            Debug.Log("Key = 0");
            KeyBar.GetComponent<SpriteRenderer>().sprite = spritesKeys[0];
            return;
        }
        else if (counter == 1)
        {
            Debug.Log("Key = 1");
            KeyBar.GetComponent<SpriteRenderer>().sprite = spritesKeys[1];
            return;
        }
        else if (counter == 2)
        {
            Debug.Log("Key = 2");
            KeyBar.GetComponent<SpriteRenderer>().sprite = spritesKeys[2];
            return;
        }
        else if (counter == 3)
        {
            Debug.Log("Key = 3");
            KeyBar.GetComponent<SpriteRenderer>().sprite = spritesKeys[3];
            return;
        }

    }
}
