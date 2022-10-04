using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class diatomicaDissipacao : MonoBehaviour
{
    public GameObject esfera1;
    public GameObject esfera2;
    public Vector3 relativeForceVector;
    public Vector3 accelerationVector1, accelerationVector2;
    public Vector3 velocityVector1, velocityVector2;
    public Vector3 diferenca;
    public Vector3 tamanhoMola = new Vector3(5.0f, 0.0f, 0.0f);
    public float constanteElastica = 5;
    public float massa1 = 10;
    public float massa2 = 10;
    public float resistencia = 2;
 
    // Update is called once per frame
    void FixedUpdate()
    {
        Velocidade();
        Posicao();
    }
 
    void Forca()
    {
        Vector3 zeroVector = new Vector3(0.0f, 0.0f, 0.0f);
        diferenca = esfera1.transform.position - esfera2.transform.position;
        if (diferenca.x < zeroVector.x) {
            diferenca = new Vector3(-diferenca.x, -diferenca.y, -diferenca.z);
        }
        relativeForceVector = (-constanteElastica * (diferenca - tamanhoMola)) + (-resistencia * (velocityVector2 - velocityVector1));
    }
 
    void Aceleracao()
    {
        Forca();
        if (esfera1.transform.position.x > esfera2.transform.position.x) {
            accelerationVector1 = relativeForceVector / massa1;
            accelerationVector2 = -relativeForceVector / massa2;
        } else {
            accelerationVector1 = -relativeForceVector / massa1;
            accelerationVector2 = relativeForceVector / massa2;
        }
    }
 
    void Velocidade()
    {
        Aceleracao();
        velocityVector1 += accelerationVector1 * Time.deltaTime;
        velocityVector2 += accelerationVector2 * Time.deltaTime;
    }
 
    void Posicao()
    {
        esfera1.transform.position += velocityVector1 * Time.deltaTime;
        esfera2.transform.position += velocityVector2 * Time.deltaTime;
    }
}