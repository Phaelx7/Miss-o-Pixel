using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //Variaveis
    [Header("Configurações")]
    [SerializeField] private Transform player;
    [SerializeField] private Mode camMode = Mode.Fixed;
    [SerializeField] private float y;
    [SerializeField] private float xMax, xMin; //Limite maximo de X da camera

    public enum Mode { Follow, Fixed } //Modo de camera escolha
    private void Update()
    {
        switch (camMode)
        {
            case Mode.Follow:
                FollowPlayer();
                break;
            case Mode.Fixed:
                FixedCamera();
                break;
            default:
                FixedCamera();
                break;
        }
    }

    private void FollowPlayer() //Mexe no x e y
    {
        //Faz a câmera seguir o jogador, mas com condições:
        //Se a posição X do jogador estiver dentro dos limites xMin e xMax, a câmera segue tanto X quanto Y.
        if(!(player.transform.position.x > xMax || player.transform.position.x < xMin)) //Se não for maior ou menor para de seguir
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
        //Caso contrario, a camera so segue a posição Y do jogador, mantendo sua posição X.
        else
        {   //Se não movimenta somente o y
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }
    }

    private void FixedCamera() //Só mexe no x
    {
        //Faz a câmera seguir o jogador apenas no eixo X enquanto mantém sua posição fixa em y
        if(!(player.transform.position.x > xMax || player.transform.position.x < xMin)) //Se não for maior ou menor para de seguir
        {
            transform.position = new Vector3(player.position.x, y, transform.position.z);
        }
    }

    public void setNewY(int newY)
    {
        y = newY;
    }

    public void setCameraMode(string mode) //Modos de camera
    {
        switch (mode)
        {
            case "Follow":
                camMode = Mode.Follow;
                break;
            case "Fixed":
                camMode = Mode.Fixed;
                break;
            default:
                camMode = Mode.Fixed;
                break;
        }
    }
}