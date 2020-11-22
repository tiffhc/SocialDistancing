using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Animator transition;
    private float transitTime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadscene(string scene)
    {
        StartCoroutine(waitLoadScene(scene));
    }

    IEnumerator waitLoadScene(string scene)
    {
        transition.SetTrigger("fadeIN");
        yield return new WaitForSeconds(transitTime);
        SceneManager.LoadScene(scene);
    }

}
