using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private float boxForce;
    [SerializeField] private bool isUp;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sr;
    private BoxCollider2D bx;
    public int health = 5;
    public GameObject destruicao;
    
    //Pega o componente BoxCollider2D do ponto de pulo
    void Start() { bx = GetComponent<BoxCollider2D>(); }
    void Update()
    {
        if(health <= 0)
        {
            bx.enabled = false; //Desativa o colisor da caixa
            sr.enabled = false; //Desativa a imagem da caixa

            //Instancia o objeto destruição
            //Instantiate(destruicao, transform.position, transform.rotation);
            destruicao.SetActive(true); //Ativa o objeto destruição

            //Destruir o objeto pai da caixa
            Destroy(transform.parent.gameObject, 0.3f);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {   //Verificar se a caixa colidiu com o Player
        if(collision.gameObject.tag == "Player")
        {   
            if(isUp) //Arremessar for pra cima
            {
               anim.SetTrigger("hit"); //Ativa a animação de hit
               health--;
               //Procura o método para adicionar força do arremesso
               collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, boxForce), ForceMode2D.Impulse);
            } 
            else //Arremessar for pra baixo
            {
              anim.SetTrigger("hit"); //Ativa a animação de hit
              health--;
              //Procura o método para adicionar força do arremesso
              collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -boxForce), ForceMode2D.Impulse);
            }
        }
    }
}