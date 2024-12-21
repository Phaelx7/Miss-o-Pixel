using UnityEngine;

public class PlantProjectile : DanoInimigo //Script de dano
{
    [SerializeField] float speed;
    [SerializeField] float resetTime; //Tempo pra resetar
    private float lifeTime; //Tempo de vida
    public void AtivaProjetil()
    {
        lifeTime = 0; //Reseta o tempo de vida
        gameObject.SetActive(true); //Ativa
    }
    void Update()
    {
        float movement = speed * Time.deltaTime; //Velocidade de movimento
        transform.Translate(movement, 0, 0);

        lifeTime += Time.deltaTime; //Calcula o tempo de vida
        if(lifeTime > resetTime)
        {
            gameObject.SetActive(false); //Desativa
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        base.OnTriggerEnter2D(other); //Acessa o script pai
        gameObject.SetActive(false); //Se colidir desativa
    }
}