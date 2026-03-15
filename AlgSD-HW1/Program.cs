using AlgSD_HW1;

while (true)
{
    Tokenizer t = new Tokenizer();
    Console.WriteLine("Provide a number to choose what you want to do next:\n1. Provide math problem and solve");
    var usParmInp = Console.ReadLine();
    switch (usParmInp)
    {
        case ("1"):
            string problem = Console.ReadLine();
            var tk = t.Tokenize(problem);
            tk.Print();
            var rpn = RPN(tk);
            rpn.Print();
            double result = calcFinal(rpn);
            Console.WriteLine($"Result: {result}");
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

static TList RPN(TList data)
{
    string SOpers = "+-*/^";
    TStack stack = new TStack();
    TList f = new TList();
    for (int i = 0; i < data.Length(); i++)
    {
        string c = data.Get(i);
        if (Char.IsDigit(c[0]))
        {
            f.Add(c);
        } else if(c == "("){
            stack.Push(c);
        } else if (c == ")")
        {
            while (stack.Peek() != "(")
            {
                f.Add(stack.Pop());
            }

            stack.Pop();
        } else if (SOpers.Contains(c))
        {
            while (!stack.IsEmpty() && GetPriority(stack.Peek()) >= GetPriority(c))
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
        if (Char.IsDigit(c[0]))
        {
            stack.Push(double.Parse(c));
        } else if (opers.Contains(c))
        {
            double right = stack.Pop();
            double left = stack.Pop();
            double nueva = 0;
            switch (c){
                case "+": nueva = left + right; break;
                case "-": nueva = left - right; break;
                case "*": nueva = left * right; break;
                case "/": nueva = left / right; break;
                case "^": nueva = Math.Pow(left, right); break;
            }
            stack.Push(nueva);
            
            
        }
    }
    

    return stack.Pop();
}
