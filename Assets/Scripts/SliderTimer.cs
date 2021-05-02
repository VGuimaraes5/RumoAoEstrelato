using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimer : MonoBehaviour
{
    public Slider slider;
    private RectTransform sliderTransform;

    public GameObject target;
    private float targetStartPosition;
    private float targetWidth = 50.0f;
    private float targetMinStart = 200.0f;
    private float targetMaxStart = 350.0f;

    public Text instructionText;
    public Text returnText;

    [SerializeField]
    private Dificult dificult;

    public float gameTime;
    private bool stopTimer;
    private bool startTimer;
    

    void Start()
    {
        sliderTransform = slider.GetComponent<RectTransform>();
        DefineTarget();
        targetWidth /= (int)dificult;
        stopTimer = false;
        startTimer = false;
        slider.maxValue = gameTime;
        slider.value = 0.0f;
    }


    private void Update()
    {
        HitSpaceAction();
    }


    void FixedUpdate()
    {
        if (startTimer)
        {
            if (stopTimer)
            {
                VerifyResult();
            }
            else
            {
                UpdadeSlider();
            }
        }
    }

    void HitSpaceAction()
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
                ResetTimer();
            }
        }
    }

    void VerifyResult()
    {
        float pointerPosition = (slider.value * sliderTransform.sizeDelta.x) / slider.maxValue;
        if (pointerPosition >= targetStartPosition && pointerPosition <= (targetStartPosition + targetWidth))
        {
            returnText.text = "Acertô miseravi!";
        }
        else
        {
            returnText.text = "Verrgonha da profissom!";
        }
    }

    void UpdadeSlider()
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

    void ResetTimer()
    {
        slider.value = 0.0f;
        stopTimer = false;
        startTimer = false;
        returnText.text = "";
        instructionText.text = "Precione ESPAÇO para iniciar!";
    }

    void DefineTarget()
    {
        targetStartPosition = Random.Range(targetMinStart, targetMaxStart);

        target.transform.localScale = new Vector3(target.transform.localScale.x / (int)dificult, 1, 1);
        target.transform.localPosition = new Vector3(targetStartPosition, 0, 0);
    }
}
