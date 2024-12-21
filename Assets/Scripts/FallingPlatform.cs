using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float fallingTime;
    private BoxCollider2D box;
    private Joint2D joint;
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        joint = GetComponent<TargetJoint2D>();
    }
    void Falling()
    {   //desativa os componentes
        box.enabled = false;
        joint.enabled = false;
        Destroy(gameObject, 4);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {   //colidiu com o player
        if(collision.transform.CompareTag("Player"))
        {   //Chamar o método de desativar
            Invoke("Falling", fallingTime);  
        }
    }
}