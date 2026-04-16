using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    [Header("Textos da HUD")]
    public TextMeshProUGUI textoVidas;
    public TextMeshProUGUI textoColetaveis;
    
    void Update()
    {
        AtualizarHUD();
    }
    
    void AtualizarHUD()
    {
        if (textoVidas != null)
        {
            textoVidas.text = "Vidas: " + GameControll.Vidas;

        }
        
        if (textoColetaveis != null)
        {
            textoColetaveis.text = "Moédas: " + GameControll.ColetaveisColetados;

        }
    }
}