using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Oxygen : MonoBehaviour
{
    Image oxygenBar;
    public float maxOxygen;
    float oxygenLeft;
    private int currentSceneToLoad;
    public GameObject deathCanvas;


    // Start is called before the first frame update
    void Start()
    {
        oxygenBar = GetComponent<Image>();
        oxygenLeft = maxOxygen;
    }

    // Update is called once per frame
    void Update()
    {
        if(oxygenLeft > 0)
        {
            oxygenLeft -= Time.deltaTime;
            oxygenBar.fillAmount = oxygenLeft/maxOxygen;
        }
        else
        {
            // game over
            //Time.timeScale = 0;
            //SceneManager.LoadScene(4);
            Time.timeScale = 0;
            deathCanvas.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Z)){
                Time.timeScale = 1;
                currentSceneToLoad = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneToLoad);
            }
        }
    }
}
