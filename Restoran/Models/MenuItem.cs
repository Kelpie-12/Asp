
namespace Restoran.Models
{
    public class MenuItem
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		private int price;

		public int Price
		{
			get { return price; }
			set { price = value; }
		}
		private string desc;

		public string Desc
		{
			get { return desc; }
			set { desc = value; }
		}


	}
}
