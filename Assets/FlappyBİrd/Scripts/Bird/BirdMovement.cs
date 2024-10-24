using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

namespace Assets.FlappyBÝrd.Scripts.Bird
{
    public class BirdMovement : MonoBehaviour
    {
        private Rigidbody2D rgb;
        [SerializeField] private float jumpPower;
        [SerializeField] private float maxFallPower;

        private void Awake()
        {
            rgb = GetComponent<Rigidbody2D>();
            maxFallPower = -Mathf.Abs(maxFallPower);
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Jump();
            if (rgb.velocity.y < maxFallPower)
                rgb.velocity = Vector2.up * maxFallPower;
        }


        private void Jump()
        {
            rgb.velocity = Vector2.zero;

            rgb.AddForce(Vector2.up * jumpPower);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("Enemy"))
                Time.timeScale = 0;
        }
    }
}