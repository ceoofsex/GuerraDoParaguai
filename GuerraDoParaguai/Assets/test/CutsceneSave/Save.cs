using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    int a;
    bool b;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("a", SaveBool());
        //b = PlayerPrefs.GetInt("a") != 0;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            a = 1;
            PlayerPrefs.SetInt("a", a);
            PlayerPrefs.Save();
        }
        if (Input.GetMouseButtonDown(1) == true)
        {
            a = 0;
            PlayerPrefs.SetInt("a", a);
            PlayerPrefs.Save();
        }
        Debug.LogError(b);
        if (!b)
        {
            SceneManager.LoadScene("01_Principal_Cutscene");
            Debug.LogError("indo para a cutscene");
        }
        if (b)
        {
            SceneManager.LoadScene("Menu");
            Debug.LogError("indo para o menu");
        }

    }
    int SaveBool()
    {
        if (b)
        {
            a = 1;
        }
        else
        {
            a = 0;
        }
        return a;
    }
}
