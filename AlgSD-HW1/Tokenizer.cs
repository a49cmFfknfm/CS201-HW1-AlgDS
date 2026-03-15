namespace AlgSD_HW1;

public class Tokenizer
{

    public TList Tokenize(string data)
    {
        TList tokens = new TList();
        string opers = "+-*/()^";
        string buff = "";
        char prev = '\0';
        
        foreach (char x in data)
        {
            if (x == ' ') continue;
            if (char.IsDigit(x) || x == '.' || x == ',')
            {
                if (prev == ')') 
                {
                    tokens.Add("*");
                }
                buff += x;
            } 
            else if (opers.Contains(x))
            {
                if (!String.IsNullOrWhiteSpace(buff))
                {
                    tokens.Add(buff);
                    buff = "";
                }

                if (x == '(' && (char.IsDigit(prev) || prev == ')'))
                {
                    tokens.Add("*");
                }

                tokens.Add(x.ToString());
            }

            prev = x;


        }
        
        if (!String.IsNullOrWhiteSpace(buff))
        {
            tokens.Add(buff);
        }

        return tokens;
    }


}
