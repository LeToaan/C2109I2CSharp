using QuanLySinhVien.Data;

namespace QuanLySinhVien.UI {
    public class UpdateProfileUI : UserInterface {
        protected override void Print() {
            Console.WriteLine("CAP NHAT DU LIEU SINH VIEN\n");
            int id = TryParseInt(PrintWithPrompt("Nhap ma so sinh vien can tim: "));

            SinhVien profile = SinhVien.GetProfile(id);

            if (profile != null) {
                Console.WriteLine("Da tim thay du lieu sinh vien.");
                Console.WriteLine(profile.ToString());
                Console.WriteLine(String.Empty);
                profile.Name = PrintWithPrompt("Nhap ten can sua: ");
                profile.Gender = TryParseBoolean("Nhap gioi tinh can sua (true=Nam, false=Nu): ");
                profile.Birthday = TryParseDateTime("Nhap ngay sinh can sua: ");
                Console.WriteLine(String.Empty);
                Console.WriteLine("Hoan thanh cap nhat du lieu sinh vien.");
            } else {
                Console.WriteLine("\nKhong tim thay du lieu sinh vien.");
            }
            Console.WriteLine("Nhan phim bat ki de tiep tuc.");
            Console.ReadKey();
            QuanLySinhVienApp.Instance.Open();
        }
    }
}