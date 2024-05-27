using System.Collections;
using UnityEngine;


public class Quit : MonoBehaviour
{
    private bool canQuit = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnableQuitAfterDelay(13f));
    }

    // Update is called once per frame
    void Update()
    {
        if (canQuit && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape)))
        {
            Application.Quit();
            // Unity Editor'da çalýþtýrýrken oyun kapanmaz, bu satýrý ekleyerek editörde durdurabilirsiniz:
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }

    private IEnumerator EnableQuitAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canQuit = true;
    }
}
