using OopPolymorphismInterface;

SomeFile some = new SomeFile();
some.ReadFile();
some.WriteTextFile();
some.WriteBinaryInterface();

//cách thuần c#
((IBinaryFile)some).showInfo();
//cách mới ok hơn
(some as IBinaryFile).showInfo();
//===========

ManyFile many= new ManyFile();
(many as IBinaryFile).ReadFile();
(many as ITextFile).ReadFile();
many.WriteTextFile();
many.WriteBinaryInterface();

//==============
IBinaryFile bf = new SomeFile();
bf.ReadFile();
bf.showInfo();
bf.WriteBinaryInterface();
 
bf = new ManyFile();
bf.showInfo();
bf.ReadFile();
bf.WriteBinaryInterface