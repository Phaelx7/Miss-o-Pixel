using UnityEngine;

public class Trampolim : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private Animator anim;

    void Start() 
    {   //Procura o componente Animator anexado
        anim = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {   //Verificar se o trampolim colidiu com o Player
        if(collision.gameObject.tag == "Player")
        {   
            anim.SetTrigger("jump"); //Ativa a animação jump
            //Procura o método para adicionar força no pulo
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}