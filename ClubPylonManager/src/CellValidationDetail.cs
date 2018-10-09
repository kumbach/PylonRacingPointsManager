namespace ClubPylonManager {
    public class CellValidationDetail {
        public int Row { get; }
        public int Col { get; }
        public string message { get; }

        public CellValidationDetail(int row, int col, string message) {
            Row = row;
            Col = col;
            this.message = message;
        }
    }
}