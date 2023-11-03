using System;
using System.Collections;
using System.Collections.Generic;
using Model.Modules.Battle;
using Model.Modules.Location;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LocationSelectUI : MonoBehaviour
{
    #region Events
    public event Action<int> onLocationSelected = delegate {};
    #endregion

    #region Serialize Fields
    [SerializeField] private List<Button> btns;
    #endregion

    #region Private Fields
    private List<LocationData> locations;
    #endregion


    #region Public Methods
    public void init( List<LocationData> locations )
    {
        this.locations = locations;

        int btns_count_delta = locations.Count - btns.Count;
        if ( btns_count_delta > 0 )
            spawnNBattleHeroes( btns_count_delta );

        enableNBattleHeroes( locations.Count );

        for ( int i = 0; i < locations.Count; i++ )
        {
            btns[i].onClick.RemoveAllListeners();

            int idx = i;
            btns[i].onClick.AddListener( () => onLocationClicked( idx ) );

            TextMeshProUGUI btnText = btns[i].GetComponentInChildren<TextMeshProUGUI>();
            if ( btnText )
                btnText.text = idx.ToString();
        }
    }
    #endregion

    #region Private Methods
    private void spawnNBattleHeroes( int count )
    {
        for ( int i = 0; i < count; i++ )
            btns.Add( Instantiate( btns[0], btns[0].transform.parent ) );
    }

    private void enableNBattleHeroes( int count )
    {
        for ( int i = 0; i < btns.Count; i++ )
            btns[i].gameObject.SetActive( i < count );
    }

    private void onLocationClicked( int idx )
    {
        onLocationSelected( idx );
    }
    #endregion
}
