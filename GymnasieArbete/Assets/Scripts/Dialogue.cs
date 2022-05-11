using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    [SerializeField] private string[] sentences; //Meningarna som karakt�ren s�ger.
    [SerializeField] private bool canTalk = true;
    [HideInInspector] public int index = 0; //Index anger vilket index i sentences som karakt�ren ska s�ga.

    [SerializeField] private float typingSpeed;
    [SerializeField] private PlayerController player;
    [SerializeField] private VisualTrigger trigger;

    private void Update()
    {
        player.LastDirection();

        //Startar en dialog med en karakt�r. Kollar om man �r i n�rheten och att canTalk �r sann.  
        if (Input.GetKeyDown(KeyCode.Space) && canTalk && trigger.playerInRange)
        {
            player.animator.SetFloat("Speed", 0);
            player.enabled = false;
            canTalk = false;
            StartCoroutine(Type());
        }

        //Kollar om hela meningen har skrivits ut. Om det �r sant forts�tter den att skriva n�sta mening. 
        if (textDisplay.text == sentences[index])
        {
            NextSentence();
        }
    }

    //Skriver ut en viss mening fr�n f�ltet sentences. 
    private IEnumerator Type()
    {            
        //Skriver ut en bokstav i taget med viss intervall.
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //En metod f�r att g� till n�sta mening.
    private void NextSentence()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //G�r till n�sta mening om karakt�ren inte har sagt alla meningar. Annars avslutas dialogen.
            if (index < sentences.Length - 1)
            {
                index++;
                textDisplay.text = "";
                StartCoroutine(Type());
            }
            else 
            {
                textDisplay.text = "";
                index = 0;
                player.enabled = true;
                canTalk = true;
            }
        }
    }
}
