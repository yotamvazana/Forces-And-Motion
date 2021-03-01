using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DimenstionUIPhase2 : MonoBehaviour
{
    [SerializeField] private Scateboard scateboard;
   public enum ButtonType {MoreForce,LessForce}
    public ButtonType buttonType;
    bool isStopped;
    public void UiPressed()
    {
        switch (buttonType) 
        {
            case ButtonType.MoreForce:
                scateboard.force += 0.5f;
                break;
            case ButtonType.LessForce:
                scateboard.force -= 0.5f;
                break;

        }

    }

}
