using System.Collections;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

public class PokemonTextEffect : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    public float letterAppearDelay = 0.1f;

    private string originalText;
    private string currentText = "";
    private int currentLetterIndex = 0;
    private bool isAnimating = false;

    private void Start()
    {
        originalText = textMeshPro.text;
        textMeshPro.text = "";
        StartCoroutine(AnimateText());
    }

    private void Update()
    {
    }

    IEnumerator AnimateText()
    {
        isAnimating = true;
        while (currentLetterIndex < originalText.Length)
        {
            currentText += originalText[currentLetterIndex];
            textMeshPro.text = currentText;
            currentLetterIndex++;
            yield return new WaitForSeconds(letterAppearDelay);
        }
        isAnimating = false;
    }
}
