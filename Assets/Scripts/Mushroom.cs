using UnityEngine;

public class Mushroom : DanoInimigo
{
    [SerializeField] private float vel;
    [SerializeField] private Transform colisorDir;
    [SerializeField] private Transform colisorEsq;
    [SerializeField] private Transform cabecaPonto;
    [SerializeField] private BoxCollider2D box2d;
    [SerializeField] private CircleCollider2D circ2d;
    [SerializeField] private LayerMask layer;
    private Rigidbody2D rb;
    private Animator anim;
    private bool parede;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //Movimentando o inimigo
        //velocity adiciona velocidade ao corpo
        rb.velocity = new Vector2(vel, rb.velocity.y);
        //Linecast desenha colisores invisiveis
        parede = Physics2D.Linecast(colisorDir.position, colisorEsq.position, layer);
        if(parede) //Se bateu na parede
        {
            //inverte a rotação do eixo X
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            vel = -vel; //Inverte a direção
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            //contact retorna um valor a partir de um ponto de contato    
            //chegando se realmente está batendo na cabeça do inimigo
            float altura = col.contacts[0].point.y - cabecaPonto.position.y;

            if(altura > 0)
            {
                //O Personagem é jogado para cima
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
                vel = 0; //Para o inimigo
                anim.SetTrigger("die"); //chama a animação de morte

                //Desabilita os colisores
                box2d.enabled = false;
                circ2d.enabled = false;
                rb.bodyType = RigidbodyType2D.Static; //Desabilita a física do corpo

                Destroy(gameObject, 0.4f); //Destroi o objeto após 1 segundo
            }else
            {
                base.OnCollisionEnter2D(col); //Acessa o script pai
            }
        }
    }
}