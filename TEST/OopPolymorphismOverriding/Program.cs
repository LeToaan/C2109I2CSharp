using OopPolymorphismOverriding;

Parent pa = new();
pa.display();
pa.show();

Childone child = new();
child.display();
child.show();

Parent p = new Childone();
p.display();//của con
p.show();//show la của cha