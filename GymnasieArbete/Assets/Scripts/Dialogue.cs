using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    [SerializeField] private string[] sentences; //Meningarna som karaktären säger.
    [SerializeField] private bool canTalk = true;
    [HideInInspector] public int index = 0; //Index anger vilket index i sentences som karaktären ska säga.

    [SerializeField] private float typingSpeed;
    [SerializeField] private PlayerController player;
    [SerializeField] private VisualTrigger trigger;

    private void Update()
    {
        player.LastDirection();

        //Startar en dialog med en karaktär. Kollar om man är i närheten och att canTalk är sann.  
        if (Input.GetKeyDown(KeyCode.Space) && canTalk && trigger.playerInRange)
        {
            player.animator.SetFloat("Speed", 0);
            player.enabled = false;
            canTalk = false;
            StartCoroutine(Type());
        }

        //Kollar om hela meningen har skrivits ut. Om det är sant fortsätter den att skriva nästa mening. 
        if (textDisplay.text == sentences[index])
        {
            NextSentence();
        }
    }

    //Skriver ut en viss mening från fältet sentences. 
    private IEnumerator Type()
    {            
        //Skriver ut en bokstav i taget med viss intervall.
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //En metod för att gå till nästa mening.
    private void NextSentence()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Går till nästa mening om karaktären inte har sagt alla meningar. Annars avslutas dialogen.
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
