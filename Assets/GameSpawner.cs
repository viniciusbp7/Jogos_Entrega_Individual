using System.Collections;
using UnityEngine;

public class GameSpawner : MonoBehaviour
{
    [Header("Objetos para Spawnar")]
    public GameObject inimigoPrefab;
    public GameObject coletavelPrefab;

    [Header("Tempo de Spawn (Segundos)")]
    public float tempoSpawnInimigo = 2f;
    public float tempoSpawnColetavel = 3f;

    [Header("Caixa de Spawn (Limites)")]
    public float limiteXEsquerda = -8f;
    public float limiteXDireita = 8f;
    public float limiteYBaixo = -4.5f; 
    public float limiteYTopo = 4.5f;  

    void Start()
    {
        StartCoroutine(SpawnInimigosRoutine());
        StartCoroutine(SpawnColetaveisRoutine());
    }

    IEnumerator SpawnInimigosRoutine()
    {
        while (!GameControll.gameOver)
        {
            yield return new WaitForSeconds(tempoSpawnInimigo);
            float posicaoXAleatoria = Random.Range(limiteXEsquerda, limiteXDireita);
            float posicaoYAleatoria = Random.Range(limiteYBaixo, limiteYTopo);
            
            Vector2 posicaoSpawn = new Vector2(posicaoXAleatoria, posicaoYAleatoria);

            Instantiate(inimigoPrefab, posicaoSpawn, Quaternion.identity);
        }
    }

    IEnumerator SpawnColetaveisRoutine()
    {
        while (!GameControll.gameOver)
        {
            yield return new WaitForSeconds(tempoSpawnColetavel);

            float posicaoXAleatoria = Random.Range(limiteXEsquerda, limiteXDireita);
            float posicaoYAleatoria = Random.Range(limiteYBaixo, limiteYTopo);
            
            Vector2 posicaoSpawn = new Vector2(posicaoXAleatoria, posicaoYAleatoria);

            Instantiate(coletavelPrefab, posicaoSpawn, Quaternion.identity);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green; 
        float centroX = (limiteXEsquerda + limiteXDireita) / 2;
        float centroY = (limiteYBaixo + limiteYTopo) / 2;
        Vector2 centro = new Vector2(centroX, centroY);

        float largura = limiteXDireita - limiteXEsquerda;
        float altura = limiteYTopo - limiteYBaixo;
        Vector2 tamanho = new Vector2(largura, altura);

        Gizmos.DrawWireCube(centro, tamanho);
    }
}