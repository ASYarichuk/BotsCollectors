using UnityEngine;

public class Unit : MonoBehaviour
{
    private CoinsBase _coinsBase;

    private UnitsBase _unitBase;

   [SerializeField] private Transform _target;

    private void Awake()
    {
        _coinsBase = GetComponentInParent<CoinsBase>();
        _unitBase = GetComponentInParent<UnitsBase>();
    }

    private void Update()
    {
        if (_target == null && transform.GetComponentInChildren<CollectCoin>())
        {
            _target = _coinsBase.transform;
        }

        if (_target == null && !transform.GetComponentInChildren<CollectCoin>())
        {
            _unitBase.AddFreeUnit(this);
        }
    }

    public void TakeTargetCoin(Coin coin)
    {
        if(coin != null)
        {
            _target = coin.transform;
            _coinsBase.Delete(coin);
        }
        else
        {
            _target = null;
        }
    }

    public Transform GiveTarget()
    {
        return _target;
    }

    public void BroughtCoin(int amountBroughtCoins)
    {
        _coinsBase.AddAvailableMoney(amountBroughtCoins);
    }
}
