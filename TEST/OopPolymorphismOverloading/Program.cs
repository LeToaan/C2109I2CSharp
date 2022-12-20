using OopPolymorphismOverloading;

//BasicMath math= new BasicMath();
//Console.WriteLine(math.NumberTwo);

//BasicMath basic = new (5, 6);
//Console.WriteLine(basic.NumberTwo);

//object initializer
BasicMath math= new BasicMath();
//BasicMath math2 = new BasicMath()
//{
//    NumberOne = 1
//};
//BasicMath math3 = new() { NumberTwo = 4 };

//BasicMath math4 = new() { NumberOne= 5 , NumberTwo = 10};

math.sum();
math.sum(5,6);
math.sum(5);

//named argumemt
math.sum(num2:5);
math.sum(num2:6, num1:1);


