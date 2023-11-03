using System;
using Model.Modules.Battle;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;


public class BattleUI : MonoBehaviour
{
   #region Events
   public event Action             onBackBtn      = delegate {};
   public event Action             onNextTurn     = delegate {};
   public event Action<BattleBase> onBattleOpened = delegate {};
   #endregion

   #region Serialize Fields
   [Header( "Buttons")]
   [SerializeField] private Button btnBack;
   [SerializeField] private Button btnNextTurn;

   [Header( "Panels")]
   [SerializeField] private BattleTeamUI myTeamUI;
   [SerializeField] private BattleTeamUI enemyTeamUI;

   [SerializeField] private WinLoseUI winLoseUI;

   [Header( "Info Texts" )]
   [SerializeField] private TextMeshProUGUI txtCurTurn;
   #endregion

   #region Private Fields
   private BattleBase battleBase;
   #endregion


   #region Public Methods
   public void init( BattleBase battle_base )
   {
      battleBase = battle_base;

      winLoseUI.gameObject.SetActive( false );

      myTeamUI.init( battleBase.battleTeams[TeamID.FIRST] );
      enemyTeamUI.init( battleBase.battleTeams[TeamID.SECOND] );

      updateCurTurnText();
      initSubscriptions();

      onBattleOpened( battleBase );
   }
   #endregion

   #region Private Methods
   private void initSubscriptions()
   {
      battleBase.onBattleFinish -= onBattleFinish;
      battleBase.onBattleFinish += onBattleFinish;

      battleBase.onIteration -= onIteration;
      battleBase.onIteration += onIteration;

      btnNextTurn.onClick.RemoveAllListeners();
      btnNextTurn.onClick.AddListener( () => onNextTurn() );

      btnBack.onClick.RemoveAllListeners();
      btnBack.onClick.AddListener( onBackBtnClicked );

      winLoseUI.onBackBtn -= onBackBtnClicked;
      winLoseUI.onBackBtn += onBackBtnClicked;
   }

   private void onBattleFinish( TeamID team_id )
   {
      winLoseUI.gameObject.SetActive( true );
      winLoseUI.init( team_id == TeamID.FIRST );
   }

   private void onIteration( int _ )
   {
      updateCurTurnText();
   }

   private void onBackBtnClicked()
   {
      onBackBtn();
   }

   private void updateCurTurnText()
   {
      txtCurTurn.text = $"Cur turn: {battleBase.curTeamID.ToString()}";
   }
   #endregion
}
