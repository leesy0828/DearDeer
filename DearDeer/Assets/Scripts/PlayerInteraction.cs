using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 1.5f; // 상호작용 최대 거리
    public Image crosshair; //크로스 헤어 이미지
    public Color normalColor = Color.white; //크로스 헤어 색상(평상시)
    public Color interactableColor = Color.green; //크로스 헤어 색상(상호작용 가능할시)
    public Material outlineMaterial;

    private Camera playerCamera; //플레이어 카메라
    private GameObject lookObject; //플레이어가 바라보는 물체
    private Material[] originalMaterials;
    private Material clonedOutlineMaterial;
    private Outline objectOutline;

    void Awake()
    {
        objectOutline = GetComponent<Outline>();
        playerCamera = GetComponentInChildren<Camera>();
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    void Update()
    {
        CheckForInteractable();
    }

    private void CheckForInteractable()
    {
        RaycastHit hit;
        // 플레이어 카메라 위치에서 Ray 발사
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionDistance))
        {
            // Ray에 맞은 Object가 "Interactable" 태그를 가지고 있는지 확인
            if (hit.collider.CompareTag("Interactable"))
            {
                // 새로운 상호작용 가능한 Object를 바라보고 있다면 업데이트
                if (lookObject != hit.collider.gameObject)
                {
                    lookObject = hit.collider.gameObject;
                    objectOutline = hit.transform.GetComponent<Outline>();
                }

                crosshair.color = interactableColor; //크로스 헤어 색상 변경
                objectOutline.enabled = true;
            }
            else
            {
                // 상호작용 불가능한 객체를 바라보고 있다면 초기화
                objectOutline.enabled = false;
                lookObject = null;
                crosshair.color = normalColor;
            }
        }
        else
        {
            // 아무것도 바라보고 있지 않아도 초기화
            objectOutline.enabled = false;
            lookObject = null;
            crosshair.color = normalColor;
        }
    }
}