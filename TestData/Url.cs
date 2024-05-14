namespace Test_Ecommerce.TestData
{
    public class Url
    {
        public static string LoginUrl { get; set; } = "https://ecommerce-playground.lambdatest.io/index.php?route=account/login";

        public static string searchUrl { get; set; } = "https://ecommerce-playground.lambdatest.io/index.php?route=product%2Fsearch&search=";

        public static string productUrl { get; set; } = "https://ecommerce-playground.lambdatest.io/index.php?route=product/product&product_id=28";

    }
}
