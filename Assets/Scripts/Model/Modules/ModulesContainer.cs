using Model.Modules.Battle;
using Model.Modules.Hero;
using Model.Modules.Location;


namespace Model.Modules
{

  public class ModulesContainer
  {
    public IModuleBattle    battle    = new ModuleBattle();
    public IModuleHero      hero      = new ModuleHero();
    public IModuleLocations locations = new ModuleLocations();
  }

}