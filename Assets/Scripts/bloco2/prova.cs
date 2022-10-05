using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class prova : MonoBehaviour
{
    public Vector3 aceleracao;
    public Vector3 velocidade;
    public Vector3 forca;
    public Vector3 diferenca;
    public Vector3 tamanhoMola = new Vector3(2.0f, 2.0f, 2.0f);
    public float k;
    public float b;
    public float mass;

    void FixedUpdate() {
        forca = (-k * (transform.position - tamanhoMola)) + (-b * velocidade);
        aceleracao = forca/mass;
        velocidade += aceleracao * Time.deltaTime;
        transform.position += velocidade * Time.deltaTime;
    }
}