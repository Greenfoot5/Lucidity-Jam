using UnityEngine;

public class StateChanger : MonoBehaviour
{
    public GameObject newState;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().SetLucidityState(newState);
            ChangerStates.Instance.UpdateChangers();
        }
    }
}
