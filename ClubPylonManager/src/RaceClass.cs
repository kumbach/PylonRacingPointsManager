﻿using System.Runtime.Remoting.Messaging;

namespace ClubPylonManager {
  public class RaceClass {
    public string Name { get; set; }

    public override string ToString() {
      return Name;
    }
  }
}