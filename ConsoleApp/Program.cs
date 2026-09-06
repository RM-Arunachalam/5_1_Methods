using ClassLib;

class Sample
{
    public static void Main(string[] args)
    {
        //inside static method(main method)->accessing instance fields and methods by creating object
        Product laptop = new Product("A quality laptop"); 
        laptop.cost = 80000;
        laptop.name = "HP";
        laptop.quantityInStock = 2;
        laptop.SetProductID( 1000);//out of range prodID
        Console.WriteLine("Laptop prod id->"+laptop.GetProductId());//0
        laptop.SetProductID(87);//valid prodID
        Console.WriteLine("Laptop prod id->" + laptop.GetProductId());//87
        Console.WriteLine(laptop.GetDescription());//A quality laptop

        Console.WriteLine("laptop product tax:" + laptop.tax);//0
        laptop.CalculateTax();//calling instance method with current object
        Console.WriteLine("laptop product tax:" + laptop.tax);//8000

        Console.WriteLine("Finalcost:"+laptop.ApplyDiscount(5));//76000
        Console.WriteLine("discount amount:" + laptop.GetDiscount());//4000
   
        Product.SetAvailability("Online");
        System.Console.WriteLine("laptop is available in "+Product.GetAvailability()+" mode");// Online mode
        laptop.SetProductCode("PD1876");
        System.Console.WriteLine("laptop product code retrieved:" + laptop.GetproductCode());//PD1876
        System.Console.WriteLine("laptop is available in " + Product.GetAvailability() + " mode");// Offline mode
        laptop.InstanceMethod();//calling instance method

        System.Console.WriteLine();
        Product mobile = new("A worthy mobile");
        mobile.cost = 20000;
        mobile.name = "Iphone";
        mobile.quantityInStock = 1;
        Product.SetAvailability("Offline");
        System.Console.WriteLine("mobile is available in " + Product.GetAvailability() + " mode");//Offline mode
        mobile.InstanceMethod();//calling instance method

        System.Console.Write("\n*******Passing object ref as arguments*****:");
        System.Console.WriteLine("\nbefore modification of mobile name->" + mobile.name);//Iphone
        int totalQuantityInStock = Product.GetTotalQuantity(mobile, laptop);
        System.Console.WriteLine(totalQuantityInStock);//3
        System.Console.Write("after modification of mobile name->" + mobile.name);//Samsung

        System.Console.WriteLine("\n*******default arguments*****:");
        mobile.CalculatedTax();//default argument
        System.Console.WriteLine("calculated tax for mobile:"+mobile.tax);//1000
        mobile.CalculatedTax(10);//overriding default argument
        System.Console.WriteLine("calculated tax for mobile:" + mobile.tax);//2000

        System.Console.WriteLine("\n*******named arguments*****:");
        mobile.CalculatedTaxx(percent: 50);//improves readability(useful when method has many parameters especially Reference variables)
        System.Console.WriteLine("calculated tax for mobile:" + mobile.tax);//10000

        System.Console.WriteLine("\n****MethodOverloading***");
        Product Watch = new Product("Stunning watch");
        Watch.cost = 10000;
        Watch.CalculateTax();//500
        System.Console.WriteLine("Tax for watch:" + Watch.tax);//500
        System.Console.WriteLine("calculate tax for watch->" + Watch.CalculateTax(10000, 10));//1000
        System.Console.WriteLine("Tax for watch:" + Watch.tax);//1000
        

        System.Console.WriteLine("\n***Parameter Modifier-Default***");
        int a=9;
        System.Console.WriteLine("Before modified 'A' value will be:" + a);//9
        Watch.DefaultParameterModifier(a);
        System.Console.WriteLine("After modified 'A' value will be:" + a);//9

        System.Console.WriteLine("\n***Parameter Modifier-Ref***");
        int b = 9;
        System.Console.WriteLine("Before modified 'B' value will be:" + b);//9
        Watch.RefParameterModifier(ref b);
        System.Console.WriteLine("After modified 'B' value will be:" + b);//60

        System.Console.WriteLine("\n***Parameter Modifier-Out***");
        int c ;
        System.Console.WriteLine("Before modified 'C' value is not initialized");
        Watch.OutParameterModifier(out c,out double c2);
        System.Console.WriteLine("After modified 'C' value will be:" + c);//65
        System.Console.WriteLine("'C2' value will be:" + c2);//89

        System.Console.WriteLine("\n***Parameter Modifier-In***");
        int d = 9;
        System.Console.WriteLine("Before modified 'D' value will be:" + d);//9
        Watch.InParameterModifier(in d);
        System.Console.WriteLine("After modified 'D' value will be:" + d);//9
        Watch.name = "titan";
        System.Console.WriteLine("Before modified watch brand name:" + Watch.name);//titan
        Watch.InParameterModifier2(in Watch);
        System.Console.WriteLine("After modified watch brand name:" + Watch.name);//rolex

    /*    System.Console.WriteLine("\nprinting products list 1:");
        string[] productsList1 = { "toy", "sofa", "furniture" };
        Product.ParamsParameterModifier(productsList1);
        System.Console.WriteLine();
        System.Console.WriteLine("printing products list 2:");
        string[] productsList2 = { "bench", "chair", "tablet","keyboard" };
        Product.ParamsParameterModifier(productsList2);

        System.Console.WriteLine("\nlocal function::");
        Product.DisplayMarks(34, 35);//34.5

        System.Console.WriteLine("\nstatic local function::");
        Product.DisplayMarks2(23, 24);//23.5

        System.Console.WriteLine("\nRecursion::");
        System.Console.WriteLine("Factorial of 5 is "+Product.Factorial(5));//120
        System.Console.WriteLine("Factorial of 6 is " + Product.Factorial(6));//720
    */
    }
}