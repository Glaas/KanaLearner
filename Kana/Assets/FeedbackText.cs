using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeedbackText : MonoBehaviour
{
    public enum Kind
    {
        GOOD,
        BAD
    }

    public Kind thisKind;

    public TextMeshProUGUI textMesh;


    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = String.Empty;

    }

    public void AssignGood()
    {
        thisKind = Kind.GOOD;
        RefreshValues();
    }

    public void AssignBad()
    {
        thisKind = Kind.BAD;
        RefreshValues();
    }

    private void RefreshValues()
    {
        switch (thisKind)
        {
            case Kind.GOOD:
                textMesh.color = Color.green;
                textMesh.text = "Yass king ♥";
                break;
            case Kind.BAD:
                textMesh.color = Color.red;
                textMesh.text = "No :( Answer was " + FindObjectOfType<UIBrain>().currentSO.answerExpected;
                break;
        }

        StartCoroutine(ResetValues());
    }

    public IEnumerator ResetValues()
    {
        yield return new WaitForSeconds(1.5f);
        textMesh.text = String.Empty;
    }
}