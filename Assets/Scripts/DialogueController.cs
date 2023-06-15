using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public GameObject dialogueBox; 
    public KeyCode interactKey = KeyCode.E; 
    private bool inRange = false; 
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            inRange = true;
            anim.SetBool("inArea", true);
            anim.SetBool("appDone", true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
            anim.SetBool("inArea", false);
            anim.SetBool("disaDone", true);
        }
    }

    private void Update()
    {
        if (inRange && Input.GetKeyDown(interactKey))
        {
            dialogueBox.SetActive(true);
        }
    }
}
