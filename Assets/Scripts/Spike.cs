using UnityEngine;

public class Spike : DanoInimigo //Script pai
{
    //verificar se colidiu
    void OnTriggerEnter2D(Collider2D collision)
    {   //colidiu com o player
        if(collision.CompareTag("Player"))
        {
            //Chama o metodo de dano do player
            base.OnTriggerEnter2D(collision); //Acessa o script de dano
            collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 12f, ForceMode2D.Impulse);
            //Jogar o player para cima
        }
    }
}