using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferPhase2 : MonoBehaviour
{
    internal Scateboard rope;
    [SerializeField] List<Body> bodysList = new List<Body>();
    private void Start()
    {
        rope = GetComponentInChildren<Scateboard>();
    }
    public void BodyClicked(Body body)
    {
        if (!body.onRope)
        {
        rope.AddBodyToRope(body.bodyGroup, body);
        body.onRope = true;
        }
        else
        {
            rope.RemoveBodyFromRope(body);
             body.onRope = false;
        }

    }


}
