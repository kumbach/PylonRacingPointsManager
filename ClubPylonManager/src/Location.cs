﻿namespace PylonRacingPointsManager {
  public class Location {
    public string Name { get; set; }

    public Location(string name) {
      Name = name;
    }

    public override string ToString() {
      return Name;
    }
  }
}