using System;
using Model.Modules.Battle;
using UnityEngine;


public class BattleController : MonoBehaviour
{
    #region Events
    public event Action<BattleBase> onBattleStarted = delegate {};
    #endregion

    #region Private Fields
    private BattleBase battleBase;
    #endregion


    #region Public Methods
    public void init( BattleBase battle_base )
    {
        this.battleBase = battle_base;

        onBattleStarted( battle_base );
    }

    public void doIteration()
    {
        if ( battleBase == null )
        {
            Debug.LogError( "There is no battle at the moment" );
            return;
        }

        battleBase.doIteration();
    }
    #endregion
}
