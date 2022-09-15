using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float zoomInValue;
    [SerializeField] float zoomOutValue;
    [SerializeField] float sensitivityInValue;
    [SerializeField] float sensitivityOutValue;


    CinemachineVirtualCamera virtualCamera;
    FirstPersonController controller;
    bool isZoomedIn;

    private void Awake()
    {
        controller = FindObjectOfType<FirstPersonController>();
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }

    private void OnDisable()
    {
        ChangeZoom(zoomOutValue, sensitivityOutValue);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && !isZoomedIn)
        {
            ChangeZoom(zoomInValue, sensitivityInValue);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && isZoomedIn)
        {
            ChangeZoom(zoomOutValue, sensitivityOutValue);
        }
    }

    private void ChangeZoom(float zoomValue, float mouseSensitinityValue)
    {
        controller.RotationSpeed = mouseSensitinityValue;
        virtualCamera.m_Lens.FieldOfView = zoomValue;
        isZoomedIn = !isZoomedIn;
    }


}
