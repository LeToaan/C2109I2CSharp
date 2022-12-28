namespace QuanLySinhVien.Data {
    public class SinhVien {
        private int _id;
        private string _name;
        private bool _gender;
        private DateTime _birthday;

        public SinhVien(int id, string name, 
                bool gender, DateTime birthday) {
            _id = id;
            _name = name;
            _gender = gender;
            _birthday = birthday;
        }
        
        public int ID {
            get { return _id; }
            set { _id = value; }
        }

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        public bool Gender {
            get { return _gender; }
            set { _gender = value; }
        }

        public DateTime Birthday {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public override string ToString() {
            return $"{nameof(ID)}={ID.ToString()}, {nameof(Name)}={Name}, {nameof(Gender)}={(Gender ? "Nam" : "Nu")}, {nameof(Birthday)}={Birthday.ToString()}";
        }

        private static List<SinhVien> s_lstSinhVien = new List<SinhVien>();

        public static SinhVien GetProfile(int id) {
            for (int i = 0; i < s_lstSinhVien.Count; ++i) {
                SinhVien profile;
                if ((profile = s_lstSinhVien[i]).ID == id)
                    return profile;
            }
            return null;
        }

        public static int ProfileCounts {
            get { return s_lstSinhVien.Count; }
        }

        public static void AddProfile(SinhVien profile) {
            s_lstSinhVien.Add(profile);
        }

        public static bool RemoveProfile(int id) {
            for (int i = 0; i < s_lstSinhVien.Count; ++i) {
                SinhVien profile;
                if ((profile = s_lstSinhVien[i]).ID == id) {
                    s_lstSinhVien.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public static void ShowProfiles() {
            for (int i = 0; i < s_lstSinhVien.Count; ++i) {
                SinhVien profile = s_lstSinhVien[i];
                Console.WriteLine(profile.ToString());
            }
        }

        public static void SortProfiles() {
            s_lstSinhVien.Sort((a, b) => a.ID.CompareTo(b.ID));
        }
    }
}