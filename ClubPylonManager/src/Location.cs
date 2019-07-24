using System.Runtime.Remoting.Messaging;

namespace ClubPylonManager {
  public class Location {
    public string name { get; set; }

    public override string ToString() {
      return name;
    }
  }
}