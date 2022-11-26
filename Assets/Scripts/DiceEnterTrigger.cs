using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceEnterTrigger : MonoBehaviour
{
    public int value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dice")
        {
            ScoreManager._score -= (value * FaceValue._valor);
            Destroy(gameObject);
        }
    }
}
