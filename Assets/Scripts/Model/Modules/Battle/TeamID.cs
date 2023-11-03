namespace Model.Modules.Battle
{

  public enum TeamID
  {
    NONE   = 0,
    FIRST  = 1,
    SECOND = 2,
  }


  public static class TeamIDHelper
  {
    public static TeamID getNextTeamID( this TeamID team_id )
    {
      if ( team_id == TeamID.FIRST )
        return TeamID.SECOND;

      if ( team_id == TeamID.SECOND )
        return TeamID.FIRST;

      return TeamID.FIRST;
    }
  }

}