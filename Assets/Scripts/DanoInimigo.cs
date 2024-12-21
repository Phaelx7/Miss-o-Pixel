using UnityEngine;

public class DanoInimigo : MonoBehaviour
{
  [SerializeField] protected int dano; //Dano que o jogador ira receber

  protected void OnTriggerEnter2D(Collider2D colidiu) //Se colidiu com um trigger
  {
    if(colidiu.tag == "Player") //Colidiu com o player
    {
        colidiu.GetComponent<Player>().Hit(dano); //Vai acessar o componente hit e aplicar o dano
    }
  }
  protected void OnCollisionEnter2D(Collision2D colidiu) //Se colidiu
  {
    if(colidiu.gameObject.CompareTag("Player")) //Colidiu com o player
    {
        colidiu.gameObject.GetComponent<Player>().Hit(dano); //Vai acessar o componente hit e aplicar o dano
    }
  }
}
//Esse é o script pai
//O dano que todos os inimigos irão dar ficarão aqui
//Classe feita para que cada inimigo/armadilha dê um dano especifico ao jogador
//Deixando assim o jogo mais dinamico

//public todos podem acessar
//private somente a classe pode acessar
//protected somente a classe ou os filhos podem acessar