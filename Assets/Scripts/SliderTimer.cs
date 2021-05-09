using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimer : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    private RectTransform sliderTransform;

    [SerializeField]
    private GameObject target;
    private float targetStartPosition;
    private float targetWidth = 50.0f;
    private float targetMinStart = 200.0f;
    private float targetMaxStart = 350.0f;

    [SerializeField]
    private Text instructionText;
    [SerializeField]
    private Text returnText;

    [SerializeField]
    private Dificult dificult;

    [SerializeField]
    private float gameTime;
    private bool stopTimer;
    private bool startTimer;
    private bool result;

    [SerializeField]
    private string nextScene;
    [SerializeField]
    private SceneLoader sceneLoader;


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
                StartCoroutine(FinishLevel());
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
            } 
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

    void DefineTarget()
    {
        targetStartPosition = Random.Range(targetMinStart, targetMaxStart);

        target.transform.localScale = new Vector3(target.transform.localScale.x / (int)dificult, 1, 1);
        target.transform.localPosition = new Vector3(targetStartPosition, 0, 0);
    }

    IEnumerator FinishLevel()
    {
        VerifyResult();
        SaveResult();
        yield return new WaitForSeconds(2f);
        sceneLoader.Transition(nextScene);
    }

    void VerifyResult()
    {
        float pointerPosition = (slider.value * sliderTransform.sizeDelta.x) / slider.maxValue;
        result = (pointerPosition >= targetStartPosition && pointerPosition <= (targetStartPosition + targetWidth));
    }

    void SaveResult()
    {
        ResultStorage.lastResult = result;
    }
}
