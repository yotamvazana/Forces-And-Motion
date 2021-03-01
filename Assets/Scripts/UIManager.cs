using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] Rope rope;
    [SerializeField] TextMeshProUGUI blueForceText;
    [SerializeField] TextMeshProUGUI redForceText;
    [SerializeField] TextMeshProUGUI TotalForceText;
    [SerializeField] TextMeshProUGUI SpeedText;


    private void Start()
    {
        rope.uIManager = this;
        blueForceText.text = ToNutonString(0);
        redForceText.text = ToNutonString(0);
        TotalForceText.text = ToNutonString(0);
        SpeedText.text = ToSpeedString(0);
        
    }

    public void ForceUpdate(int blueForce,int redForce, int totalForce)
    {
        blueForceText.text = ToNutonString(blueForce); 
        redForceText.text = ToNutonString(redForce);
        TotalForceText.text = ToNutonString(totalForce);
        SpeedText.text = ToSpeedString(totalForce/100);

    }
    string ToNutonString(int Force)
    {
        return Force.ToString() + "N";
    }
    string ToSpeedString(int Force)
    {
        if (Force > 0)
        {
            Force *= -1;
        }
        return Force.ToString() + "mph";
    }
}
