using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PosCutscene : MonoBehaviour
{
    public string nomeDaCena;

    void OnEnable()
    {
        SceneManager.LoadScene(nomeDaCena);
        print("funcionou");
    }
}
