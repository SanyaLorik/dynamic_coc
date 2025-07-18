using System.Collections.Generic;

public class EntityCollection
{
    private readonly List<BuildingAbstract> _buildings = new();
    private readonly List<ITargetable> _allianceTargets = new();

    public IReadOnlyList<BuildingAbstract> Buildings => _buildings;
    public IReadOnlyList<ITargetable> AllianceTargets => _allianceTargets;

    public bool HasBuildings => _buildings.Count > 0;

    public bool HasAlliances => _allianceTargets.Count > 0;

    public void AddBuilding(BuildingAbstract building)
    {
        AddAlliance(building);

        if (_buildings.Contains(building) == true)
            return;

        _buildings.Add(building);
    }

    public void RemoveBuilding(BuildingAbstract building)
    {
        RemoveAlliance(building);

        if (_buildings.Contains(building) == false)
            return;

        _buildings.Remove(building);
    }

    public void AddAlliance(ITargetable alliance)
    {
        if (_allianceTargets.Contains(alliance) == true)
            return;

        _allianceTargets.Add(alliance);
    }

    public void RemoveAlliance(ITargetable allianc)
    {
        if (_allianceTargets.Contains(allianc) == false)
            return;

        _allianceTargets.Remove(allianc);
    }
}
