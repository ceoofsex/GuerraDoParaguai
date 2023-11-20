using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject panelOptions, panelCredits, panelStart;
    public GameObject buttonsMenu;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;

                if (hitObject.CompareTag("button_start"))
                {
                    panelStart.SetActive(true);
                    buttonsMenu.SetActive(false);
                }
                if (hitObject.CompareTag("button_options"))
                {
                
                
                    panelOptions.SetActive(true);
                    buttonsMenu.SetActive(false);
                
                }
                if (hitObject.CompareTag("button_credits"))
                {
                
                    panelCredits.SetActive(true);
                    buttonsMenu.SetActive(false);
                
                }
                if (hitObject.CompareTag("button_exit"))
                {
                    Application.Quit();
                }
                //if (hitObject.CompareTag("button_back_credits"))
                //{
                
                //    panelCredits.SetActive(false);
                //    buttonsMenu.SetActive(true);
                
                //}
            }
        }
    }
}
