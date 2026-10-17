using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
      
    public void onStartclick()
    {
       SceneManager.LoadScene("Scene 1.0");
    }

}