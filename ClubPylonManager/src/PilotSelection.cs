namespace ClubPylonManager
{
    public class PilotSelection
    {
        public string Pilot { get; set; }
        public bool Selected { get; set; }

        public PilotSelection(string pilot)
        {
            Pilot = pilot;
            Selected = false;
        }
    }
}