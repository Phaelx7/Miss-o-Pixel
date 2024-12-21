using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IndioDialogo : MonoBehaviour
{
   public string cenaReferencia;
   public string[] dialogo;
   [SerializeField] private TextMeshProUGUI textoDialogo; //texto do painel
   [SerializeField] private GameObject painelTexto;
   private bool jaFalou = false;

    private void OnTriggerEnter2D(Collider2D colidiuIndio) 
    {   //Se colidiu com o player
        if(colidiuIndio.CompareTag("Player"))
        {
            Dialogo();
            jaFalou = true;
        }
    }
    public void Dialogo() //metodo de dialogo
    {
        if(jaFalou == false) //Se o jogador não tiver falado
        {
            painelTexto.SetActive(true); //Ativa a caixa
            StartCoroutine(Dialogue()); //Chama a rotina 
        }
    }
    IEnumerator Dialogue()
    {
        for(int i = 0; i < dialogo.Length; i++) //Onde vai mudar o dialogo
        {
            textoDialogo.text = dialogo[i]; //vai mudar para o dialogo na posição i
            yield return new WaitForSeconds(4f); //Esperar 5 segundos
        }
        yield return new WaitForSeconds(2f); //Espera +1 segundo antes de acabar
        painelTexto.SetActive(false); //Desativa após acabar o dialogo
    }
}
