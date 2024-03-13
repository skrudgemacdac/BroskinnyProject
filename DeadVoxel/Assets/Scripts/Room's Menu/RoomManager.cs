using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;
using System.IO;
using TMPro;
using Cinemachine;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;

    private Unit _playerUnit;

    //[SerializeField] private CinemachineVirtualCamera _virtualCamera;

    //[SerializeField] private Transform _leftLeg;
    //[SerializeField] private Transform _rightLeg;
    //[SerializeField] private Transform _rightHand;
    //[SerializeField] private Transform _leftHand;

    private Flash _flash;

    [SerializeField] private TMP_Text _txt;

    [SerializeField] private GameObject _flashOnTxt;

    [SerializeField] private int _Energy;

    [SerializeField] private bool _onLight;

    [SerializeField] private GameObject _startTxt;

    private void Awake()
    {
        if (Instance) 
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;  
    }

    public override void OnEnable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.buildIndex == 1) 
        {
            //GameObject playerObject = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Broskinny_pelvisV2 1"), new Vector3(0, 2, 0), Quaternion.identity);


            //Quaternion rotation = Quaternion.Euler(85, 0, 0);

            //GameObject virtualCamera = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "CM vcam1"), new Vector3(0, 15, 0), rotation);

            //_virtualCamera = virtualCamera.GetComponent<CinemachineVirtualCamera>();

            //_playerUnit = playerObject.GetComponent<Unit>();

            //_playerUnit.LeftLeg.Target = _leftLeg;
            //_playerUnit.RightLeg.Target = _rightLeg;
            //_playerUnit.LeftHand.Target = _leftHand;
            //_playerUnit.RightHand.Target = _rightHand;

            //_flash = playerObject.GetComponent<Flash>();
            //_flash.Txt = _txt;
            //_flash.StartTxt = _startTxt;
            //_flash.FlashOnTxt = _flashOnTxt;
            //_flash.Energy = _Energy;
            //_flash.OnLight = _onLight;
        }
    }

    public override void OnDisable()
    { 
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


}
