using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager instance;

    public GameObject player;
    [Space]
    public Transform[] spawnPoints;

    [Space]
    public GameObject roomCam;

    [Space]
    public GameObject nameUI;
    public GameObject connectingUI;


    private string nickname = "unnamed";

    public string roomNameToJoin = "test";


    [HideInInspector]
    public int kills = 0;
    [HideInInspector]
    public int deaths = 0;

    void Awake()
    {
        instance = this;
    }

    public void ChangeNickname(string _name)
    {
        nickname = _name;
    }

    public void JoinRoomButtonPressed()
    {
        Debug.Log("Connecting...");

        PhotonNetwork.JoinOrCreateRoom(roomNameToJoin, null, null);

        nameUI.SetActive(false);
        connectingUI.SetActive(true);
    }


    // Start is called before the first frame update
    //void Start()
    //{
    //
    //}
    //public override void OnConnectedToMaster()
    //{
    //    base.OnConnectedToMaster();
    //    Debug.Log("Connected to Server");
    //    PhotonNetwork.JoinLobby();
    //    
    //    
    //}
    //public override void OnJoinedLobby()
    //{
    //    base.OnJoinedLobby();
    //    Debug.Log("We're in the lobby");
    //    PhotonNetwork.JoinOrCreateRoom(roomNameToJoin, null, null);
    //}
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("We're connected and in a room now");

        roomCam.SetActive(false);

        SpawnPlayer(); 

    }


    public void SpawnPlayer()
    {
        Transform spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];

        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
        
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        _player.GetComponent<Health>().isLocalPlayer = true;

        _player.GetComponent<PhotonView>().RPC("SetNickname", RpcTarget.AllBuffered, nickname);
        PhotonNetwork.LocalPlayer.NickName = nickname;

    }

    public void SetHashes()
    {
        try
        {
            Hashtable hash = PhotonNetwork.LocalPlayer.CustomProperties;
            hash["kills"] = kills;
            hash["deaths"] = deaths;

            PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        }
        catch
        {

        }
    }



}
