namespace PylonRacingPointsManager {
  public class RaceClass {

    public string Name { get; set; }

    public RaceClass(string name) {
      Name = name;
    }

    public override string ToString() {
      return Name;
    }
  }
}