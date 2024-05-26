using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

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

    public bool inAreaPrincess = false;
    public bool inAreaBear = false;
    public bool inAreaFisherman = false;
    public bool inAreaBigTree = false;

    public bool RoseTaken = false;
    public bool SlingTaken = false;
    public bool LyreTaken = false;
    public bool WormTaken = false;

    public AudioSource pickupSound;

    public PlayableDirector princessAnim;

    public Animator princessAnimator;

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
            Debug.Log("Rose Al�nd�");
            StartCoroutine("PickupItem");
            PickRose();
        }

        if (Input.GetKeyDown(KeyCode.Space) && canPickUpItem && inAreaLyre)
        {
            //LYRE PICKUP
            Debug.Log("Lyre Al�nd�");
            StartCoroutine("PickupItem");
            Picklyre();
        }

        if (Input.GetKeyDown(KeyCode.Space) && canPickUpItem && inAreaSling)
        {
            //SLING PICKUP
            Debug.Log("Sling Al�nd�");
            StartCoroutine("PickupItem");
            PickSling();
        }

        if (Input.GetKeyDown(KeyCode.Space) && canPickUpItem && inAreaWorm)
        {
            //WORM PICKUP
            Debug.Log("Worm Al�nd�");
            StartCoroutine("PickupItem");
            PickWorm();
        }

        if (Input.GetKeyDown(KeyCode.Space) && inAreaPrincess && RoseTaken)
        {
            //Princess Full Anim
            Debug.Log("Princess Animasyon Triggerland�");
            princessAnim.Play();
            princessAnimator.SetBool("PlayPrincessAnim", true);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //ITEM DROP TEST
            Debug.Log("Item B�rak�lmaya zorland�");
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
            Debug.Log("Rose'un alan�ndas�n");
            inAreaRose = true;
        }
        else if (other.CompareTag("Worm"))
        {
            Debug.Log("Worm'un alan�ndas�n");
            inAreaWorm = true;
        }
        else if (other.CompareTag("Sling"))
        {
            Debug.Log("Sling'in alan�ndas�n");
            inAreaSling = true;
        }
        else if (other.CompareTag("Lyre"))
        {
            Debug.Log("Lyre'�n alan�ndas�n");
            inAreaLyre = true;
        }
        else if (other.CompareTag("Bear"))
        {
            Debug.Log("Bear'�n alan�ndas�n");
            inAreaBear = true;
        }
        else if (other.CompareTag("Princess"))
        {
            Debug.Log("Princess'�n alan�ndas�n");
            inAreaPrincess = true;
        }
        else if (other.CompareTag("BigTree"))
        {
            Debug.Log("BigTree'�n alan�ndas�n");
            inAreaBigTree = true;
        }
        else if (other.CompareTag("Fisherman"))
        {
            Debug.Log("Fisherman'�n alan�ndas�n");
            inAreaFisherman = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inAreaLyre = false; inAreaSling = false; inAreaRose = false; inAreaWorm = false; inAreaPrincess=false; inAreaBigTree=false; inAreaFisherman=false; inAreaBear = false;   
    }

    private void PickRose() 
    {
        stomachItems[0].gameObject.SetActive(true);
        stomachItems[1].gameObject.SetActive(false);
        stomachItems[2].gameObject.SetActive(false);
        stomachItems[3].gameObject.SetActive(false);
        RoseTaken = true;
        SlingTaken = false;
        LyreTaken = false;
        WormTaken = false;
    }

    private void PickSling()
    {
        stomachItems[0].gameObject.SetActive(false);
        stomachItems[1].gameObject.SetActive(true);
        stomachItems[2].gameObject.SetActive(false);
        stomachItems[3].gameObject.SetActive(false);
        RoseTaken = false;
        SlingTaken = true;
        LyreTaken = false;
        WormTaken = false;
    }

    private void Picklyre()
    {
        stomachItems[0].gameObject.SetActive(false);
        stomachItems[1].gameObject.SetActive(false);
        stomachItems[2].gameObject.SetActive(true);
        stomachItems[3].gameObject.SetActive(false);
        RoseTaken = false;
        SlingTaken = false;
        LyreTaken = true;
        WormTaken = false;
    }

    private void PickWorm()
    {
        stomachItems[0].gameObject.SetActive(false);
        stomachItems[1].gameObject.SetActive(false);
        stomachItems[2].gameObject.SetActive(false);
        stomachItems[3].gameObject.SetActive(true);
        RoseTaken = false;
        SlingTaken = false;
        LyreTaken = false;
        WormTaken = true;
    }

}
