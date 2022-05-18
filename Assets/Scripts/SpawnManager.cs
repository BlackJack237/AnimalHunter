using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private Animal[] animals;
    [SerializeField] private float spawnTime =3f;
    [SerializeField] private float minSpeed = 2f;
    [SerializeField] private float maxSpeed = 2f;
    private float spawnTimer = 0f;

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= spawnTime)
        {
            int randomPoint = Random.Range(0, spawnPoints.Length);
            int animalCountToSpawn = Random.Range(0, animals.Length);
            float randomMoveSpeed = Random.Range(minSpeed, maxSpeed);

            Animal newAnimal = Instantiate(animals[animalCountToSpawn], spawnPoints[randomPoint].transform);
            bool moveDirection = newAnimal.transform.position.x < 0 ? false : true;

            newAnimal.GetComponent<SpriteRenderer>().flipX = moveDirection;
            newAnimal.MoveSpeed = moveDirection ? randomMoveSpeed : -1 * randomMoveSpeed;
            spawnTimer= 0f;
        }
    }
}
