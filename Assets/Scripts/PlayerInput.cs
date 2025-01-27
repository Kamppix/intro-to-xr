using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public InputActionReference quitAction;
    public InputActionReference teleportAction;
    public List<GameObject> viewPositions;

    private int currentPosition = 0;

    // Start is called before the first frame update
    void Start()
    {
        quitAction.action.Enable();
        quitAction.action.performed += (ctx) =>
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        };
        
        teleportAction.action.Enable();
        teleportAction.action.performed += (ctx) =>
        {
            if (viewPositions.Count == 0) return;
            currentPosition++;
            if (currentPosition >= viewPositions.Count) currentPosition = 0;
            if (viewPositions[currentPosition] != null)
            {
                transform.position = viewPositions[currentPosition].transform.position;
            }
        };
    }
}
