<Query Kind="Program" />

void Main()
{
	var cart = CreateTestCart();
	
	// This isn't comprehensible without thinking about each item.
	// Also it contains some weird logic which may not make sense even in context
	// Oh and look, magic strings and magic numbers.  Joy!
	var output = cart.Items.Where(x => x.UnitPrice > 2.00m && x.Name != "Stuff" && x.UnitPrice < 99m).OrderByDescending(x => x.Id).Take(3).Select(x => x.UnitPrice);
	
	output.Dump();
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

// Define other methods and classes here
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