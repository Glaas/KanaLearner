using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class UIBrain : MonoBehaviour
{
    public Image displayedSymbol;

    public TMP_InputField inputField;

    public hiraganas[] kanasSO;
    public hiraganas currentSO;

    public TouchScreenKeyboard touchscreen;


    private void Start()
    {
        GrabNewSO();
        AssignNewValues();

        inputField.onSubmit.AddListener(CheckAnswer);
      //  inputField.OnSelect(TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default));
      
      
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            print("ping");
            touchscreen = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        }
    }

    public void GrabNewSO()
    {
        currentSO = kanasSO[Random.Range(0, kanasSO.Length)];
    }

    public void AssignNewValues()
    {
        displayedSymbol.sprite = currentSO.symbol;
        displayedSymbol.SetNativeSize();
    }

    public void CheckAnswer(string answer)
    {
        if (answer == currentSO.answerExpected)
        {
            print("Good job !");
            GetComponentInChildren<FeedbackText>().AssignGood();
        }
        else if (inputField.text != currentSO.answerExpected)
        {
            print("nooo u suk :(");
            GetComponentInChildren<FeedbackText>().AssignBad();
        }

        GrabNewSO();
        AssignNewValues();
        inputField.text = String.Empty;
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 50, 200, 100), "Default"))
        {
            touchscreen = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        }
    }
}