using System;


namespace Model.Modules.Battle
{

  public delegate void TakeDamageDelegate( BattleHero enemy, float new_health, float delta );
  public delegate void GiveDamageDelegate( BattleHero target, float new_health, float delta );

  public class BattleHero
  {
    public event TakeDamageDelegate onTakeDamage = delegate {};
    public event GiveDamageDelegate onGiveDamage = delegate {};
    public event Action             onDeath      = delegate {};

    public HeroPrototypeID heroPrototypeID { get; private set; }
    public float           health          { get; private set; }
    public float           maxHealth       { get; private set; }
    public float           damage          { get; private set; }


    internal BattleHero( HeroPrototypeID hero_prototype_id, float health, float damage )
    {
      heroPrototypeID = hero_prototype_id;
      this.health = health;
      this.maxHealth = health;
      this.damage = damage;
    }

    public bool isDead => health <= 0;

    public bool isAlive => !isDead;

    public float normalizedHealth => maxHealth != 0 ? health / maxHealth : 0;

    public void giveDamageTo( BattleHero battle_hero )
    {
      float damage_dealt = battle_hero.takeDamage( damage );

      this.       onGiveDamage( battle_hero, battle_hero.health, damage_dealt );
      battle_hero.onTakeDamage( this, battle_hero.health, damage_dealt );
    }

    private float takeDamage( float damage_amount )
    {
      if ( isDead || damage_amount == 0 )
        return 0.0f;

      float old_health = health;
      health -= damage_amount;
      if ( health < 0 )
        health = 0;

      float damage_dealt = old_health - health;

      if ( isDead )
        onDeath();

      return damage_dealt;
    }
  }

}