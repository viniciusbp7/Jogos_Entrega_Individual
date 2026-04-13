using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{   
    private Rigidbody2D rb;
    public float velocidade = 5f;

    AudioSource audio;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
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
            audio.Play();
            GameControll.Coletar();
            Destroy(other.gameObject);

        }
        if (other.tag == "Inimigo")
        {
            GameControll.PerderVida();
            Destroy(other.gameObject);
        }
    }
}

