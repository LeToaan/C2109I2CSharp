using QuanLySinhVien.Data;

namespace QuanLySinhVien.UI {
    public class ShowProfilesUI : UserInterface {
        protected override void Print() {
            Console.WriteLine("HIEN THI THONG TIN CAC SINH VIEN\n");
            if (SinhVien.ProfileCounts > 0) {
                SinhVien.ShowProfiles();
                Console.WriteLine(String.Empty);
            } else {
                Console.WriteLine("Khong co du lieu sinh vien nao ton tai.");
            }
            Console.WriteLine("Nhan phim bat ki de tiep tuc.");
            Console.ReadKey();
            QuanLySinhVienApp.Instance.Open();
        }
    }
}