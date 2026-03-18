using AlgSD_HW1;

double Pi = 3.1415926535897932;
// Console.WriteLine(Sin(485));
// Console.WriteLine(Cos(485));
while (true)
{
    Tokenizer t = new Tokenizer();
    Console.WriteLine("Provide a number to choose what you want to do next:\n1. Provide math problem and solve");
    var usParmInp = Console.ReadLine();
    switch (usParmInp)
    {
        case ("1"):
            string problem = Console.ReadLine();
            try
            {
                var tk = t.Tokenize(problem);
                tk.Print();
                var rpn = RPN(tk);
                rpn.Print();
                double result = calcFinal(rpn);
                Console.WriteLine($"\nResult: {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Division by zero!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            break;
        case ("2"):
            Console.WriteLine("Shutting down the progam...");
            Environment.Exit(0);
            break;
       default:
            Console.WriteLine("Not a valid option");
            break;
    }   

}

static double Cos(double x)
{
    double Radians = x * Math.PI / 180.0;
    Radians = Radians % (2 * Math.PI);
    double final = 1;
    int sign = -1;
    for (int i = 1; i < 10; i++)
    {
        int power = 2 * i;
        final += sign * (Power(Radians, power) / Fact(power));
        sign *= -1;
    }
    
    return final;
}

static double Sin(double x)
{
    double Radians = x * Math.PI / 180.0;
    Radians = Radians % (2 * Math.PI);
    double final = 0;
    int sign = 1;
    for (int i = 0; i < 10; i++)
    {
        int power = 2 * i + 1;
        final += sign * (Power(Radians, power) / Fact(power));
        sign *= -1;
    }
    
    return final;
}

static double Fact(int x)
{
    double nueva = 1;
    for (int i = 2; i <= x; i++)
    {
        nueva *= i;
    }

    return nueva;
}

static double Power(double number, double power) //3^4
{
    double nueva = number;
    if (power == 1){return number;}
    
    if (power % 1 == 0)
    {
        for (int i = 1; i < power; i++)
        {
            // Console.WriteLine($"S {i} {nueva}");
            nueva = nueva * number;
        }
    }
    return nueva;
}

static TList RPN(TList data)
{
    string SOpers = "+-*/^";
    TStack stack = new TStack();
    TList f = new TList();
    for (int i = 0; i < data.Length(); i++)
    {
        string c = data.Get(i);
        if (Char.IsDigit(c[0]) || (c.Length > 1 && c[0] == '-' && Char.IsDigit(c[1])))
        {
            f.Add(c);
        } else if (c == "sin" || c == "cos" || c == "max")
        {
            stack.Push(c);
        } else if (c == ",")
        {
            while (stack.Peek() != "(")
            {
                f.Add(stack.Pop());
            }
        } else if(c == "("){
            stack.Push(c);
        } else if (c == ")")
        {
            while (stack.Peek() != "(")
            {
                f.Add(stack.Pop());
            }
            stack.Pop();
            if (!stack.IsEmpty() && (stack.Peek() == "sin" || stack.Peek() == "cos" || stack.Peek() == "max"))
            {
                f.Add(stack.Pop());
            }
        } else if (SOpers.Contains(c))
        {
            while (!stack.IsEmpty() && (c != "^" ? GetPriority(stack.Peek()) >= GetPriority(c) : GetPriority(stack.Peek()) > GetPriority(c)))
            {
                f.Add(stack.Pop());
            }

            stack.Push(c);
        }
    }
    while (!stack.IsEmpty())
    {
        f.Add(stack.Pop());
    }
    return f;
}

static int GetPriority(string oper)
{
    if (oper == "^") return 3;
    if (oper == "*" || oper == "/") return 2;
    if (oper == "+" || oper == "-") return 1;
    return 0;
}

static double calcFinal(TList data)
{
    СStack stack = new СStack();
    string opers = "+-*/^";
    for (int i = 0; i < data.Length(); i++)
    {
        string c = data.Get(i);
        if (Char.IsDigit(c[0]) || (c.Length > 1 && c[0] == '-' && Char.IsDigit(c[1])))
        {
            stack.Push(double.Parse(c));
        }else if (c == "sin" || c == "cos" || c == "max") {
            if (c == "max")
            {
                double b = stack.Pop();
                double a = stack.Pop();
                stack.Push(a > b ? a : b);
            }
            else
            {
                double right = stack.Pop();
                double nueva = 0;
                switch (c)
                {
                    case "cos": nueva = Cos(right); break;
                    case "sin": nueva = Sin(right); break;
                }
                stack.Push(nueva);
            }
        } else if (opers.Contains(c)) {
            double right = stack.Pop();
            double left = stack.Pop();
            double nueva = 0;
            switch (c){
                case "+": nueva = left + right; break;
                case "-": nueva = left - right; break;
                case "*": nueva = left * right; break;
                case "/":
                    if (right == 0) throw new DivideByZeroException("Division by zero!");
                    nueva = left / right; break;
                case "^": nueva = Math.Pow(left, right); break;
            }
            stack.Push(nueva);
            
            
        }
    }
    

    return stack.Pop();
}
