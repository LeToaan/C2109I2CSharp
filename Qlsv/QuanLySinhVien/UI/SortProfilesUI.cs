using QuanLySinhVien.Data;

namespace QuanLySinhVien.UI {
    public class SortProfilesUI : UserInterface {
        protected override void Print() {
            Console.WriteLine("SAP XEP THONG TIN CAC SINH VIEN\n");

            if (SinhVien.ProfileCounts > 0) {
                SinhVien.SortProfiles();
                Console.WriteLine("Sap xep thanh cong.");
                Console.WriteLine("Danh sach thong tin sau khi sap xep:");
                SinhVien.ShowProfiles();
                Console.WriteLine(String.Empty);
            } else {
                Console.WriteLine("Khong co du lieu sinh vien nao de sap xep.");
            }
            Console.WriteLine("Nhan phim bat ki de tiep tuc.");
            Console.ReadKey();
            QuanLySinhVienApp.Instance.Open();
        }
    }
}