using QuanLySinhVien.UI;

namespace QuanLySinhVien {
    public class QuanLySinhVienApp : UserInterface {
        private static readonly string[] MsgMainMenu = new string[] {
            "CHUONG TRINH QUAN LY SINH VIEN\n",
            "1. Them du lieu sinh vien",
            "2. Xoa du lieu sinh vien",
            "3. Tim kiem thong tin sinh vien",
            "4. Cap nhat thong tin sinh vien",
            "5. Hien thi toan bo thong tin cac sinh vien",
            "6. Sap xep lai danh sach sinh vien",
            "7. Thoat khoi ung dung\n",
            "De thuc hien cac tac vu tren, hay nhap so thu tu cua tac vu: "
        };
        private List<UserInterface> _lstUI = new List<UserInterface>();
        private static QuanLySinhVienApp s_instance;
        public static QuanLySinhVienApp Instance {
            get { return s_instance; }
        }

        public QuanLySinhVienApp() {
            s_instance = this;
            _lstUI.Add(new AddProfileUI());
            _lstUI.Add(new DeleteProfileUI());
            _lstUI.Add(new LookupProfileUI());
            _lstUI.Add(new UpdateProfileUI());
            _lstUI.Add(new ShowProfilesUI());
            _lstUI.Add(new SortProfilesUI());
            _lstUI.Add(new ExitAppUI());
        }

        protected override void Print() {
            int inp = TryParseInt(PrintWithPrompt(MsgMainMenu));
            SelectTask(inp);
        }

        private void SelectTask(int i) {
            if (i <= 0 || i > _lstUI.Count)
                SelectTask(TryParseInt(PrintWithPrompt(
                    "Khong co lua chon nao ton tai, xin vui long nhap lai: "
                )));

            _lstUI[i - 1].Open();
        }
    }
}