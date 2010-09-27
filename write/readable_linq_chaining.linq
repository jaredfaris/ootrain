<Query Kind="Program" />

void Main()
{
	LoadConfiguredValues(); // Don't embed values, recompiling is bad
	
	var cart = CreateTestCart();
	
	// It's pretty obvious what each distinct unit of this chain is doing.
	// We can even easily comment anything that's tricky
	var output = cart.Items
		.Where(x => x.UnitPrice > lowerLimit) // Explain non-obvious logic
		.Where(x => x.UnitPrice < upperLimit) 
		.Where(x => x.Name != bannedName) // No more magic strings!
		.OrderByDescending(y => y.Id)
		.Take(3) // Limit for some business reason?  Maybe explain
		.Select(z => z.UnitPrice);
	
	output.Dump();
}

private decimal lowerLimit { get; set; }
private decimal upperLimit { get; set; }
private string bannedName { get; set; }

// This class proxies loading data from an actual data source
private void LoadConfiguredValues()
{
	lowerLimit = 2.00m;
	upperLimit = 99m;
	bannedName = "Stuff";
}

private SourceShoppingCart CreateTestCart()
{
	return new SourceShoppingCart{
		Id = 1,
		Name = "Test",
		Items = new List<SourceCartItem> {
			new SourceCartItem{
				Id = 1,
				Name = "Widget",
				UnitPrice = 3.33m
			},
			new SourceCartItem{
				Id = 2,
				Name = "Gadget",
				UnitPrice = 4.44m
			},
			new SourceCartItem{
				Id = 3,
				Name = "Gizmo",
				UnitPrice = 5.55m
			},
			new SourceCartItem{
				Id = 4,
				Name = "Thinger",
				UnitPrice = 6.66m
			}
		}
	};
}

private class SourceCartItem {
	public int Id { get; set; }
	public string Name { get; set; }
	public decimal UnitPrice { get; set; }
}

private class SourceShoppingCart {
	public int Id { get; set; }
	public string Name { get; set; }
	public IEnumerable<SourceCartItem> Items { get; set; }
}