using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomListItem : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    public RoomInfo roomInfo;

    public void SetUp(RoomInfo _roomInfo) 
    {
        roomInfo = _roomInfo;
        text.text = _roomInfo.Name;
    }

    public void OnClick() 
    {
        Connection.Instance.JoinRoom(roomInfo);
    }
}
