using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TxtSlowCharacter : MonoBehaviour
{
    TMP_Text txt;
    public float speed = 1;
    string tmpString;
    // Start is called before the first frame update
    void Awake()
    {
        txt = GetComponent<TMP_Text>();
        tmpString = txt.text;
    }
    private void OnEnable()
    {
        StartCoroutine(FlowText());
    }

    IEnumerator FlowText()
    {
        int stringTurn = -1;
        txt.enabled = true;
        txt.text = "";
        while (stringTurn < tmpString.Length)
        {
            stringTurn++;
            if (stringTurn < tmpString.Length)
               txt.text = txt.text + tmpString[stringTurn];
            yield return new WaitForSeconds(speed/10);
        }
        yield break;

    }
}