using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class MainMenu : MonoBehaviour
{

    #region Public Variables

    /// <summary>
    /// 
    /// </summary>
    public GameObject mainMenuContainer;

    #endregion Public Variables

    #region Private Variables

    /// <summary>
    /// 
    /// </summary>
    private List<Transform> _mainMenuButtons;

    /// <summary>
    /// 
    /// </summary>
    private List<Transform> _optionsMenuButtons;

    /// <summary>
    /// 
    /// </summary>
    private int _index;

    /// <summary>
    /// 
    /// </summary>
    private int _maxIndex;

    #endregion Private Variables

    // Start is called before the first frame update
    void Start()
    {
        _mainMenuButtons = new List<Transform>();
        _optionsMenuButtons = new List<Transform>();

        InitMenuButtonList(mainMenuContainer, _mainMenuButtons);

        _maxIndex = _mainMenuButtons.Count - 1;
    }

    // Update is called once per frame
    void Update()
    {
        Navigate();

        switch (_index)
        {
            case 0:
                // New game
                break;
            case 1:
                // Options
                break;
            case 2:
                // Leave
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Navigate()
    {
        if (Input.GetAxis("Vertical") < 0)
        {
            if (_index < _maxIndex)
            {
                _index++;
            }
            else
            {
                _index = 0;
            }
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            if (_index > 0)
            {
                _index--;
            }
            else
            {
                _index = _maxIndex;
            }
        }
    }

    #region Private Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="MenuContainer"></param>
    /// <param name="ToFilledList"></param>
    private static void InitMenuButtonList(GameObject MenuContainer, List<Transform> ToFilledList)
    {
        if (MenuContainer is null) throw new ArgumentNullException(nameof(MenuContainer));
        if (ToFilledList is null) throw new ArgumentNullException(nameof(ToFilledList));

        ToFilledList.AddRange(MenuContainer.transform.Cast<Transform>().Where(child => child.name.Contains("Button")));

        Debug.Log("Count: " + ToFilledList.Count);
    }

    #endregion Private Methods
}
