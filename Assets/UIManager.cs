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


    private void Start()
    {
        rope.uIManager = this;
        blueForceText.text = ToNutonString(0);
        redForceText.text = ToNutonString(0);
        TotalForceText.text = ToNutonString(0);
        
    }

    public void ForceUpdate(int blueForce,int redForce, int totalForce)
    {
        blueForceText.text = ToNutonString(blueForce); 
        redForceText.text = ToNutonString(redForce);
        TotalForceText.text = ToNutonString(totalForce);

    }
    string ToNutonString(int Force)
    {
        return Force.ToString() + "N";
    }
}
