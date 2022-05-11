using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FadeInAndOut : MonoBehaviour
{
    public Tilemap treeTileMap;
    // Start is called before the first frame update
    void Start()
    {
        treeTileMap = GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            treeTileMap.color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            treeTileMap.color = new Color(1.0f, 1.0f, 1.0f);
        }
    }


}
