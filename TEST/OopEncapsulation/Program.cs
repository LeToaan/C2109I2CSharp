using OopEncapsulation;

Sunflower sunflower = new();
//sunflower.Protected();// error vì chỉ có quan hệ giữa các class
sunflower.Internal();//cùng project/assembly nên dc sài
//sunflower.PrivateProtected();//
sunflower.ProtectedInternal();//
sunflower.Public();//
                   //sunflower.Private(); private nên k dc sài