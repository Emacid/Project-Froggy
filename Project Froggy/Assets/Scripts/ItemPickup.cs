using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ItemPickup : MonoBehaviour
{
    // Start is called before the first frame update

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public float playerDeactivateTime = 4.0f;
    
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

    public GameObject roseObject;
    public GameObject wormObject;
    public GameObject slingObject;
    public GameObject[] lyreObjects;

    public AudioSource pickupSound;

    public PlayableDirector princessAnim;
    public PlayableDirector fishermanAnim;
    public PlayableDirector BigTreeAnim;
    public PlayableDirector princessShortAnim;
    public PlayableDirector fishermanShortAnim;
    public PlayableDirector BigTreeShortAnim;

    public Animator princessAnimator;
    public Animator princessShortAnimator;
    public Animator fishermanAnimator;
    public Animator fishermanShortAnimator;
    public Animator BigTreeAnimator;
    public Animator BigTreeShortAnimator;

    public GameObject[] stomachItems;

    public GameObject princessGameObject;
    public GameObject fishermanGameObject;
    public GameObject BigTreeGameObject;

    public Player playerScript;

    public AudioSource princessAudio;

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

        if (Input.GetKeyDown(KeyCode.Space) && inAreaPrincess && RoseTaken)
        {
            //Princess Full Anim
            Debug.Log("Princess Animasyon Triggerlandý");
            princessAudio.Play();
            princessAnim.Play();
            princessAnimator.SetBool("PlayPrincessAnim", true);
            StartCoroutine("DeletePrincess");
        }

        else if (Input.GetKeyDown(KeyCode.Space) && inAreaPrincess)
        {
            //Princess Short Anim
            Debug.Log("Princess Short Animasyon Triggerlandý");
            princessShortAnim.Play();
            princessShortAnimator.SetBool("PlayPrincessShort", true);
            StartCoroutine("DeactivatePlayerMovement");
            princessShortAnim.time = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && inAreaFisherman && WormTaken)
        {
            //Fisherman Full Anim
            Debug.Log("Fisherman Animasyon Triggerlandý");
            fishermanAnim.Play();
            fishermanAnimator.SetBool("PlayFishermanAnim", true);
            StartCoroutine("DeleteFisherman");
        }

        else if (Input.GetKeyDown(KeyCode.Space) && inAreaFisherman)
        {
            //Fisherman Short Anim
            Debug.Log("Fisherman Short Animasyon Triggerlandý");
            fishermanShortAnim.Play();
            fishermanShortAnimator.SetBool("PlayFishermanShort", true);
            StartCoroutine("DeactivatePlayerMovement");
            fishermanShortAnim.time = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && inAreaBigTree && SlingTaken)
        {
            //Big Tree Fairy Full Anim
            Debug.Log("Big Tree Animasyon Triggerlandý");
            BigTreeAnim.Play();
            BigTreeAnimator.SetBool("PlayFairyAnim", true);
            StartCoroutine("DeleteBigTree");
        }

        else if (Input.GetKeyDown(KeyCode.Space) && inAreaBigTree)
        {
            //Big Tree Fairy Short Anim
            Debug.Log("Big Tree Short Animasyon Triggerlandý");
            BigTreeShortAnim.Play();
            BigTreeShortAnimator.SetBool("PlayFairyShort", true);
            StartCoroutine("DeactivatePlayerMovement");
            fishermanShortAnim.time = 0;
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

    private IEnumerator DeactivatePlayerMovement()
    {
        playerScript.enabled = false;
        yield return new WaitForSeconds(playerDeactivateTime);
        playerScript.enabled = true;
    }

    private IEnumerator DeletePrincess()
    {
        playerScript.enabled = false;
        yield return new WaitForSeconds(3f);
        princessGameObject.SetActive(false);
        yield return new WaitForSeconds(10f);
        playerScript.enabled = true;
    }

    private IEnumerator DeleteFisherman()
    {
        playerScript.enabled = false;
        yield return new WaitForSeconds(5f);
        fishermanGameObject.SetActive(false);
        stomachItems[3].gameObject.SetActive(false);
        yield return new WaitForSeconds(7.5f);
        playerScript.enabled = true;
    }

    private IEnumerator DeleteBigTree()
    {
        playerScript.enabled = false;
        yield return new WaitForSeconds(3f);
        BigTreeGameObject.SetActive(false);
        yield return new WaitForSeconds(10f);
        playerScript.enabled = true;
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
        else if (other.CompareTag("Bear"))
        {
            Debug.Log("Bear'ýn alanýndasýn");
            inAreaBear = true;
        }
        else if (other.CompareTag("Princess"))
        {
            Debug.Log("Princess'ýn alanýndasýn");
            inAreaPrincess = true;
        }
        else if (other.CompareTag("BigTree"))
        {
            Debug.Log("BigTree'ýn alanýndasýn");
            inAreaBigTree = true;
        }
        else if (other.CompareTag("Fisherman"))
        {
            Debug.Log("Fisherman'ýn alanýndasýn");
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
