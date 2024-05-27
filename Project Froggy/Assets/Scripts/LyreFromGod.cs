using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyreFromGod : MonoBehaviour
{
    
    public bool allTaken = false;

    public GameObject[] lyreObjects;

    public GameObject[] objectsToDeactivate;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (allTaken) 
        {
            StartCoroutine("SendLyre");
        }
    }

    private IEnumerator SendLyre()
    {
        yield return new WaitForSeconds(12.0f);
        lyreObjects[0].SetActive(true);
        lyreObjects[1].SetActive(true);
        lyreObjects[2].SetActive(true);
        yield return new WaitForSeconds(5.3f);
        objectsToDeactivate[0].SetActive(false);
        objectsToDeactivate[1].SetActive(false);
        objectsToDeactivate[2].SetActive(false);
        objectsToDeactivate[3].SetActive(false);
        objectsToDeactivate[4].SetActive(false);
        objectsToDeactivate[5].SetActive(false);
        objectsToDeactivate[6].SetActive(false);
    }

}
