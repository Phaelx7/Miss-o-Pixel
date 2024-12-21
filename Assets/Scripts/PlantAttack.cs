using UnityEngine;

public class PlantAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown; //Tempo de ataque
    [SerializeField] private Transform firePoint; //Local de disparo
    [SerializeField] private GameObject[] bulletPlant; //Bala
    private float cooldownTime; //Tempo de espera
    private Animator anim;

    void Start() { anim = GetComponent<Animator>(); }
    private void Attack()
    {
        cooldownTime = 0; //Zera o tempo de espera
        anim.SetTrigger("atirando"); //Toca a animação de atirar

        bulletPlant[FindBullet()].transform.position = firePoint.position; //Mandar a bala para o local de disparo
        bulletPlant[FindBullet()].GetComponent<PlantProjectile>().AtivaProjetil(); //Pegar a direção do projetil
    }
    private int FindBullet()
    { //Ira procurar todas as balas e a que não estiver ativa retornara
        for(int i = 0; i < bulletPlant.Length; i++)
        {
            if(!bulletPlant[i].activeInHierarchy) //Não ta ativa na hierarquia
            {
                return i; //Usa a bola inativa
            }
        }
        return 0; //Se não usa a primeira
    }
    private void Update()
    {
        cooldownTime += Time.deltaTime; //Aumenta o tempo de espera
        //Se o tempo de espera for maior que o de ataque
        if(cooldownTime > attackCooldown)
        { //Ele chama o metodo de atacar
            Attack();
        }
    }
}