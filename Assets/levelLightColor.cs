using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelLightColor : MonoBehaviour
{
    private GameManager gameManager;
    private int activeStage;
    private Light _light;
    private Color c0, c1, c2, c3, c4, c5, c6, c7, c8;
    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();
        gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();


        c0 = new Color(1,0,0);
        c1 = new Color(1,.22f,.15f);
        c2 = new Color(1,.475f,.3f);
        c3 = new Color(1,.725f,.45f);
        c4 = new Color(.89f, 1f, .83f);
        c5 = new Color(1,.95f,.84f);
        c6 = new Color(1,.50f,.60f);
        c7 = new Color(1,.75f,.5f);
        c8 = new Color(1,1,.5f);

    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu.GameIsPaused)
        {
            return;
        }
        else
        {
            activeStage = gameManager.activeStage;
            if (activeStage == 0)
            {
                _light.color = c0;
                _light.intensity = 5;
            }
            if (activeStage == 1)
            {
                _light.color = c1;
                _light.intensity = 4;
            }
            if (activeStage == 2)
            {
                _light.color = c2;
                _light.intensity = 3;
            }
            if (activeStage == 3)
            {
                _light.color = c3;
                _light.intensity = 2;
            }
            if (activeStage == 4)
            {
                //_light.color = Color.HSVToRGB(.44f, .16f, 1.00f);
                _light.color = c4;
                _light.intensity = 1;
            }
            if (activeStage == 5)
            {
                _light.color = c5;
                _light.intensity = 2;
            }
            if (activeStage == 6)
            {
                _light.color = c7;
                _light.intensity = 3;
            }
            if (activeStage == 7)
            {
                _light.color = c7;
                _light.intensity = 4;
            }
            if (activeStage == 8)
            {
                _light.color = c8;
                _light.intensity = 5;
            }
        }

    }
}
