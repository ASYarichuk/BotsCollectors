using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] CoinCreator _coincreator;

    private float _speedRotation = 200f;

    private void Update()
    {
        transform.Rotate(Vector3.right * _speedRotation * Time.deltaTime);
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.GetComponent<Base>())
        {
            _coincreator.MoveCoin();
        }
    }
}
