using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.FlappyBÝrd.Scripts.Barrier
{
    public class PipeMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }
}