using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ItemPickup : MonoBehaviour
{
    // Start is called before the first frame update

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private LyreFromGod lyreFromGod;

    public float playerDeactivateTime = 4.0f;
    
    public bool canPickUpItem = false;
    private bool canMoveNow = false;

    public bool holdTheAnim = false;
    public bool holdTheAnimShort = false;

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

    private bool canStopMusic = false;

    private bool roseGoneForever = false;
    private bool slingGoneForever = false;
    private bool lyreGoneForever = false;
    private bool wormGoneForever = false;

    public GameObject roseObject;
    public GameObject wormObject;
    public GameObject slingObject;
    public GameObject[] lyreObjects;

    public AudioSource pickupSound;
    public AudioSource musicObj;
    public GameObject bearKillSound;

    public PlayableDirector princessAnim;
    public PlayableDirector fishermanAnim;
    public PlayableDirector BigTreeAnim;
    public PlayableDirector princessShortAnim;
    public PlayableDirector fishermanShortAnim;
    public PlayableDirector BigTreeShortAnim;
    public PlayableDirector BearShortAnim;
    public PlayableDirector BearLongAnim;

    public Animator princessAnimator;
    public Animator princessShortAnimator;
    public Animator fishermanAnimator;
    public Animator fishermanShortAnimator;
    public Animator BigTreeAnimator;
    public Animator BigTreeShortAnimator;
    public Animator BearShortAnimator;
    public Animator BearLongAnimator;

    public GameObject[] stomachItems;
    public Footsteps footsteps;

    public GameObject princessGameObject;
    public GameObject fishermanGameObject;
    public GameObject[] BigTreeGameObjects;
    public GameObject bearObject;

    public GameObject noLeafTreeHolder;

    public Outline roseOutline;
    public Outline wormOutline;
    public Outline slingOutline;

    public Player playerScript;

    public AudioSource princessAudio;
    public AudioSource princessAudioShort;

    public GameObject restartUI;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lyreFromGod = GameObject.Find("Lyre Controller").GetComponent<LyreFromGod>();
        
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
            inAreaRose = false;
            canPickUpItem = false;
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
            inAreaSling = false;
            canPickUpItem = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canPickUpItem && inAreaWorm)
        {
            //WORM PICKUP
            Debug.Log("Worm Alýndý");
            StartCoroutine("PickupItem");
            PickWorm();
            inAreaWorm = false;
            canPickUpItem = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && inAreaPrincess && RoseTaken && !holdTheAnim)
        {
            //Princess Full Anim
            Debug.Log("Princess Animasyon Triggerlandý");
            musicObj.Pause();
            StartCoroutine("HoldingTheFootstepstLong");
            holdTheAnim = true;
            StartCoroutine("HoldingTheAnimLong");
            princessAudio.Play();
            princessAnim.Play();
            princessAnimator.SetBool("PlayPrincessAnim", true);
            StartCoroutine("DeletePrincess");
            roseObject.SetActive(false);
            roseGoneForever = true;
            inAreaPrincess = false;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && inAreaPrincess && !holdTheAnimShort)
        {
            //Princess Short Anim
            Debug.Log("Princess Short Animasyon Triggerlandý");
            musicObj.Pause();
            princessAudioShort.gameObject.SetActive(true);
            StartCoroutine("HoldingTheFootstepstShort");
            holdTheAnimShort = true;
            StartCoroutine("HoldingTheAnimShort");
            princessShortAnim.Play();
            princessShortAnimator.SetBool("PlayPrincessShort", true);
            StartCoroutine("DeactivatePlayerMovement");
            princessShortAnim.time = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && inAreaFisherman && WormTaken && !holdTheAnim)
        {
            //Fisherman Full Anim
            Debug.Log("Fisherman Animasyon Triggerlandý");
            musicObj.Pause();
            StartCoroutine("HoldingTheFootstepstLong");
            holdTheAnim = true;
            StartCoroutine("HoldingTheAnimLong");
            princessAudio.Play();
            fishermanAnim.Play();
            fishermanAnimator.SetBool("PlayFishermanAnim", true);
            StartCoroutine("DeleteFisherman");
            wormObject.SetActive(false);
            wormGoneForever = true;
            inAreaFisherman = false;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && inAreaFisherman && !holdTheAnimShort)
        {
            //Fisherman Short Anim
            Debug.Log("Fisherman Short Animasyon Triggerlandý");
            musicObj.Pause();
            princessAudioShort.gameObject.SetActive(true);
            StartCoroutine("HoldingTheFootstepstShort");
            holdTheAnimShort = true;
            StartCoroutine("HoldingTheAnimShort");
            fishermanShortAnim.Play();
            fishermanShortAnimator.SetBool("PlayFishermanShort", true);
            StartCoroutine("DeactivatePlayerMovement");
            fishermanShortAnim.time = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && inAreaBigTree && SlingTaken && !holdTheAnim)
        {
            //Big Tree Fairy Full Anim
            Debug.Log("Big Tree Animasyon Triggerlandý");
            musicObj.Pause();
            StartCoroutine("HoldingTheFootstepstLong");
            holdTheAnim = true;
            StartCoroutine("HoldingTheAnimLong");
            princessAudio.Play();
            BigTreeAnim.Play();
            BigTreeAnimator.SetBool("PlayFairyAnim", true);
            StartCoroutine("DeleteBigTree");
            slingObject.SetActive(false);
            slingGoneForever = true;
            inAreaBigTree = false;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && inAreaBigTree && !holdTheAnimShort)
        {
            //Big Tree Fairy Short Anim
            Debug.Log("Big Tree Short Animasyon Triggerlandý");
            musicObj.Pause();
            princessAudioShort.gameObject.SetActive(true);
            StartCoroutine("HoldingTheFootstepstShort");
            holdTheAnimShort = true;
            StartCoroutine("HoldingTheAnimShort");
            BigTreeShortAnim.Play();
            BigTreeShortAnimator.SetBool("PlayFairyShort", true);
            StartCoroutine("DeactivatePlayerMovement");
            BigTreeShortAnim.time = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && inAreaBear && LyreTaken && !holdTheAnim)
        {
            //Ayý Full Anim
            Debug.Log("Ayýyý öldürme Triggerlandý");
            musicObj.Pause();
            StartCoroutine("HoldingTheFootstepstLong");
            holdTheAnim = true;
            StartCoroutine("HoldingTheAnimLong");
            princessAudio.Play();
            BearLongAnim.Play();
            BearLongAnimator.SetBool("PlayBearAnim", true);
            StartCoroutine("DeleteBear");
            lyreGoneForever = true;
            inAreaBear = false;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && inAreaBear && !holdTheAnimShort)
        {
            //Ayý Short Anim
            Debug.Log("Ayý Bizi Öldürüyoo Animasyon Triggerlandý");
            musicObj.Pause();
            canStopMusic = true;
            StartCoroutine("HoldingTheFootstepstForever");
            holdTheAnimShort = true;
            StartCoroutine("HoldingTheAnimShort");
            BearShortAnim.Play();
            BearShortAnimator.SetBool("PlayBearShort", true);
            StartCoroutine("DeactivatePlayerMovement");
            BearShortAnim.time = 0;
            StartCoroutine("killedByBear");
        }

        if (roseGoneForever && slingGoneForever && wormGoneForever && !canMoveNow) 
        {
            lyreFromGod.allTaken = true;
            StartCoroutine("DeactivatePlayerMovement");
            canMoveNow = true;
        }
    }

    private IEnumerator PickupItem() 
    {
        pickupSound.PlayDelayed(0.5f);
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
        stomachItems[0].gameObject.SetActive(false);
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
        BigTreeGameObjects[0].SetActive(false);
        BigTreeGameObjects[1].SetActive(false);
        BigTreeGameObjects[2].SetActive(false);
        stomachItems[1].gameObject.SetActive(false);
        yield return new WaitForSeconds(10f);
        playerScript.enabled = true;
    }

    private IEnumerator DeleteBear()
    {
        playerScript.enabled = false;
        yield return new WaitForSeconds(3f);
        bearObject.SetActive(false);
        stomachItems[2].gameObject.SetActive(false);
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
        inAreaLyre = false; inAreaSling = false; inAreaRose = false; inAreaWorm = false; inAreaPrincess=false; inAreaBigTree=false; inAreaFisherman=false; inAreaBear = false; canPickUpItem = false;   
    }

    private void PickRose() 
    {
        roseObject.SetActive(false);

        stomachItems[0].gameObject.SetActive(true);
        stomachItems[1].gameObject.SetActive(false);
        stomachItems[2].gameObject.SetActive(false);
        stomachItems[3].gameObject.SetActive(false);
        
        RoseTaken = true;
        SlingTaken = false;
        LyreTaken = false;
        WormTaken = false;

        StartCoroutine("ItemsToStartingPlaces");
    }

    private void PickSling()
    {
        slingObject.SetActive(false);
        noLeafTreeHolder.SetActive(true);

        stomachItems[0].gameObject.SetActive(false);
        stomachItems[1].gameObject.SetActive(true);
        stomachItems[2].gameObject.SetActive(false);
        stomachItems[3].gameObject.SetActive(false);
        
        RoseTaken = false;
        SlingTaken = true;
        LyreTaken = false;
        WormTaken = false;

        StartCoroutine("ItemsToStartingPlaces");
    }

    private void Picklyre()
    {
        lyreObjects[0].SetActive(false);
        lyreObjects[1].SetActive(false);
        lyreObjects[2].SetActive(false);

        stomachItems[0].gameObject.SetActive(false);
        stomachItems[1].gameObject.SetActive(false);
        stomachItems[2].gameObject.SetActive(true);
        stomachItems[3].gameObject.SetActive(false);
        
        RoseTaken = false;
        SlingTaken = false;
        LyreTaken = true;
        WormTaken = false;
        
        inAreaLyre = false;
        canPickUpItem = false;

        StartCoroutine("ItemsToStartingPlaces");
    }

    private void PickWorm()
    {
        wormObject.SetActive(false);

        stomachItems[0].gameObject.SetActive(false);
        stomachItems[1].gameObject.SetActive(false);
        stomachItems[2].gameObject.SetActive(false);
        stomachItems[3].gameObject.SetActive(true);
        
        RoseTaken = false;
        SlingTaken = false;
        LyreTaken = false;
        WormTaken = true;

        StartCoroutine("ItemsToStartingPlaces");
    }


    private IEnumerator ItemsToStartingPlaces()
    {
        yield return new WaitForSeconds(0.01f);

        if (!roseGoneForever && !RoseTaken) 
        {
            roseObject.SetActive(true);
            roseOutline.SpriteRendererOfChildren.sortingOrder = -2;
        }

        if (!wormGoneForever && !WormTaken)
        {
            wormObject.SetActive(true);
            wormOutline.SpriteRendererOfChildren.sortingOrder = -2;
        }

        if (!slingGoneForever && !SlingTaken)
        {
            slingObject.SetActive(true);
            slingOutline.SpriteRendererOfChildren.sortingOrder = -2;
        }
    }

    private IEnumerator HoldingTheAnimLong()
    {
        yield return new WaitForSeconds(13f);
        holdTheAnim = false;
        musicObj.Play();
    }

    private IEnumerator HoldingTheAnimShort()
    {
        yield return new WaitForSeconds(7f);
        holdTheAnimShort = false;
        princessAudioShort.gameObject.SetActive(false);
        if (!canStopMusic) 
        {
           musicObj.Play();
        }
        
    }

    private IEnumerator HoldingTheFootstepstLong()
    {
        footsteps.enabled = false;
        yield return new WaitForSeconds(15f);
        footsteps.enabled = true;
        
    }

    private IEnumerator HoldingTheFootstepstShort()
    {
        footsteps.enabled = false;
        yield return new WaitForSeconds(7f);
        footsteps.enabled = true;
        
    }

    private IEnumerator HoldingTheFootstepstForever()
    {
        footsteps.enabled = false;
        yield return new WaitForSeconds(90f);
        footsteps.enabled = false;

    }

    private IEnumerator killedByBear()
    {
        footsteps.enabled = false;
        playerScript.enabled = false;
        yield return new WaitForSeconds(8f);
        restartUI.SetActive(true);
    }
}
