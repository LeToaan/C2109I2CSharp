using QuanLySinhVien.Data;

namespace QuanLySinhVien.UI {
    public class LookupProfileUI : UserInterface {
        protected override void Print() {
            Console.WriteLine("TIM KIEM DU LIEU SINH VIEN\n");
            int id = TryParseInt(PrintWithPrompt("Nhap ma so sinh vien can tim: "));

            SinhVien profile = SinhVien.GetProfile(id);

            if (profile != null) {
                Console.WriteLine("Da tim thay du lieu sinh vien:");
                Console.WriteLine(profile.ToString());
                Console.WriteLine(String.Empty);
            } else {
                Console.WriteLine("\nKhong tim thay du lieu sinh vien.");
            }
            Console.WriteLine("Nhan phim bat ki de tiep tuc.");
            Console.ReadKey();
            QuanLySinhVienApp.Instance.Open();
        }
    }
}