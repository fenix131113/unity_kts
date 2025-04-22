using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pinball.Player;
using UnityEngine;
using ZenjectKT.Core;
using Random = UnityEngine.Random;

namespace Pinball.Interactable
{
    public class BonusSpawner : MonoBehaviour
    {
        [SerializeField] private float minTimeBetweenSpawn;
        [SerializeField] private float maxTimeBetweenSpawn;
        [SerializeField] private Bonus[] bonusesPrefabs;
        [SerializeField] private List<Transform> spawnPoints;

        private readonly Dictionary<Transform, Bonus> _spawnedBonuses = new();
        private readonly ObjectPool<Bonus> _bonusesPool = new();
        private Scores _scores;

        public void Construct(Scores scores) => _scores = scores;

        private void Start() => StartCoroutine(SpawnCoroutine());

        private void Spawn()
        {
            if(_spawnedBonuses.Count == spawnPoints.Count)
                return;
            
            var allowedSpawnPoints = spawnPoints.Except(_spawnedBonuses.Keys).ToList();
            var selectedPoint = allowedSpawnPoints[Random.Range(0, allowedSpawnPoints.Count)];

            var selectedBonus = _bonusesPool.Pop();

            if (!selectedBonus)
            {
                selectedBonus = Instantiate(bonusesPrefabs[Random.Range(0, bonusesPrefabs.Length)],
                    selectedPoint.position, Quaternion.identity);

                selectedBonus.InitScores(_scores);
                selectedBonus.OnBonusGained += OnBonusCollected;
            }
            
            _spawnedBonuses.Add(selectedPoint, selectedBonus);
            selectedBonus.transform.position = selectedPoint.position;
            selectedBonus.gameObject.SetActive(true);
        }

        private void OnBonusCollected(Bonus bonus)
        {
            bonus.gameObject.SetActive(false);
            _bonusesPool.Push(bonus);
            _spawnedBonuses.Remove(_spawnedBonuses.First(x => x.Value == bonus).Key);
        }

        // ReSharper disable once FunctionRecursiveOnAllPaths
        private IEnumerator SpawnCoroutine()
        {
            yield return new WaitForSeconds(Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn));

            Spawn();

            StartCoroutine(SpawnCoroutine());
        }
    }
}