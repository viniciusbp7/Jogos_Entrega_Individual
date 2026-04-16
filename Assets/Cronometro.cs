using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{
    public TextMeshProUGUI textoTempo;
    private float tempoDecorrido = 0f;
    private bool cronometroAtivo = true;

    void Start()
    {
        if (textoTempo == null)
        {
            Debug.LogError("Texto do cronômetro não está atribuído!");
        }
    }

    void Update()
    {
        if (cronometroAtivo && !GameControll.gameOver)
        {
            tempoDecorrido += Time.deltaTime;
            AtualizarTexto();
        }
        
        if (GameControll.gameOver)
        {
            cronometroAtivo = false;
        }
    }

    void AtualizarTexto()
    {
        int minutos = Mathf.FloorToInt(tempoDecorrido / 60f);
        int segundos = Mathf.FloorToInt(tempoDecorrido % 60f);
        
        textoTempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
        public void ResetarCronometro()
    {
        tempoDecorrido = 0f;
        cronometroAtivo = true;
    }
}