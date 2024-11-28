namespace SIXOOPSHOP
{
    //Существует продавец, он имеет у себя список товаров,
    //и при нужде, может вам его показать, также продавец может продать вам товар.
    //После продажи товар переходит к вам, и вы можете также посмотреть свои вещи.
    //Возможные классы – игрок, продавец, товар.
    //Вы можете сделать так, как вы видите это.

    class Product
    {
        private string nameProduct;

        private int settingsPrice;


        public Product(string nameProduct, int settingsPrice)
        {
            NameProduct = nameProduct;
            SettingsPrice = settingsPrice;
        }

        public int SettingsPrice { get { return settingsPrice; } set { settingsPrice = value; } }

        public string NameProduct { get { return nameProduct; } set { nameProduct = value; } }
    }

    class Shop
    {
        private Dictionary<int, Product> listProductShop = new Dictionary<int, Product>()
        {
            {1, new Product("Молоко", 100)},
            {2, new Product("Мясо", 200)},
            {3, new Product("Шоколад", 300)},
            {4, new Product("Сыр", 400)},
            {5, new Product("Торт", 500)}
        };

        public void DisplayProduct()
        {
            foreach (KeyValuePair<int, Product> valuePairShop in listProductShop)
            {
                Console.WriteLine($"Индекс: {valuePairShop.Key}.\n" +
                    $"Название продукта: {valuePairShop.Value.NameProduct}.\n" +
                    $"Цена продукта: {valuePairShop.Value.SettingsPrice}.\n");
                Console.WriteLine();
            }
        }
        public void DeletProductShop(int key)
        {
            listProductShop.Remove(key);
        }

        public bool TryGetProduct(int key, out Product product)
        {
            product = null;

            if (listProductShop.ContainsKey(key))
            {
                product = listProductShop[key];
                return true;
            }
            return false;
        }
    }

    class Buyer
    {
        public List<Product> listProductBueyr = new List<Product>();
        public void DisplayProductBuyer()
        {
            foreach (Product valuePairShop in listProductBueyr)
            {
                Console.WriteLine($"Название продукта: {valuePairShop.NameProduct}.\n" +
                    $"Цена продукта: {valuePairShop.SettingsPrice}.\n");
                Console.WriteLine();
            }
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            Buyer buyer = new Buyer();

            while (true)
            {
                Console.WriteLine("Выберите команду: \n1 - показать список товара. " +
                    "\n2 - Продать товар. \n3 - Корзина покупателя.");

                string inputCommandStr = Console.ReadLine();
                if (int.TryParse(inputCommandStr, out int inputCommand))
                {
                    switch (inputCommand)
                    {
                        case (int)ShopProduct.ShopProduct:
                            shop.DisplayProduct();
                            break;

                        case (int)ShopProduct.SellProduct:
                            shop.DisplayProduct();
                            Console.WriteLine("Выберите товар для покупки. Введите индекс.");
                            int productChoice = Convert.ToInt32(Console.ReadLine());
                            if (shop.TryGetProduct(productChoice, out Product product))
                            {
                                buyer.listProductBueyr.Add(product);
                                shop.DeletProductShop(productChoice);
                            }
                            break;

                        case (int)ShopProduct.ShowBuyProduct:
                            buyer.DisplayProductBuyer();
                            break;

                        default:
                            Console.WriteLine("Неизвестная команда.");
                            break;
                    }
                }
            }
        }
    }
}

enum ShopProduct
{
    ShopProduct = 1,
    SellProduct,
    ShowBuyProduct
}
