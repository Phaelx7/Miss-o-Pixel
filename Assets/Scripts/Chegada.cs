using UnityEngine;
using UnityEngine.SceneManagement;

public class Chegada : MonoBehaviour
{
    public string cena; //Para escrever qual cena que vai mudar
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {   //passa de fase
            SceneManager.LoadScene(cena);
        }
    }
}