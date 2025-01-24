using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_WinCon : MonoBehaviour
{
    public GameObject playerRef;
    public float DeathTime;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerRef.SetActive(false);
            StartCoroutine(WinScene());
        }
        
    }

    IEnumerator WinScene()
    {
        yield return new WaitForSeconds(DeathTime);
        SceneManager.LoadScene(sceneName);
    }
}
