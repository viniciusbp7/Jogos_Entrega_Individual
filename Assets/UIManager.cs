using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;
    public AudioSource audioGameOver;
    
    private bool gameOverSoundPlayed = false;
    
    void Start()
    {
        if (endGamePanel != null)
        {
            endGamePanel.SetActive(false);
        }
    }

    void Update() 
    {
        if(GameControll.gameOver) 
        {
            endGamePanel.SetActive(true);
            
            if (!gameOverSoundPlayed && audioGameOver != null)
            {
                audioGameOver.Play();
                gameOverSoundPlayed = true;
            }
        }
    }
}