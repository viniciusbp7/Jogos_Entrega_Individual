using UnityEngine;

public class GameControll
{
    private static int coletaveisColetados;
    private static int vidasPlayer;

    public static bool gameOver
    {
        get {return vidasPlayer <= 0;}
    }
    
    public static int Vidas
    {
        get { return vidasPlayer; }
    }
    
    public static int ColetaveisColetados
    {
        get { return coletaveisColetados; }
    }
    
    public static void Init()
    {
        coletaveisColetados = 0;
        vidasPlayer = 3;
    }
    
    public static void Coletar()
    {
        coletaveisColetados++;
    }
    
    public static void PerderVida()
    {
        vidasPlayer--;
    }
}