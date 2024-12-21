using UnityEngine;

public class Fruits : MonoBehaviour
{
    //Variaveis
    private SpriteRenderer sr;
    private CircleCollider2D circle;
    private AudioSource audio;
    public GameObject collected;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
        audio = GetComponent<AudioSource>();
    }
    //verificar se colidiu
    void OnTriggerEnter2D(Collider2D collision)
    {
        //colidiu com o player
        if (collision.gameObject.tag == "Player")
        {
            //chama o método para aparecer o valor na tela e adicionar no inventário
            collision.GetComponent<Player>().IncreaseScore();
            audio.Play(); //Tocar o som de coleta
            //desativa visualmente
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true); //ativa o objeto animação
            Destroy(gameObject, 0.3f); //Destrói o objeto depois de 0,3s
        }
    }
}