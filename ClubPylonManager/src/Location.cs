using System.Runtime.Remoting.Messaging;

namespace ClubPylonManager {
  public class Location {
    public string Name { get; set; }

    public override string ToString() {
      return Name;
    }
  }
}