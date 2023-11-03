using System.Collections;
using Model.Modules.Battle;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace UI
{

  public class BattleHeroUI : MonoBehaviour
  {
    #region Serialize Fields
    [SerializeField] private Image           image     = null;
    [SerializeField] private Slider          hpBar     = null;
    [SerializeField] private TextMeshProUGUI txtHealth = null;
    [SerializeField] private TextMeshProUGUI txtDamage = null;
    #endregion

    #region Private Fields
    private BattleHero battleHero      = null;
    private Coroutine  damageCoroutine = null;
    #endregion

    #region Public Methods
    public void init( BattleHero battle_hero )
    {
      deinit();

      battleHero = battle_hero;

      battleHero.onDeath      += onDeath;
      battleHero.onTakeDamage += onTakeDamage;
      battleHero.onGiveDamage += onGiveDamage;
      
      image.color = Color.white;
      updateHpBar();
      txtDamage.text = battleHero.damage.ToString();
    }

    public void deinit()
    {
      StopAllCoroutines();

      if ( battleHero == null )
        return;

      battleHero.onDeath      -= onDeath;
      battleHero.onTakeDamage -= onTakeDamage;
      battleHero.onGiveDamage -= onGiveDamage;
      battleHero = null;
    }
    #endregion

    #region Private Methods
    private void onDeath()
    {
      updateHpBar();

      deinit();

      image.color = Color.black;
    }

    private void onTakeDamage( BattleHero offender, float new_health, float delta )
    {
      if ( damageCoroutine != null )
        StopCoroutine( damageCoroutine );

      updateHpBar();
      damageCoroutine = StartCoroutine( damageAnimation( Color.red ) );
    }

    private void onGiveDamage( BattleHero target, float new_health, float delta )
    {
      if ( damageCoroutine != null )
        StopCoroutine( damageCoroutine );

      updateHpBar();
      damageCoroutine = StartCoroutine( damageAnimation( Color.blue ) );
    }

    private IEnumerator damageAnimation( Color color )
    {
      const float ANIMATION_TIME = 0.4f;
      float       timer          = ANIMATION_TIME;
      while ( timer > 0.0f )
      {
        image.color = Color.Lerp( color, Color.white, 1.0f - timer / ANIMATION_TIME );
        yield return null;
        timer -= Time.deltaTime;
      }
    }

    private void updateHpBar()
    {
      if ( battleHero == null )
        return;

      hpBar.gameObject.SetActive( battleHero.isAlive );
      hpBar.normalizedValue = battleHero.normalizedHealth;
      txtHealth.text = $"{battleHero.health}/{battleHero.maxHealth}";
    }
    #endregion
  }

}