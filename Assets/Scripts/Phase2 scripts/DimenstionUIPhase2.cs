using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DimenstionUIPhase2 : MonoBehaviour
{
    [SerializeField] private Scateboard scateboard;
   public enum ButtonType {MoreForce,LessForce,resetScene,stop,MoreFriction,LessFriction}
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
            case ButtonType.resetScene:
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            case ButtonType.stop:
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
            case ButtonType.LessFriction:
                scateboard.rb.drag-=1; 
                break;
            case ButtonType.MoreFriction:
                scateboard.rb.drag+=1; 
                break;

        }

    }

}
