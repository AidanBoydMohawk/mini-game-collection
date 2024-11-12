using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team02

{
    public class RandomObjects : MonoBehaviour
    {
        public GameObject[] myObjects;
        private float spawnInterval = 0.2f;
        private float timer = 0f;

        void Update()
        {
            timer += Time.deltaTime;

            if (timer >= spawnInterval)
            {
                StartCoroutine(Wait());
                timer = 0f;
            }
        }

        private IEnumerator Wait()
        {
            int randomIndex = UnityEngine.Random.Range(0, myObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(-15, 20), 25, UnityEngine.Random.Range(-15, 20));

            Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
            yield return null;
        }
    }
}


