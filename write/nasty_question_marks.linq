<Query Kind="Program" />

void Main()
{
	var w = "Test1";
	var x = 100;
	var y = 50;
	var z = "50";
	
	// This will result in defenestration
	var result = (x > y) ? (x.ToString() == z) ? 1 : 2 : 3;
	
	// This will result in worse
	var result2 = (x > y) ? (x.ToString() == z) ? 1.ToString() : z ?? w : 3.ToString();
	
	result.Dump();
	result2.Dump();
}