using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
   public void switchtogame()

   {
SceneManager.LoadScene(1);
Debug.Log("Switched To Scene 1");
   }



public void switchtoleaderboard()
   {
      SceneManager.LoadScene(2,LoadSceneMode.Additive);
      Debug.Log("Switched to Scene 2");
   }

public void closeleaderboard()
{
SceneManager.UnloadSceneAsync(2);

Debug.Log("Closed Scene 2");
}

   
}
