using System.Collections;
using UnityEngine;

public class CoinCreator : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    private int _mapSizeMinX = -64;
    private int _mapSizeMaxX = 107;
    private int _mapSizeMinZ = -10;
    private int _mapSizeMaxZ = 55;
    private int _positionCoinY = 2;
    private int _amountCoins = 10;

    private float _waitUntilCreate = 3f;

    private void Start()
    {
        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        var waitUntilCreateCoins = new WaitForSeconds(_waitUntilCreate);

        while (_amountCoins > 0)
        {
            Instantiate(_coinPrefab, new Vector3(Random.Range(_mapSizeMinX, _mapSizeMaxX), _positionCoinY, Random.Range(_mapSizeMinZ, _mapSizeMaxZ)), Quaternion.Euler(0, 0, 90));

            _amountCoins--;

            yield return waitUntilCreateCoins;
        }
    }

    public void MoveCoin()
    {
        transform.position = new Vector3(Random.Range(_mapSizeMinX, _mapSizeMaxX), _positionCoinY, Random.Range(_mapSizeMinZ, _mapSizeMaxZ));
    }
}
