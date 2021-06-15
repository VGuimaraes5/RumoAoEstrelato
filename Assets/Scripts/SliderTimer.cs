using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimer : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

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
    private Text returnText;

    [SerializeField]
    private Dificult dificult;
    [SerializeField]
    private Velocity velocity;

    private float gameTime;
    private bool stopTimer;
    private bool startTimer;
    private bool result;

    [SerializeField]
    private string nextScene;
    [SerializeField]
    private SceneLoader sceneLoader;


    [SerializeField]
    private Text countdownText;
    private float countdownTime = 5;
    

    void Start()
    {
        DefinirDificuldade();

        sliderTransform = slider.GetComponent<RectTransform>();
        DefineTarget();
        targetWidth /= (int)dificult;
        stopTimer = false;
        startTimer = false;
        slider.value = 0.0f;

        switch (velocity)
        {
            case Velocity.SLOW:
                gameTime = 1.6f;
                break;
            case Velocity.MEDIUM:
                gameTime = 1.2f;
                break;
            case Velocity.FAST:
                gameTime = 0.8f;
                break;
        }
        slider.maxValue = gameTime;
    }


    private void Update()
    {
        HitSpaceAction();
        Countdown();
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
            if (startTimer && !stopTimer)
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
        switch (sceneName)
        {
            case "cozinha":
                ResultStorage.resultCozinha = result;
                break;
            case "carregamento":
                ResultStorage.resultCarregamento = result;
                break;
            case "atendimento":
                ResultStorage.resultAtendimento = result;
                break;
        }
    }

    void Countdown()
    {
        if (countdownTime >= 0)
        {
            countdownTime -= Time.deltaTime;
            if (countdownTime < 4)
            {
                countdownText.text = Mathf.Floor(countdownTime).ToString("N0");
            }
        }
        else
        {
            startTimer = true;
            countdownText.text = "Precione ESPAÇO para parar!";
        }
    }

    void DefinirDificuldade()
    {
        switch (sceneName)
        {
            case "cozinha":
                if (ResultStorage.escolhaCozinha == Choises.GOOD)
                {
                    dificult = Dificult.EASY;
                    velocity = Velocity.FAST;
                }
                else if (ResultStorage.escolhaCozinha == Choises.BAD)
                {
                    dificult = Dificult.EASY;
                    velocity = Velocity.MEDIUM;
                }
                break;
            case "carregamento":
                if (ResultStorage.escolhaCarregamento == Choises.GOOD)
                {
                    dificult = Dificult.MEDIUM;
                    velocity = Velocity.FAST;
                }
                else if (ResultStorage.escolhaCarregamento == Choises.BAD)
                {
                    dificult = Dificult.MEDIUM;
                    velocity = Velocity.MEDIUM;
                }
                break;
            case "atendimento":
                if (ResultStorage.escolhaAtendimento == Choises.GOOD)
                {
                    dificult = Dificult.HARD;
                    velocity = Velocity.FAST;
                }
                else if (ResultStorage.escolhaAtendimento == Choises.BAD)
                {
                    dificult = Dificult.HARD;
                    velocity = Velocity.MEDIUM;
                }
                break;
        }
    }
}
