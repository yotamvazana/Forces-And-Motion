using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagerPhase2 : MonoBehaviour
{
    [SerializeField] Scateboard scateboard;
    [SerializeField] TextMeshProUGUI blueForceText;
    [SerializeField] TextMeshProUGUI redForceText;
    [SerializeField] TextMeshProUGUI TotalForceText;
    [SerializeField] TextMeshProUGUI SpeedText;


    private void Start()
    {
        scateboard.uIManagerPhase2 = this;
        blueForceText.text = ToNutonString(0);
        redForceText.text = ToNutonString(0);
        TotalForceText.text = ToNutonString(0);
        SpeedText.text = ToSpeedString(0);
        
    }

    public void ForceUpdate(int blueForce,int redForce, int totalForce)
    {
        blueForceText.text = ToKilogramsString(blueForce); 
        redForceText.text = ToKilogramsString(redForce);
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
}
