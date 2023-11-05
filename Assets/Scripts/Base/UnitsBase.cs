using System.Collections.Generic;
using UnityEngine;

public class UnitsBase : MonoBehaviour
{
    [SerializeField] private List<Unit> _units = new();
    [SerializeField] private List<Unit> _freeUnits = new();

    [SerializeField] private CoinsBase _coinsBase;

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.TryGetComponent(out Unit unit))
            {
                _units.Add(unit);
            }
        }

        foreach (Unit unit in _units)
        {
            _freeUnits.Add(unit);
        }
    }

    void Update()
    {
        if (_coinsBase.ShowAmount() > 0)
        {
            CollectCoin();
        }
    }

    private void CollectCoin()
    {
        if (_freeUnits.Count > 0)
        {
            Unit currentUnit = _freeUnits[0];
            _freeUnits.Remove(_freeUnits[0]);

            Coin targetCoin = _coinsBase.TakeFirstCoin();

            currentUnit.TakeTargetCoin(targetCoin);
        }
    }

    public void AddFreeUnit(Unit unit)
    {
        if (!_freeUnits.Contains(unit))
        {
            _freeUnits.Add(unit);
        }
    }
}
