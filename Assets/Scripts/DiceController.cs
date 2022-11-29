using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private bool _isMoving;

    private void Update()
    {
        if (_isMoving) return;

        if (Input.GetKey(KeyCode.A)) Direcciones(Vector3.left);
        else if (Input.GetKey(KeyCode.D)) Direcciones(Vector3.right);
        else if (Input.GetKey(KeyCode.W)) Direcciones(Vector3.forward);
        else if (Input.GetKey(KeyCode.S)) Direcciones(Vector3.back);

        void Direcciones(Vector3 dir)
        {
            var anchor = transform.position + (Vector3.down + dir) * 0.5f; //suma de vectores
            var axis = Vector3.Cross(Vector3.up, dir); // producto cruz
            StartCoroutine(Roll(anchor, axis));
        }
    }

    private IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        _isMoving = true;
        for (var i = 0; i < 90 / _speed; i++)
        {
            transform.RotateAround(anchor, axis, _speed); //rotacion
            yield return new WaitForSeconds(0.01f);
        }
        _isMoving = false;
    }
}
