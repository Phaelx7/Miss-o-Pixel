using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Variaveis
    [Header("Atributos")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private int HP;
    [SerializeField] private int frutas;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI coletavelText;
    [SerializeField] private TextMeshProUGUI vidaText;
    [SerializeField] private GameObject perdeu;

    [Header("Componentes")]
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 direction;
    private bool isGround, recovery;
    private bool noVento;

    void Start()
    {
        //a variavel rb vai receber o componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        vidaText.text = HP.ToString(); //pego a vida e transformo em texto
        Time.timeScale = 1; //Passa o tempo padrão
        //DontDestroyOnLoad(gameObject); //Ao carregar uma nova cena o player não é destruído
    }
    void Update()
    {
        //Direções a movimentar WASD - SETAS - ANALOGICO
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Jump();
        Animacoes();
    }
    void FixedUpdate()
    {
        Movement();
    }
    //Mover
    void Movement() 
    {   
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }
    //Pular
    void Jump()
    {   //se ao pressionar a tecla espaço e estiver no chão
        if(Input.GetButtonDown("Jump") && isGround == true && noVento == false)
        {   //adiciona uma força de impulsão
            gameObject.transform.parent = null; // Para pular e não seguir a plataforma
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGround = false; //estou no ar
            //adicionar animação pular
            anim.SetBool("jump", true);
        }
    }
    //Animações do Personagem
    void Animacoes()
    {   //se estiver indo para a direita
        if(direction.x > 0 )
        {
            if (isGround) //se está no chão
            {
                //Ativar correr
                anim.SetBool("run", true);
            }
            transform.eulerAngles = Vector2.zero;
        }
        //se estiver indo para a esquerda
        if (direction.x < 0)
        {
            if (isGround) //se está no chão
            {
                //Ativar correr
                anim.SetBool("run", true);
            } 
            transform.eulerAngles = new Vector2(0f,180f); //rotacionar 180°
        }
        //se estiver parado
        if (direction.x == 0)
        {   
            if(isGround) //se está no chão
            {   //modo idle
                anim.SetBool("idle", true);
                anim.SetBool("run", false);
                anim.SetBool("jump", false);
            }
        }
    }
    //Morrer
    public void Death()
    {   //se sua vida for menor ou igual a zero
        if(HP <= 0)
        {
            perdeu.SetActive(true); //Aba game over ativa
            Time.timeScale = 0; //Pausar o jogo
        }
    }
    //Pontuação
    public void IncreaseScore() 
    {
        frutas++; //aumenta a quantidade de frutas
        coletavelText.text = frutas.ToString(); //pega o texto e coloca a quantidade de frutas
    }
    //Tomou hit
    public void Hit(int dano)
    { 
        if(recovery == false) //tempo de recuperação desativado
        {
            StartCoroutine(Flick(dano));
        }
    }
    //Corrotina
    IEnumerator Flick(int dano)
    {
        recovery = true; //tempo de recuperação
        HP -= dano; //Vai perder vida
        Death(); //chama o método perdeu
        vidaText.text = HP.ToString(); //mudar o valor no canvas
        //ativar animação de hit
        anim.SetBool("hit", true);
        yield return new WaitForSeconds(1f); //esperar 1 segundo
        anim.SetBool("hit", false); //desativa após o tempo
        recovery = false;
    }
    //Verificar se o personagem colidiu com alguma coisa
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            isGround = true; //estou no chão
            anim.SetBool("jump", false); //desativa pulo
        }
        if(collision.gameObject.CompareTag("Plataforma")) //Se está colidindo com a plataforma
        {
            gameObject.transform.parent = collision.transform; 
            //Se colidiu irá pegar o transform e mandará para o player,
            //O que fará ele seguir
        }
        else
        {
            gameObject.transform.parent = null;
        }
    }
    //O OnTriggerStay ele funciona quando o objeto está em constante contato com outro objeto
    //O OnTriggerEnter ele é chamado somente uma vez quando o objeto entra em contato com outro
    //O OnTriggerExit ele é chamado somente uma vez quando o objeto sai de contato com outro
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.layer == 7) //Se colidiu na layer do ventilador
        {
            noVento = true; //estou no vento
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == 7) //Se colidiu na layer do ventilador
        {
            noVento = false; //Sai do vento
        }
        if(col.gameObject.CompareTag("Plataforma"))
        {
            //Null significa que não ta atribuindo nada
            gameObject.transform.parent = null; //Ao sair voltará para o estado padrão
        }
    }
    //Reiniciar o jogo
    public void RestartGame()
    {   //Carrega a cena ativa
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}