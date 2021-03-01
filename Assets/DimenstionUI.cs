using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DimenstionUI : MonoBehaviour
{
   public enum ButtonType {ResetScene,Pause,MoreForce,LessForce}
    public ButtonType buttonType;
    bool isStopped;
    public void UiPressed()
    {
        switch (buttonType) 
        {
            case ButtonType.Pause:
                if (isStopped)
                {
                    Time.timeScale = 1;
                isStopped = false;
                }
                else
                {
                    Time.timeScale = 0;
                    isStopped = true;
                }
                break;
            case ButtonType.ResetScene:
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    Time.timeScale = 1;
                break;

        }

    }

}
