using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLastScene : MonoBehaviour
{
    public GameObject fadeOutObj;
    private bool inArea = false;
    public AudioSource musicObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inArea && Input.GetKeyUp(KeyCode.Space))
        {
            fadeOutObj.SetActive(true);
            StartCoroutine("ChangeToLastScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inArea = true;
        }
    }

    private IEnumerator ChangeToLastScene()
    {
        StartCoroutine(FadeOutMusic());
        yield return new WaitForSeconds(4.7f);
        SceneManager.LoadScene("LastScene");
    }

    private IEnumerator FadeOutMusic()
    {
        float startVolume = musicObj.volume;
        float duration = 4.7f;
        float startTime = Time.time;

        while (Time.time < startTime + duration)
        {
            musicObj.volume = Mathf.Lerp(startVolume, 0, (Time.time - startTime) / duration);
            yield return null;
        }

        musicObj.volume = 0;
        musicObj.Stop();
    }
}
