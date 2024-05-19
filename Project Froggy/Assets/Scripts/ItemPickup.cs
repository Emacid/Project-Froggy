using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // Start is called before the first frame update

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //ITEM PICKUP
            Debug.Log("Item Al�nd�");
            StartCoroutine("PickupItem");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //ITEM DROP TEST
            Debug.Log("Item B�rak�ld�");
            animator.SetBool("isPickingUp", false);
        }
    }

    private IEnumerator PickupItem() 
    {
        animator.SetBool("isPickingUp", true);
        yield return new WaitForSeconds(0.7f);
        animator.SetBool("isPickingUp", false);
    }

}
