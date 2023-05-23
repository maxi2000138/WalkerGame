using System;
using Data.TypeIds;
using Enemy;
using Infrastructure.Services;
using Inventory.Model;
using UnityEngine;
using Random = System.Random;

public class LootSpawner : MonoBehaviour
{
    [SerializeField] private EnemyDeath _enemyDeath;
    private GameFactory _gameFactory;

    public void Construct(GameFactory gameFactory)
    {
        _gameFactory = gameFactory;
    }

    private void OnEnable()
    {
        _enemyDeath.Happened += SpawnLoot;
    }

    private void OnDisable()
    {
        _enemyDeath.Happened -= SpawnLoot;
    }

    private void SpawnLoot()
    {
        Random random = new Random();
        random.Next();
        int len = Enum.GetNames(typeof(LootTypeId)).Length;
        GameObject lootObject = _gameFactory.CreateLootGameObject((LootTypeId)random.Next(0, len), transform);
    }
}
