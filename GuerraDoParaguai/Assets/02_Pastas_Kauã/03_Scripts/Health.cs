using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Health : MonoBehaviour
{
    
    public int health;
    public bool isLocalPlayer;

    public RectTransform healthBar;
    private float originalHealthBarSize;


    [Header("UI")]
    public TextMeshProUGUI healthText;


    private void Start()
    {
        originalHealthBarSize = healthBar.sizeDelta.x;
    }
    private void Update()
    {
        //healthBar.sizeDelta = new Vector2(originalHealthBarSize * health / 100f, healthBar.sizeDelta.y);

    }

    [PunRPC]
    public void TakeDamege(int _damege)
    {
        health -= _damege;

        healthBar.sizeDelta = new Vector2(originalHealthBarSize * health / 100f, healthBar.sizeDelta.y);


        healthText.text = health.ToString();


        if(health <= 0)
        {

            if(isLocalPlayer)
            {
                RoomManager.instance.SpawnPlayer();

                RoomManager.instance.deaths++;
                RoomManager.instance.SetHashes();
            }
                


           
            Destroy(gameObject);
        
        }
    }
    
}
