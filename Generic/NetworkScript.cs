using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkScript : MonoBehaviour
{
    [SerializeField]
    private uint roomsize = 4;

    private string roomName;

    public GameObject Canvas;

    private NetworkManager networkManager;

    private void Awake()
    {
       Debug.Log("Awake");
       Canvas.SetActive(true);
    }

    void Start()
    {

        Debug.Log("Start");
        
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }
    }


    public void setRoomName(string _name)
    {
        roomName = _name;
        Debug.Log(roomName);
    }

    public void CreateRoom()
    {
        if (roomName != "" && roomName != null)
        {
            Debug.Log("Creating Room: " + roomName + " with room for " + roomsize + " players.");
            // Create room
            networkManager.matchMaker.CreateMatch(roomName, roomsize, true, "", "", "", 0, 0, networkManager.OnMatchCreate);
            Canvas.SetActive(false);
        }
    }

}
