using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update

    public void Restart()
    {

        SceneManager.LoadScene(0);
    }
    public void LoadBeta()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadGreek()
    {
       
        SceneManager.LoadScene(2);
    }
    public void LoadMedeival()
    {
        
        SceneManager.LoadScene(4);
    }
    public void LoadUndead()
    {

        SceneManager.LoadScene(3);
    }
    public void LoadEgypt()
    {
      
        //SceneManager.LoadScene(4);
    }
    
    public void credits()
    {
        Application.OpenURL("https://sites.google.com/view/flcccapstone2019/home");
    }
}
