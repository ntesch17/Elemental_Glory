using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

public class LeaveGame : MonoBehaviour
{
    private GameObject Canvas;
    private GameObject LobbyCanvas;
    NetworkManager networkManager;
    bool reload;
    // Start is called before the first frame update
    void Start()
    {

        Canvas = this.gameObject;
        LobbyCanvas = GameObject.Find("Lobby Canvas");
       
        networkManager = NetworkManager.singleton;
    }

    private void Update()
    {
        if (reload == true)
        {
           
           
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
           
            reload = false;
        } 
    }

    // Update is called once per frame

    public void LeaveRoom()
    {
        MatchInfo matchInfo = networkManager.matchInfo;
        networkManager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0, networkManager.OnDropConnection);
        networkManager.StopHost();
        reload = true;

        
        
      
    }
}
