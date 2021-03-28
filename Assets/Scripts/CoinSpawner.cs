using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnObject;
    [SerializeField] private float _spawnTime;
    [SerializeField] private float _spawnXRange;

    private float _timer = 0;

    private void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= _spawnTime)
        {
            Vector3 _spawnPozition = (transform.position + new Vector3(Random.Range((_spawnXRange / 2) * -1, _spawnXRange / 2), 0, 0));
            Instantiate(_spawnObject, _spawnPozition, Quaternion.identity);
            _timer = _spawnTime -_timer;
        }
    }
}
