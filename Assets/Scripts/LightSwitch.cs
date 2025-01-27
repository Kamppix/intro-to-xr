using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    public Light light;
    public InputActionReference inputAction;
    public List<Color> colors;

    private int currentColor = 0;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        if (colors.Count > currentColor && colors[currentColor] != null)
        {
            light.color = colors[currentColor];
        }

        inputAction.action.Enable();
        inputAction.action.performed += (ctx) =>
        {
            if (colors.Count == 0) return;
            currentColor++;
            if (currentColor >= colors.Count) currentColor = 0;
            if (colors[currentColor] != null)
            {
                light.color = colors[currentColor];
            }
        };
    }
}
