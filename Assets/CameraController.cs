using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
   [SerializeField] TransfersManager transfersManager;


    [SerializeField] float sensitivity;
    [SerializeField] float smoothing;
    Camera viewCam; 

    private Vector2 smoothedVelocity;
    private Vector2 currentLookingPos;


    [SerializeField] int interractRange;
    [SerializeField] LayerMask targetLayer;
    void Start()
    {
       
       Cursor.lockState = CursorLockMode.Locked;
        viewCam = GetComponent<Camera>();
    }

    void Update()
    {
        RotateCamera();
        if (Input.GetMouseButtonDown(0))
        {
            Interract();
        }

    }
  
    
    private void RotateCamera()
    {
        Vector2 values = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        values = Vector2.Scale(values, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x, values.x, 1f / smoothing);
        smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, values.y, 1f / smoothing);

        currentLookingPos += smoothedVelocity;

        transform.rotation = Quaternion.Euler(Mathf.Clamp(-currentLookingPos.y, -10, 45), Mathf.Clamp(currentLookingPos.x,-50, 50), transform.rotation.z);

        
    }

    public void Interract()
    {
        if (Physics.Raycast(viewCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), out RaycastHit hit, interractRange, targetLayer))
        {
            if (hit.collider.GetComponent<SceneReset>() != null)
            {
                hit.collider.GetComponent<SceneReset>().ResetScene();
            }
            else
            {
            transfersManager.BodyClicked(hit.collider.GetComponent<Body>());
            }
        }

    }
    public bool AbleToInterract()
    {
        return Physics.Raycast(viewCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), interractRange, targetLayer);
    }
}