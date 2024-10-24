using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.FlappyBÝrd.Scripts.Barrier
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] GameObject barrierPrefab;

        [SerializeField] private float spaceHeight;
        [SerializeField] private float nextPipeDistance;
        [SerializeField] private int pipeCount;

        [SerializeField] private List<GameObject> pipeList;


        private void Awake()
        {
            pipeList = new List<GameObject>();

            for (int i = 0; i < pipeCount; i++)
            {
                var pipe = Instantiate(barrierPrefab, Vector3.zero, Quaternion.identity);
                var pipeUp = pipe.transform.Find("Up").transform;
                var pipDown = pipe.transform.Find("Down").transform;

                pipeUp.position = new Vector3(0, pipeUp.position.y + spaceHeight / 2, 0);
                pipDown.position = new Vector3(0, pipDown.position.y - spaceHeight / 2, 0);

                pipe.transform.position = new Vector3(3 + i * nextPipeDistance, RandomPositionY(), 0);

                pipeList.Add(pipe);

            }
        }

        private float RandomPositionY() => Random.Range(-2.3f, 2.3f);

        private void SpawnAgain(GameObject obje)
        {
            if (obje != pipeList[0])
                return;

            var pipe = pipeList[0];
            pipeList.RemoveAt(0);

            pipe.transform.position = new Vector3(7, RandomPositionY(), 0);

            pipeList.Add(pipe);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("Enemy"))
                SpawnAgain(collision.transform.parent.gameObject);
        }
    }
}