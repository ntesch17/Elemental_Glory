using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class JoinGame : MonoBehaviour
{
    private NetworkManager networkManager;

    public GameObject Canvas;

    [SerializeField]
    private Text status;

    [SerializeField]
    private GameObject roomListItemPrefab;

    [SerializeField]
    private Transform roomListParent;

    private NetworkManager nm;

    

    List<GameObject> roomList = new List<GameObject>();

    void Start()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }

        RefreshRoomList();
    }

    public void RefreshRoomList()
    {
        ClearRoomList();
        networkManager.matchMaker.ListMatches(0, 20, "", false, 0, 0, OnMatchList);
        status.text = "Loading...";
    }

    public void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matchList)
    {
        Debug.Log("This is running");
        status.text = "";

        if (!success || matchList == null)
        {
            status.text = "Couldn't get Room List";
            return;
        }

     
        foreach (MatchInfoSnapshot match in matchList)
        {
            GameObject _roomListItemGO = Instantiate(roomListItemPrefab);
            _roomListItemGO.transform.SetParent(roomListParent);

            RoomListItem _roomListItem = _roomListItemGO.GetComponent<RoomListItem>();
            if (_roomListItem != null)
            {
                _roomListItem.Setup(match, joinRoom );
            }
          
            //that will take care of setting up the name/amount of users 
            //as well as setting up a callback function that will join the game

            roomList.Add(_roomListItemGO);

           
        }
        if (roomList.Count == 0)
        {
            status.text = "No rooms at the Moment ";
        }
    }

    void ClearRoomList()
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            Destroy(roomList[i]);
        }
        roomList.Clear();
    }

    public void joinRoom(MatchInfoSnapshot _match)
    {
        Debug.Log("Joining" + _match.name);
        networkManager.matchMaker.JoinMatch(_match.networkId, "","","",0,0, networkManager.OnMatchJoined);
        ClearRoomList();
        status.text = "Joining...";
        Canvas.SetActive(false);
    }

    
}
