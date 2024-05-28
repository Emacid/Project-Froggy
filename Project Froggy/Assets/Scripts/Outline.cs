using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{

    public SpriteRenderer SpriteRendererOfChildren;

    private ItemPickup ItemPickup;

    // Start is called before the first frame update
    void Start()
    {
        ItemPickup = GameObject.Find("Body").GetComponent<ItemPickup>();

        foreach (Transform child in transform)
        {
            SpriteRendererOfChildren = child.GetComponent<SpriteRenderer>();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //Children objenin sprite renderer'ýný 0 yap
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Player Outline Tetikledi!");
            ItemPickup.canPickUpItem = true;
           SpriteRendererOfChildren.sortingOrder = 1;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player Outline Alanýndan Çýktý!");
        ItemPickup.canPickUpItem = false;
        SpriteRendererOfChildren.sortingOrder = -2;
    }


}
