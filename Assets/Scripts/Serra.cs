using UnityEngine;

public class Serra : DanoInimigo //Script pai
{
    [SerializeField] private float speed;
    [SerializeField] private float tempoMovimento;
    private bool direita = true;
    private float tempo;
    private SpriteRenderer sprite;

    void Start() { sprite = GetComponent<SpriteRenderer>();}
    void Update()
    {
        if(direita) //Verifica se está indo para a direita
        { //Move para a direita
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            sprite.flipX = false;
        }
        else
        { //Move para a esquerda
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            sprite.flipX = true;
        }
        tempo += Time.deltaTime; //O tempo de movimento vira o tempo do jogo

        if(tempo >= tempoMovimento) //Verifica se o tempo de movimento é maior ou igual ao tempo
        {
            direita = !direita; //Inverte a direção
            tempo = 0; //Zera o tempo de movimento
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        base.OnCollisionEnter2D(coll); //Chama o pai
        //Script de dano
    }
}