while (true){
    Console.WriteLine("Provide a number to choose what you want to do next:\n1. Provide math problem and solve");
    var usParmInp = Console.ReadLine();
    switch (usParmInp)
    {
        case ("1"):
            Console.WriteLine("FFGGFGFFG");
            string problem = Console.ReadLine();
            tokenize(problem);
            break;
        default:
            Console.WriteLine("Not a valid option");
            break;
    }

}
