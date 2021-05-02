using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimer : MonoBehaviour
{
    public Slider slider;
    public Text returnText;
    public Text instructionText;
    public float gameTime;

    private bool stopTimer;
    private bool startTimer;

    private float minTime = 2.39f;
    private float maxTime = 2.53f;


    void Start()
    {
        stopTimer = false;
        startTimer = false;
        slider.maxValue = gameTime;
        slider.value = 0.0f;
    }


    private void Update()
    {
        hitSpaceAction();
    }


    void FixedUpdate()
    {
        if (startTimer)
        {
            if (stopTimer)
            {
                verifyResult();
            }
            else
            {
                updadeSlider();
            }
        }
    }

    void hitSpaceAction()
    {
        if (Input.GetKeyDown("space"))
        {
            if (!startTimer)
            {
                startTimer = true;
                instructionText.text = "Precione ESPAÇO para parar!";
            }
            else if (startTimer && !stopTimer)
            {
                stopTimer = true;
                instructionText.text = "Precione ESPAÇO para resetar!";
            } 
            else if (startTimer && stopTimer)
            {
                resetTimer();
            }
        }
    }

    void verifyResult()
    {
        if (slider.value >= minTime && slider.value <= maxTime)
        {
            returnText.text = "Acertô miseravi!";
        }
        else
        {
            returnText.text = "Verrgonha da profissom!";
        }
    }

    void updadeSlider()
    {
        if (!stopTimer)
        {
            slider.value += Time.fixedDeltaTime;

            if (slider.value >= gameTime)
            {
                stopTimer = true;
            }
        }
    }

    void resetTimer()
    {
        slider.value = 0.0f;
        stopTimer = false;
        startTimer = false;
        returnText.text = "";
        instructionText.text = "Precione ESPAÇO para iniciar!";
    }
}
