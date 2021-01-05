using System.Collections.Generic;
using UnityEngine;

public class ChangerStates : MonoBehaviour
{
    public List<GameObject> stateChangers = new List<GameObject>();
    public Color defaultColor;
    public Color deactivatedColor;
    
    public static ChangerStates Instance;
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one changer states in scene!");
            return;
        }
        Instance = this;
    }

    public void UpdateChangers(GameObject newState)
    {
        foreach (var stateChanger in stateChangers)
        {
            if (PlayerMovement.Instance.GetLucidityState() == newState)
            {
                stateChanger.GetComponent<SpriteRenderer>().color = deactivatedColor;
            }
            else
            {
                stateChanger.GetComponent<SpriteRenderer>().color = defaultColor;
            }
        }
    }
}
