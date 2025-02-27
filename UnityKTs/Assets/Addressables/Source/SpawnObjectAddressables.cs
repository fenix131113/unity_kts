using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace Addressables.Source
{
    public class SpawnObjectAddressables : MonoBehaviour
    {
        [SerializeField] private Button spawnFirstRockButton;
        [SerializeField] private Button spawnSecondRockButton;
        [SerializeField] private Button unloadAllRocksButton;

        [SerializeField] private AssetReference spawnedFirst;
        [SerializeField] private AssetReference spawnedSecond;
        
        private AsyncOperationHandle<GameObject> _first;
        private AsyncOperationHandle<GameObject> _second;
        
        private GameObject _spawnedFirst;
        private GameObject _spawnedSecond;

        private void Start()
        {
            spawnFirstRockButton.onClick.AddListener(SpawnRock1);
            spawnSecondRockButton.onClick.AddListener(SpawnRock2);
            unloadAllRocksButton.onClick.AddListener(UnloadAllResources);
        }

        private void SpawnRock1()
        {
            if(_spawnedFirst)
                UnloadFirst();
            
            _first = UnityEngine.AddressableAssets.Addressables.LoadAssetAsync<GameObject>(spawnedFirst);

            _first.Completed += HandleOnCompleted;
            return;

            void HandleOnCompleted(AsyncOperationHandle<GameObject> obj)
            {
                if (obj.Status == AsyncOperationStatus.Succeeded)
                {
                    _spawnedFirst = Instantiate(obj.Result, Vector3.zero, Quaternion.identity);
                }
                else
                    Debug.Log("Failed to spawn rock_06");
            }
        }
        
        private void SpawnRock2()
        {
            if(_spawnedSecond)
                UnloadSecond();
            
            _second = UnityEngine.AddressableAssets.Addressables.LoadAssetAsync<GameObject>("Rock_02");

            _second.Completed += HandleOnCompleted;
            return;

            void HandleOnCompleted(AsyncOperationHandle<GameObject> obj)
            {
                if (obj.Status == AsyncOperationStatus.Succeeded)
                {
                    _spawnedSecond = Instantiate(obj.Result, Vector3.zero, Quaternion.identity);
                }
                else
                    Debug.Log("Failed to spawn rock_02");
            }
        }

        private void UnloadAllResources()
        {
            UnloadFirst();
            UnloadSecond();
        }

        private void UnloadFirst()
        {
            UnityEngine.AddressableAssets.Addressables.Release(_first);
            Destroy(_spawnedFirst);
        }

        private void UnloadSecond()
        {
            UnityEngine.AddressableAssets.Addressables.Release(_second);
            Destroy(_spawnedSecond);
        }
    }
}