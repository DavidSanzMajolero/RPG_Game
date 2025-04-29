using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensivility;
    [SerializeField] private float aimSensivility;
    [SerializeField] private LayerMask aimmouseColliderLayerMask;
    [SerializeField] private Transform debugTransform;

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;

    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }
    private void Update()
    {
        Vector3 mouseWorldPostion = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimmouseColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPostion = raycastHit.point;
        }
        if (starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensivility(aimSensivility);
            thirdPersonController.SetRotateOnMove(false);
            Vector3 worldAimTarget = mouseWorldPostion;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensivility(normalSensivility);
            thirdPersonController.SetRotateOnMove(true);

        }

    }
}
