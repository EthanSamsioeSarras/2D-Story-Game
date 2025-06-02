using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineVirtualCameraCode : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();

        cinemachineVirtualCamera.Follow = player.transform;

    }
}
