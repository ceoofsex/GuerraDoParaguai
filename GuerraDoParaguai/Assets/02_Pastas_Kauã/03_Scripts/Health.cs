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

    [Header("UI")]
    public TextMeshProUGUI healthText;

    [PunRPC]
    public void TakeDamege(int _damege)
    {
        health -= _damege;

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
