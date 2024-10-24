using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.FlappyBÝrd.Scripts.Bird
{
    public class BirdMovement : MonoBehaviour
    {
        private Rigidbody2D rgb;
        [SerializeField] private float jumpPower;

        private void Awake()
        {
            rgb = GetComponent<Rigidbody2D>();
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Jump();
        }


        private void Jump()
        {
            rgb.velocity = Vector2.zero;

            rgb.AddForce(Vector2.up * jumpPower);
        }
    }
}