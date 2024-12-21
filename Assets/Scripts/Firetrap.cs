using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firetrap : DanoInimigo
{
  [Header("Timers")]
  [SerializeField] private float tempoAtivacao; //Quanto tempo será ativado apos tocar no player
  [SerializeField] private float duracao; //A duração que ficara ativa
  private Animator anim;
  private SpriteRenderer sprt;
  private bool acionada; //Quando a armadilha é acionada
  private bool ativada;//Quando a armadilha está ativa e pode machucar o jogador
  void Awake()
  {
   anim = GetComponent<Animator>();
   sprt = GetComponent<SpriteRenderer>();
  }
  private void OnTriggerEnter2D(Collider2D col)
  {
    if(col.CompareTag("Player"))
    {
      if(!acionada) //Se a armadilha não foi acionada
      {
        //Acionar a armadilha
        StartCoroutine(AtivarArmadilha());
      }
      if(ativada)
      {
        base.OnTriggerEnter2D(col); //Acessa o script pai
      }
    }
  } 
  private IEnumerator AtivarArmadilha()
  {
    acionada = true;
    yield return new WaitForSeconds(tempoAtivacao); //Vai esperar o tempo de ativação
    ativada = true; //vai ativar a armadilha de fogo
    anim.SetBool("ativo", true); //ativar a animação
    yield return new WaitForSeconds(duracao); //Vai esperar o tempo de duração acabar
    ativada = false;
    acionada = false;
    anim.SetBool("ativo", false); //desativar a animação
  }
}