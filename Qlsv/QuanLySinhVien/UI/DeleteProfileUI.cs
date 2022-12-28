using QuanLySinhVien.Data;

namespace QuanLySinhVien.UI {
    public class DeleteProfileUI : UserInterface {
        protected override void Print() {
            Console.WriteLine("XOA SINH VIEN KHOI DU LIEU\n");
            int id = TryParseInt(PrintWithPrompt("Nhap ma so sinh vien can xoa: "));
            Console.WriteLine(String.Empty);
            if (SinhVien.RemoveProfile(id))
                Console.WriteLine("Da xoa du lieu sinh vien thanh cong.");
            else
                Console.WriteLine("Du lieu sinh vien khong ton tai.");
            Console.WriteLine("Nhan phim bat ki de tiep tuc.");
            Console.ReadKey();
            QuanLySinhVienApp.Instance.Open();
        }
    }
}