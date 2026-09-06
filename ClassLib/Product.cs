namespace ClassLib
{
    public class Product
    {
        public double cost;
        public double tax;
        private int _productId; //private field
        public string name;
        private readonly string description;
        public int quantityInStock;
        private double discount;
        private string productCode;
        public static string availability;

        public Product(string desc)
        {
            description = desc;
        }

        //manipulating static fields through static method
        public static void SetAvailability(string availability)
        {
            Product.availability = availability;
        }

        //manipulating static fields through static method
        public static string GetAvailability()
        {
            return availability;
        }

        public void SetProductCode(string productCode)
        {
            //this keyword-(refers to current object,which method has invoked this method)=>accessible only inside instance methods
            //used to differentiate between parameter and instance field with same name
            this.productCode = productCode;//accessing current object field
            this.DummyInstanceMethod();//calling other instance method
        }

        public string GetproductCode()
        {
            return productCode;
        }

        public double GetDiscount()
        {
            return discount;
        }

        public string GetDescription()//only get method for readonly field
        {
            return description;
        }

        public void SetProductID(int value)//public set method -doing validation before assigning value to private field
        {
            if (value >= 1 && value <= 100)
                _productId = value;
        }

        public int GetProductId()//public get method
        {
            return _productId;
        }

        public double ApplyDiscount(double discount)//parameter
        {
            double FinalCost;//local variable
            double discountAmount= CalDiscount(discount); //calling private method 
            FinalCost = cost - discountAmount;
            return FinalCost;
        }

        //private method(how discount is calculated is hidden from outside world)
        private double CalDiscount(double disc)
        {
            
            discount = (cost * disc) / 100;
            return discount;
        }

        //instance method
        public void DummyInstanceMethod()
        {
            System.Console.WriteLine("Dummy Instance method");
            //default online mode 
            availability = "offline";//accessing static field inside instance method
            StaticMethod();//accessing static method inside instance method
        }

        //instance method
        public void InstanceMethod()
        {
            System.Console.WriteLine("executed Instance method->"+name);
        }

        //static method
        public static void StaticMethod()
        {
            System.Console.WriteLine("Static method executed");
        }

        //Passing object ref as arguments
        public static int GetTotalQuantity(Product prod1, Product prod2)//can be done with instance method 
        {
            prod1.name = "Samsung";
            return prod1.quantityInStock + prod2.quantityInStock;
        }

        public void CalculateTax() //instanceMethod
        {
            double t;//local variable
            if (cost > 50000) //cost is instance field, accessible inside instance method
            {
                t = (cost * 10) / 100;
            }
            else
            {
                t = (cost * 5) / 100;
            }
            tax = t;
        }

        public void CalculatedTax(double perc=5)//default argument(should be used in first)
        {
            double t;//local variable
            if (cost > 50000)
            {
                t = (cost * 10) / 100;
            }
            else
            {
                t = (cost *perc ) / 100;
            }
            tax = t;
        }

        public void CalculatedTaxx(double percent)//Named argument(all should be named arguments)
        {
            double t;//local variable
            if (cost > 50000)
            {
                t = (cost * 10) / 100;
            }
            else
            {
                t = (cost * percent) / 100;
            }
            tax = t;
        }


        public double CalculateTax(int cost, double taxvalue)
        {
            tax= (cost * taxvalue) / 100;
            return tax;
        }

        public void DefaultParameterModifier(int val)
        {
            val = 6;
            System.Console.WriteLine("Default parameter executed");
        }

        public void RefParameterModifier(ref int val)
        {
            val = 60;
            System.Console.WriteLine("Ref  parameter modifier executed");
        }

        public void OutParameterModifier(out int value1,out double value2)
        {
            //returning multiple values from method 
            value1 = 65;
            value2 = 89;
            System.Console.WriteLine("out  parameter modifier executed");
        }

        public void InParameterModifier(in int val)
        {
           // val = 60; //parameter modifier of "in" type can't be modified
            System.Console.WriteLine("In  parameter modifier executed");
        }

        public void InParameterModifier2(in Product val)
        {
            //  val = new Product("Stylish tv"); //parameter modifier of "in" type can't be modified(can't assign new object to it)
            val.name = "rolex";//existing object value's can be modified 
            System.Console.WriteLine("In  parameter modifier executed");
        }


        public static void ParamsParameterModifier(params string[] products)
        {
            foreach (string product in products)
            {
                System.Console.WriteLine(product+" "+product.Length);
            }
        }
   
        public static void DisplayMarks(double cost1,double cost2)
        {
            System.Console.WriteLine("Avg cost of :  "+cost1+" and "+cost2+" are "+GetAvgCost());//local function

            double GetAvgCost()
            {
                double total = 0;
                total = (double)(cost1 + cost2) / 2;//default return value is int, typecating to double to get precised value
                return total;
            }
        }

        public static void DisplayMarks2(double cost1, double cost2)
        {
            // static local function
            System.Console.WriteLine("Avg cost of :  " + cost1 + " and " + cost2 + " are " + GetAvgCost(cost1,cost2));

            static double GetAvgCost(double c1,double c2)
            {
                double total = 0;
                total = (double)(c1 + c2) / 2;
                return total;
            }
        }

        public static double Factorial(int number)
        {
            if (number == 0)//base case
                return 1;
            else
                return number * Factorial(number - 1);
        }
    }
}
