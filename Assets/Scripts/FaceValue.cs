using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public enum Caras
{
    Uno = 1,
    Dos = 2,
    Tres = 3,
    Cuatro = 4,
    Cinco = 5,
    Seis = 6
}

public class FaceValue : MonoBehaviour
{
    public Caras resultados;
    public int vectorCara;
    public Vector3[] vectorUnitario; //Los vectores que se utilizan son los vectores unitarios correspondientes a cada cara
    public Caras[] caras;
    public static int _numVal;
    public TextMeshProUGUI valorCaras;
    public static int _valor;
    public GameObject gameOver;

    private void Start()
    {

    }

    void Update()
    {
        float maxProd = -1; //con el -1 se indica que el producto punto y el vector resultante se encuentra en la direccion opuesta
        for (int i = 0; i < vectorUnitario.Length; ++i)
        {
            var vectores = vectorUnitario[i];
            var worldVector = this.transform.localToWorldMatrix.MultiplyVector(vectores); //se pasa a una matriz global desde un punto local
            float productoP = Vector3.Dot(worldVector, Vector3.up);
            if (productoP > maxProd)
            {
                maxProd = productoP; //el maximo productor punto es el vector con la mayor direccion en y, por lo tanto, es la cara esperada
                vectorCara = i;
            }
        }
        resultados = caras[vectorCara];
        _valor = Convert.ToInt32(resultados);
        valorCaras.text = _valor.ToString();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (var vectores in vectorUnitario)
        {
            var worldVector = this.transform.localToWorldMatrix.MultiplyVector(vectores);
            Gizmos.DrawLine(this.transform.position, this.transform.position + worldVector);
        }
    }
}

