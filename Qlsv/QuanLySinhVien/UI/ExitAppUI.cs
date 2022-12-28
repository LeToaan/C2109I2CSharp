namespace QuanLySinhVien.UI {
    public class ExitAppUI : UserInterface {
        protected override void Print() {
            Environment.Exit(0);
        }
    }
}