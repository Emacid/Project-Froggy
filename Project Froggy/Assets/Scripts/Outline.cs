using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{

    private SpriteRenderer SpriteRendererOfChildren;

    // Start is called before the first frame update
    void Start()
    {
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
        //Children objenin sprite renderer'�n� 0 yap
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Player Outline Tetikledi!");
           SpriteRendererOfChildren.sortingOrder = 0;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player Outline Alan�ndan ��kt�!");
        SpriteRendererOfChildren.sortingOrder = -1;
    }


}
