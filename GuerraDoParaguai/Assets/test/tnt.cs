using System.Collections;
using UnityEngine;

public class Tnt : MonoBehaviour
{
    public int tntLife = 2;
    public GameObject explosionTNT;
    public GameObject gameObjectTNT;
    // Start is called before the first frame update
    void Start()
    {
        explosionTNT.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Esplosion();
    }
    void Esplosion()
    {
        Debug.LogError(tntLife);
        if (tntLife <= 0)
        {
            explosionTNT.SetActive(true);
            StartCoroutine(EsplosionStart());
            StartCoroutine(SpawnTNT());
        }
    }
    IEnumerator EsplosionStart()
    {
        gameObjectTNT.SetActive(false);
        Debug.Log("Aguardando 2 segundo...");
        yield return new WaitForSeconds(2f);
        Debug.Log("Aguardou 2 segundo!");

        explosionTNT.SetActive(false);



    }
    IEnumerator SpawnTNT()
    {
        yield return new WaitForSeconds(5f);
        gameObjectTNT.SetActive(true);
        tntLife = 2;
    }
    private void OnTriggerStay(Collider other)
    {
        if (tntLife == 0)
        {

        }
    }
}