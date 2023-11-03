using System.IO;
using Model.Common;
using Model.Modules;
using Model.Modules.Hero;
using UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Serialize Fields
    [Header( "References")]
    [SerializeField] public BattleController battleController;
    [SerializeField] public UIController ui;

    [Header( "Other" )]
    [SerializeField] public string staticDataLocalPath = "";
    #endregion

    #region Public Properties
    public ModulesContainer modulesContainer { get; private set; } = new ModulesContainer();
    public string           staticDataPath   => Path.Combine( Application.dataPath, staticDataLocalPath );
    #endregion


    #region Unity Methods
    private void Awake()
    {
        tryToRegisterSingleton();

        ModulesCommon.init( staticDataPath );
        initUI();
    }
    #endregion
    
    #region Private Methods
    private void initUI()
    {
        ui.battleUI.onBattleOpened += battleController.init;
        ui.battleUI.onNextTurn += battleController.doIteration;
        
        ui.init();
    }
    #endregion

    #region Singleton Logic
    public static GameManager instance
    {
        get
        {
            if ( _instance == null )
            {
                Debug.LogError( $"Please add any of {typeof(GameManager)} to Scene" );
            }

            return _instance;
        }
    }

    private static GameManager _instance = null;

    private void tryToRegisterSingleton()
    {
        if ( _instance != null )
        {
            Debug.LogError( $"Trying to register Singleton object {name} but its already exists ({instance.name}). There should be only one instance of the object on the Scene!" );
            return;
        }

        _instance = this;
    }
    #endregion
}
