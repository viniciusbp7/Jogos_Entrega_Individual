using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEscape : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Voltando ao menu principal...");
            VoltarAoMenu();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC pressionado - Voltando ao menu...");
            VoltarAoMenu();
        }
    }
    
    void VoltarAoMenu()
    {
        SceneManager.LoadScene(0);
    }
}