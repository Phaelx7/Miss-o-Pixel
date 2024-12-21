using UnityEngine;

public class SpikeHead : DanoInimigo //Script pai
{
    [Header("Atributos")]
    [SerializeField]private float speed;
    [SerializeField]private float distancia; //Distancia de detecção
    [SerializeField]private float checkDelay; //Delay checagem
    [SerializeField]private LayerMask playerLayer; //Mascara da layer do player
    private float checkTime; //Tempo de checagem
    private Vector3 destino; //Armazenar a posição do jogador
    private Vector3[] direcoes = new Vector3[4]; //Vetor que recebera as 4 direções
    private bool atacando = false;

    private void OnEnable() //Para ele não atacar o tempo todo
    {
        Parar();
    }
    void Update()
    {
        //Mover somente se tiver atacando
        if(atacando)
        {
            transform.Translate(destino * Time.deltaTime * speed);
        }
        else
        {
            checkTime += Time.deltaTime;
            if(checkTime > checkDelay) //Se o tempo for maior que o de delay checar a posição do Player
            {
                ChecarPlayer(); 
            }
        }
    }
    void ChecarPlayer()
    {
        CalculaDirecoes();
        //Checar se vê o player
        for(int i = 0; i < direcoes.Length; i++)
        {
            Debug.DrawRay(transform.position, direcoes[i], Color.blue); //Verificar o tamanho
            //Detectar o jogador, e confirmar que os raios colidiram
            //Apos isso irá manda-lo para a direção
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direcoes[i], distancia, playerLayer);

            if(hit.collider != null && !atacando) //Se detectou e não está atacando
            {
                atacando = true; //Ai ele começa a atacar
                destino = direcoes[i]; //Manda o player para a direção
                checkTime = 0; //Reseta o tempo de checagem
            }
        }
    }
    void CalculaDirecoes()
    {
        direcoes[0] = transform.right * distancia; //Direita
        direcoes[1] = -transform.right * distancia; //Esquerda
        direcoes[2] = transform.up * distancia; //Cima
        direcoes[3] = -transform.up * distancia; //Baixo
    }
    void Parar()
    {
        destino = transform.position; //O destino vira a posição atual
        atacando = false; //Para de atacar
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            base.OnTriggerEnter2D(col); //Acessa o script de dano
        }
        //Parar quando colidir com algo
        Parar();
    }
}