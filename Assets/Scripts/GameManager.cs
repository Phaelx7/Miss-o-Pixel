using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform point;
    void Start()
    {   //Procura na cena o objeto Player e acessa a posição e passa para o player
        FindObjectOfType<Player>().transform.position = point.position;
    }
    public static void CarregaCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }
    public void Sair()
    {
        Application.Quit();
    }
}