using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{   
    private Rigidbody2D rb;
    public float velocidade = 5f;

    [Header("Sons")]
    public AudioSource audioColetavel;
    public AudioSource audioDano;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        AudioSource[] audios = GetComponents<AudioSource>();
        if (audios.Length >= 1) audioColetavel = audios[0];
        if (audios.Length >= 2) audioDano = audios[1];
    }

    void FixedUpdate()
    {
        if (Keyboard.current == null) return;

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(moveHorizontal, moveVertical);
        if (direction.magnitude > 0)
        {
            direction.Normalize();
        }

        Vector2 movement = direction * velocidade * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coletavel")
        {
            if (audioColetavel != null)
                audioColetavel.Play();
            
            GameControll.Coletar();
            Destroy(other.gameObject);
        }
        
        if (other.tag == "Inimigo")
        {
            if (audioDano != null)
                audioDano.Play();
            
            GameControll.PerderVida();
            Destroy(other.gameObject);
        }
    }
}