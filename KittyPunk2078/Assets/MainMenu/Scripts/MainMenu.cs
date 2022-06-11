using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    #region Public Variables

    public GameObject mainMenuContainer;

    #endregion Public Variables

    #region Private Variables

    private List<Transform> MainMenuButtons;

    #endregion Private Variables


    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in mainMenuContainer.transform)
        {
            Debug.Log(child.name);
            children.Add(child);
        }

        Debug.Log("Count: " + children.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
