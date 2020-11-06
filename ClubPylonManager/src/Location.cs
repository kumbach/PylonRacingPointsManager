namespace PylonRacingPointsManager {
  public class Location {
    public string Name { get; set; }

    // ReSharper disable once UnusedMember.Global
    public Location() {
    }

    public Location(string name) {
      Name = name;
    }

    public override string ToString() {
      return Name;
    }
  }
}