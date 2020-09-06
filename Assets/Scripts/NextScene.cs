using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private int nextSceneToLoad;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Flare")
        {
            anim.Play("Goal_show");
            //sound?
        }
        else
        {
            SceneManager.LoadScene(nextSceneToLoad);
        }
    }
}
