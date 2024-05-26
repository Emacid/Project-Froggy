using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // Start is called before the first frame update

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public bool canPickUpItem = false;

    public bool inAreaRose = false;
    public bool inAreaSling = false;
    public bool inAreaLyre = false;
    public bool inAreaWorm = false;

    public bool RoseTaken = false;
    public bool SlingTaken = false;
    public bool LyreTaken = false;
    public bool WormTaken = false;

    public AudioSource pickupSound;

    public GameObject[] stomachItems;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canPickUpItem && inAreaRose)
        {
            //ROSE PICKUP
            Debug.Log("Rose Alýndý");
            StartCoroutine("PickupItem");
            PickRose();
        }

        if (Input.GetKeyDown(KeyCode.Space) && canPickUpItem && inAreaLyre)
        {
            //LYRE PICKUP
            Debug.Log("Lyre Alýndý");
            StartCoroutine("PickupItem");
            Picklyre();
        }

        if (Input.GetKeyDown(KeyCode.Space) && canPickUpItem && inAreaSling)
        {
            //SLING PICKUP
            Debug.Log("Sling Alýndý");
            StartCoroutine("PickupItem");
            PickSling();
        }

        if (Input.GetKeyDown(KeyCode.Space) && canPickUpItem && inAreaWorm)
        {
            //WORM PICKUP
            Debug.Log("Worm Alýndý");
            StartCoroutine("PickupItem");
            PickWorm();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //ITEM DROP TEST
            Debug.Log("Item Býrakýlmaya zorlandý");
            animator.SetBool("isPickingUp", false);
        }
    }

    private IEnumerator PickupItem() 
    {
        pickupSound.Play();
        animator.SetBool("isPickingUp", true);
        yield return new WaitForSeconds(0.7f);
        animator.SetBool("isPickingUp", false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Rose")) 
        {
            Debug.Log("Rose'un alanýndasýn");
            inAreaRose = true;
        }
        else if (other.CompareTag("Worm"))
        {
            Debug.Log("Worm'un alanýndasýn");
            inAreaWorm = true;
        }
        else if (other.CompareTag("Sling"))
        {
            Debug.Log("Sling'in alanýndasýn");
            inAreaSling = true;
        }
        else if (other.CompareTag("Lyre"))
        {
            Debug.Log("Lyre'ýn alanýndasýn");
            inAreaLyre = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inAreaLyre = false; inAreaSling = false; inAreaRose = false; inAreaWorm = false;
    }

    private void PickRose() 
    {
        stomachItems[0].gameObject.SetActive(true);
        stomachItems[1].gameObject.SetActive(false);
        stomachItems[2].gameObject.SetActive(false);
        stomachItems[3].gameObject.SetActive(false);
        RoseTaken = true;
    }

    private void PickSling()
    {
        stomachItems[0].gameObject.SetActive(false);
        stomachItems[1].gameObject.SetActive(true);
        stomachItems[2].gameObject.SetActive(false);
        stomachItems[3].gameObject.SetActive(false);
        SlingTaken = true;
    }

    private void Picklyre()
    {
        stomachItems[0].gameObject.SetActive(false);
        stomachItems[1].gameObject.SetActive(false);
        stomachItems[2].gameObject.SetActive(true);
        stomachItems[3].gameObject.SetActive(false);
        LyreTaken = true;
    }

    private void PickWorm()
    {
        stomachItems[0].gameObject.SetActive(false);
        stomachItems[1].gameObject.SetActive(false);
        stomachItems[2].gameObject.SetActive(false);
        stomachItems[3].gameObject.SetActive(true);
        WormTaken = true;
    }

}
