using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    [SerializeField] Sprite[] spritesRot;

    bool startCor = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !startCor)
        {
            StartCoroutine(RotPlatform());
            startCor = true;
        }
    }

    IEnumerator RotPlatform()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Des 1");
        GetComponent<SpriteRenderer>().sprite = spritesRot[1];
        yield return new WaitForSeconds(1f);
        Debug.Log("Des 2");
        GetComponent<Collider2D>().enabled = false;
        //мен€ю спрайт на сломанный
        GetComponent<SpriteRenderer>().sprite = spritesRot[2];
        yield return new WaitForSeconds(2f);
        GetComponent<Collider2D>().enabled = true;
        //ћен€ю спрайт на первый
        GetComponent<SpriteRenderer>().sprite = spritesRot[0];
        startCor = false;
    }
}
