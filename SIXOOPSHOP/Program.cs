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
        public Dictionary<int, Product> listProductShop = new Dictionary<int, Product>();

        public void SearchProduct()
        {
            foreach (KeyValuePair<int, Product> valuePairShop in listProductShop)
            {
                Console.WriteLine($"Индекс: {valuePairShop.Key}.\n" +
                    $"Название продукта: {valuePairShop.Value.NameProduct}.\n" +
                    $"Цена продукта: {valuePairShop.Value.SettingsPrice}.\n");
                Console.WriteLine();
            }
        }
    }

    class Bueyr
    {
        public Dictionary<int, Product> listProductBueyr = new Dictionary<int, Product>();
        public void SearchProduct()
        {
            foreach (KeyValuePair<int, Product> valuePairShop in listProductBueyr)
            {
                Console.WriteLine($"Индекс: {valuePairShop.Key}.\n" +
                    $"Название продукта: {valuePairShop.Value.NameProduct}.\n" +
                    $"Цена продукта: {valuePairShop.Value.SettingsPrice}.\n");
                Console.WriteLine();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            Bueyr bueyr = new Bueyr();
            shop.listProductShop.Add(1, new Product("Молоко", 100));
            shop.listProductShop.Add(2, new Product("Мясо", 200));
            shop.listProductShop.Add(3, new Product("Шоколад", 300));
            shop.listProductShop.Add(4, new Product("Сыр", 400));
            shop.listProductShop.Add(5, new Product("Торт", 500));

            while (true)
            {
                Console.WriteLine("Выберите команду: \n1 - показать список товара. " +
                    "\n2 - Продать товар. \n3 - Корзина покупателя.");

                string inputCommand = Console.ReadLine();
                if (int.TryParse(inputCommand, out int _inputCommand))
                {
                    switch (_inputCommand)
                    {
                        case (int)ShopProduct.ShopProduct:
                            shop.SearchProduct();
                            break;

                        case (int)ShopProduct.SellProduct:
                            shop.SearchProduct();
                            Console.WriteLine("Выберите товар для покупки. Введите индекс.");
                            int productChoice = Convert.ToInt32(Console.ReadLine());
                            if (productChoice != _inputCommand || productChoice == _inputCommand)
                            {
                                if (productChoice == 1)
                                {
                                    bueyr.listProductBueyr.Add(productChoice, new Product("Молоко", 100));
                                }

                                if (productChoice == 2)
                                {
                                    bueyr.listProductBueyr.Add(productChoice, new Product("Мясо", 200));
                                }

                                if (productChoice == 3)
                                {
                                    bueyr.listProductBueyr.Add(productChoice, new Product("Шоколад", 300));
                                }

                                if (productChoice == 4)
                                {
                                    bueyr.listProductBueyr.Add(productChoice, new Product("Сыр", 400));
                                }
                                if (productChoice == 5)
                                {
                                    bueyr.listProductBueyr.Add(productChoice, new Product("Торт", 500));
                                }
                            }
                            break;

                        case (int)ShopProduct.ShowBuyProduct:
                            bueyr.SearchProduct();
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
