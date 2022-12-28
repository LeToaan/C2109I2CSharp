using System;
using System.Globalization;

namespace QuanLySinhVien.UI {
    public abstract class UserInterface {
        protected abstract void Print();

        public void Open() {
            Console.Clear();
            Print();
        }

        protected string PrintWithPrompt(string[] arr) {
            for (int i = 0; i < arr.Length; ++i) {
                string s = arr[i];
                if (i < arr.Length - 1) {
                    Console.WriteLine(s);
                } else {
                    Console.Write(s);
                }
            }

            string inp = Console.ReadLine();
            if (String.IsNullOrEmpty(inp))
                return PrintWithPrompt(NoEmptyInput);
            return inp;
        }

        protected string PrintWithPrompt(string s) {
            Console.Write(s);
            string inp = Console.ReadLine();
            if (String.IsNullOrEmpty(inp))
                return PrintWithPrompt(NoEmptyInput);
            return inp;
        }

        protected int TryParseInt(String inp) {
            int parsed;
            if (!Int32.TryParse(inp, out parsed)) {
                return TryParseInt(PrintWithPrompt("Khong phai so hop le, xin nhap lai: "));
            }

            return parsed;
        }

        protected bool TryParseBoolean(String inp) {
            bool parsed;
            if (!Boolean.TryParse(inp, out parsed)) {
                return TryParseBoolean(PrintWithPrompt("Khong phai boolean hop le, xin nhap lai: "));
            }

            return parsed;
        }

        protected DateTime TryParseDateTime(String inp) {
            DateTime parsed;
            if (!DateTime.TryParseExact(inp, DateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsed)) {
                return TryParseDateTime(PrintWithPrompt("Khong phai ngay thang hop le, xin nhap lai: "));
            }
            
            return parsed;
        }

        private static readonly string[] DateFormats = new string[] {
            "d/M/yyyy", "dd/MM/yyyy", "d-M-yyyy",
            "dd-MM-yyyy", "ddMMyyyy"
        };
        private const string NoEmptyInput = "Du lieu nhap vao khong duoc de trong, hay nhap lai: ";
    }
}