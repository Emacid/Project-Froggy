using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstCutscene : MonoBehaviour
{
    public GameObject fadeOutObject;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ChangeScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(10.0f);
        fadeOutObject.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("GameScene");
    }

}
