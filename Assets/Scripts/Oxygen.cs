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
            SceneManager.LoadScene(4);
        }
    }
}
