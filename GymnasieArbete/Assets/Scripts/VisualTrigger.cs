using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VisualTrigger : MonoBehaviour
{
    [SerializeField] private GameObject visualCue;
    public bool playerInRange;

    void Awake()
    {
        visualCue.SetActive(false);
        playerInRange = false;
    }

    void Update()
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
