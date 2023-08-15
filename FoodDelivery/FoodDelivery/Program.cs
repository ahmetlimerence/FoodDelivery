using FoodDelivery;
using System.Xml.Schema;

internal class Program
{
    private static void Main(string[] args)
    {
        Customer customer = new Customer("admin","admin");
        Cooker cooker = new Cooker("admin", "admin");
        Product product = new Food(19,"Makarna","adminCooker");
        Product product1 = new Food(10,"salata","adminCooker");
        Product product2 = new Food(20,"pilav","adminCooker");

        customer.AddProduct(product1);
        customer.AddProduct(product2);
        customer.AddProduct(product);
        customer.AddProduct(product1);

        cooker.AddFoodToMenu(product1);
        cooker.AddFoodToMenu(product1);
        cooker.AddFoodToMenu(product1);
        cooker.AddFoodToMenu(product1);
        cooker.AddFoodToMenu(product1);
        cooker.AddFoodToMenu(product2);
        cooker.AddFoodToMenu(product);


        cooker.DecreaseProductCountFromMenu(product1, 5);

        foreach(int val in cooker.GetMenu().Values)
        {
            Console.WriteLine(val);
        }

        foreach(int val in customer._basket.Values)
        {
            Console.WriteLine(val);
        }
    }


}