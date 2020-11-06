namespace PylonRacingPointsManager {
  public class RaceClass {

    public string Name { get; set; }

    // ReSharper disable once UnusedMember.Global
    public RaceClass() {
    }

    public RaceClass(string name) {
      Name = name;
    }

    public override string ToString() {
      return Name;
    }
  }
}