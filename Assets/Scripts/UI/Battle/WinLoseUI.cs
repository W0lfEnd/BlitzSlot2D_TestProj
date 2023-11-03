using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class WinLoseUI : MonoBehaviour
{
    #region Events
    public event Action onBackBtn = delegate {};
    #endregion

    #region Serialize Fields
    [SerializeField] private Button          btnBack;
    [SerializeField] private TextMeshProUGUI txtInfo;
    #endregion


    #region Public Methods
    public void init( bool is_win )
    {
        btnBack.onClick.RemoveAllListeners();
        btnBack.onClick.AddListener( () => onBackBtn() );

        txtInfo.text = is_win ? "You WIN :)" : "You LOSE :(";
    }
    #endregion
}
