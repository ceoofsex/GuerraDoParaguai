using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_controller : MonoBehaviour
{
    public GameObject Canva_menu_pincipal;
    public GameObject Canva_credito;
    [SerializeField] private string game_scene;

    public void canva_para_troca_do_credito()
    {
        Canva_menu_pincipal.SetActive(false);
        Canva_credito.SetActive(true);
    }

    public void canva_para_troca_do_menu()
    {
        Canva_menu_pincipal.SetActive(true);
        Canva_credito.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(game_scene);
    }


    public void exit_game()
    {
        Application.Quit();
        print("funfou");
    }
}
