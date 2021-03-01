using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public enum BodyGroup { red, blue }

public class Body : MonoBehaviour
{
    [SerializeField]float scale_weight_Ratio=1;
    internal float scaleMass;
    public BodyGroup bodyGroup;
    internal bool onRope=false;

    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        scaleMass = (transform.localScale.x + transform.localScale.y + transform.localScale.z) / (3 * scale_weight_Ratio);
        Debug.Log(scaleMass);
            
    }
    public void BackToPlace()
    {
        transform.position = startPos;
    }

}
