using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class test : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public string fullText;
    public float delayBetweenLetters = 0.1f;

    private string currentText = "";
    private int textIndex = 0;

    private void Start()
    {
        StartCoroutine(ShowTextGradually());
    }
    private void Update()
    {

    }

    private IEnumerator ShowTextGradually()
    {
        while (textIndex < fullText.Length)
        {
            currentText += fullText[textIndex];
            textMeshPro.text = currentText;

            textIndex++;

            yield return new WaitForSeconds(delayBetweenLetters);
        }
    }
}
