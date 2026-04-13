using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;
    
    void Start()
    {
    }

    void FixedUpdate()
    {

        if(GameControll.gameOver) 
        {
            endGamePanel.SetActive(true);
        }
    }
}