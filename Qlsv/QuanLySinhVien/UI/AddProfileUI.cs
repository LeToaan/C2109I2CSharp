using QuanLySinhVien.Data;

namespace QuanLySinhVien.UI {
    public class AddProfileUI : UserInterface {
        protected override void Print() {
            Console.WriteLine("THEM SINH VIEN VAO DU LIEU\n");
            int id = InputID();
            string name = PrintWithPrompt("Nhap ten sinh vien: ");
            bool gender = TryParseBoolean(PrintWithPrompt("Nhap gioi tinh (true=Nam, false=Nu): "));
            DateTime birthday = TryParseDateTime(PrintWithPrompt("Nhap ngay sinh: "));

            SinhVien profile = new SinhVien(id, name, gender, birthday);
            SinhVien.AddProfile(profile);
            Console.WriteLine("\nDa them du lieu sinh vien moi thanh cong.");
            Console.WriteLine("Nhan phim bat ki de tiep tuc.");
            Console.ReadKey();
            QuanLySinhVienApp.Instance.Open();
        }

        private int InputID() {
            int id = TryParseInt(PrintWithPrompt("Nhap ma so sinh vien: "));
            if (SinhVien.GetProfile(id) != null)
                return TryParseInt(PrintWithPrompt("Da ton tai sinh vien co ma so nay, xin hay nhap lai: "));
            return id;
        }
    }
}