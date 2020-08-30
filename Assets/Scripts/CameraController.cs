using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera camera;             //
    [SerializeField] LayerMask m_LayerMask;
    [SerializeField] float zoomOutVelocity = 5;
    float m_FieldOfView;
    bool canChangeCamera = true;

    void Start()
    {
        if(camera == null){
            camera = Camera.main;
        }
        m_FieldOfView = camera.fieldOfView;
    }

    void Update()
    {
        if(canChangeCamera){
            Vector3 mNearPlaneR = camera.ViewportToWorldPoint(new Vector3(1, 0.5f, camera.nearClipPlane));
            Vector3 mNearPlaneL = camera.ViewportToWorldPoint(new Vector3(0, 0.5f, camera.nearClipPlane));
            Vector3 mFarPlaneR = camera.ViewportToWorldPoint(new Vector3(1, 0.5f, camera.farClipPlane));
            Vector3 mFarPlaneL = camera.ViewportToWorldPoint(new Vector3(0, 0.5f, camera.farClipPlane));

            if(!Physics.Raycast(mNearPlaneR, mFarPlaneR, Mathf.Infinity, m_LayerMask)){
                m_FieldOfView = Mathf.Lerp(m_FieldOfView, m_FieldOfView + 1, Time.deltaTime * zoomOutVelocity);
                Camera.main.fieldOfView = m_FieldOfView;
            }else{
                canChangeCamera = false;
            }
        }
    }

    #if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        if(canChangeCamera){
        Vector3 mNearPlaneR = camera.ViewportToWorldPoint(new Vector3(1, 0.5f, camera.nearClipPlane));
        Vector3 mNearPlaneL = camera.ViewportToWorldPoint(new Vector3(0, 0.5f, camera.nearClipPlane));
        Vector3 mFarPlaneR = camera.ViewportToWorldPoint(new Vector3(1, 0.5f, camera.farClipPlane));
        Vector3 mFarPlaneL = camera.ViewportToWorldPoint(new Vector3(0, 0.5f, camera.farClipPlane));

        Gizmos.color = Color.white;
        //Gizmos.DrawSphere(mNearPlaneR, 0.1F);
        //Gizmos.DrawSphere(mNearPlaneL, 0.1F);
        Gizmos.DrawLine(mNearPlaneR, mFarPlaneR);
        //Gizmos.DrawSphere(mFarPlaneR, 0.1F);
        //Gizmos.DrawSphere(mFarPlaneL, 0.1F);
        Gizmos.DrawLine(mNearPlaneL, mFarPlaneL);
        }
    }
    #endif
}
