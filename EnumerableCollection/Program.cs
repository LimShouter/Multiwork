// See https://aka.ms/new-console-template for more information

using EnumerableCollection;

MyClass MyClass = new MyClass();
MyClass.Add(1);
MyClass.Add("qae");
MyClass.Add(1.04f);
MyClass.Add(false);
int index = 0;
foreach (var i in MyClass)
{
	index++;
	Console.WriteLine($"value {index} :" +  i.ToString());
}
Console.WriteLine("Hello, World!");