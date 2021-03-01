using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagerPhase2 : MonoBehaviour
{
    bool CheckAcceleration=true;
    int PubtotalForce;

    [SerializeField] Scateboard scateboard;
    [SerializeField] TextMeshProUGUI blueForceText;
    [SerializeField] TextMeshProUGUI redForceText;
    [SerializeField] TextMeshProUGUI TotalForceText;
    [SerializeField] TextMeshProUGUI SpeedText;
    [SerializeField] TextMeshProUGUI frictionText;
    [SerializeField] TextMeshProUGUI AccelerationText;


    private void Start()
    {
        scateboard.uIManagerPhase2 = this;
        blueForceText.text = ToNutonString(0);
        if (frictionText != null)
        {
        frictionText.text = ToFrictionString(0);
        }

        TotalForceText.text = ToNutonString(0);
        SpeedText.text = ToSpeedString(0);

        if (AccelerationText != null)
        {
            StartCoroutine(SecondsCounter());  
        }
        
    }

    public void ForceUpdate(int blueForce,int redForce, int totalForce)
    {
        PubtotalForce = totalForce;
        blueForceText.text = ToKilogramsString(blueForce); 
        if(frictionText != null)
        {

        frictionText.text = ToFrictionString(Mathf.RoundToInt(scateboard.rb.drag));
        }
        TotalForceText.text = ToNutonString(totalForce);
        SpeedText.text = ToSpeedString(totalForce/100);

    }
    string ToNutonString(int Force)
    {
        return Force.ToString() + "N";
    }
    string ToKilogramsString(int Force)
    {
        return Force.ToString() + "Kg";
    }
    string ToSpeedString(int Force)
    {
        if (Force < 0)
        {
            Force *= -1;
        }
        return Force.ToString() + "mph";
    }
    string ToFrictionString(int Force)
    {
        return Force.ToString() + "Drag";
    }
    string ToAccelerationString(float Force)
    {
     
        return Force.ToString() + " /s  acceleration";
    }

    public IEnumerator SecondsCounter()
    {
        while(CheckAcceleration)
        {
            Debug.Log("In Coru");
            float currentSpeed = scateboard.rb.velocity.x;
            


            yield return new WaitForSeconds(1);
            float newSpeed = scateboard.rb.velocity.x;

            AccelerationText.text = ToAccelerationString(-(currentSpeed - newSpeed));

            yield return null;
        }




        
    }

}
