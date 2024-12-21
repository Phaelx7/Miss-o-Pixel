using UnityEngine;

public class MovelPlatform : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.5f; //velocidade da plataforma

    [Header("Tipo de Plataforma")]
    [SerializeField] private bool plataformaSubindo = false; //Para saber o tipo da plataforma
    [SerializeField] private bool direita = true; //verificar se esta indo para a direita
    [SerializeField] private bool cima = true; //verificar se esta indo para cima
    
    [Header("Posição no Mundo")]
    [SerializeField] private float positionDir; //Limite direita
    [SerializeField] private float positionEsq; //Limite esquerda
    [SerializeField] private float positionCima; //Limite em cima
    [SerializeField] private float positionBaixo; //Limite em baixo
    private SpriteRenderer sprite;

    void Start() { sprite = GetComponent<SpriteRenderer>();}
    void Update()
    {
       if(!plataformaSubindo)
       {
            MovimentoLateral(); //Chamar a movimentação lateral
       }
       else
       {
            MovimentoVertical(); //Chamar a movimentação vertical
       }
    }
    void MovimentoLateral()
    {
        if(transform.position.x > positionDir) //Se for maior é pra mudar pra esquerda
        {
            direita = false;
        } 
        else if(transform.position.x < positionEsq) //Se não muda pra direita
        {
            direita = true;
        }
        if(direita) //Mover para direita
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            sprite.flipX = false;
        }
        else //Mover para esquerda
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            sprite.flipX = true;
        }
    }
    void MovimentoVertical()
    {
        if(transform.position.y > positionCima) //Se for maior é pra mudar pra esquerda
        {
            cima = false;
        } 
        else if(transform.position.y < positionBaixo) //Se não muda pra direita
        {
            cima = true;
        }
        if(cima) //Mover para direita
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        else //Mover para esquerda
        {
            transform.Translate(Vector2.up * -moveSpeed * Time.deltaTime);
        }
    }
}