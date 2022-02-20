internal class RomanNumber : ICloneable, IComparable
{
    private ushort number;
    private string romanNumber;
    internal RomanNumber(ushort n)
    {
        if (n > 0)
        {
            number = n;
            romanNumber = "";

            Dictionary<ushort, string> rDigits = new Dictionary<ushort, string>()
            {
                {1000, "M"},
                {500, "D"},
                {100, "C"},
                {50, "L"},
                {10, "X"},
                {5, "V"},
                {1, "I"}
            };

            foreach (var digit in rDigits)
            {
                if (digit.Key == number)
                {
                    romanNumber = digit.Value;
                    return;
                }
            }

            Dictionary<short, string> rRDigits = new Dictionary<short, string>()
            {
                {-1, "I"},
                {-5, "V"},
                {-10, "X"},
                {-50, "L"},
                {-100, "C"},
                {-500, "D"},
                {-1000, "M"},
            };

            int buff = number;

            short combineDigits(ushort highDigit)
            {
                foreach (var digit in rRDigits)
                {
                    if (digit.Key + highDigit != 0 && buff / (digit.Key + highDigit) > 0)
                        return digit.Key;
                }
                return 0;
            }

            void writeSymbols(int n, string symb)
            {
                for (int i = 0; i < n; i++)
                {
                    romanNumber += symb;
                }
            }

            foreach (var digit in rDigits)
            {
                int count = buff / digit.Key;
                if (count > 0 && count < 4)
                {
                    writeSymbols(count, digit.Value);
                    buff -= digit.Key * count;
                }
                else
                {
                    short revDigit = combineDigits(digit.Key);
                    if (revDigit != 0)
                    {
                        romanNumber += rRDigits[revDigit] + digit.Value;
                        buff -= digit.Key + revDigit;
                    }
                }
            }
        }
        else
            throw new RomanNumberException("Некорректное число");
    }

    public object Clone()
    {
        return new RomanNumber(number);
    }

    public int CompareTo(object? n)
    {
        if (n is RomanNumber rNumber)
            return number - rNumber.number;
        throw new RomanNumberException("Некорректный параметр передан в функцию");
    }
    public static RomanNumber Add(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 != null && n2 != null)
            return new RomanNumber((ushort)(n1.number + n2.number));
        else
            throw new RomanNumberException("Сложение этих чисел невозможно");
    }
    public static RomanNumber Sub(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 != null && n2 != null && n1.number - n2.number > 0)
            return new RomanNumber((ushort)(n1.number - n2.number));
        else
            throw new RomanNumberException("Вычитание этих чисел невозможно");
    }
    public static RomanNumber Mul(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 != null && n2 != null)
            return new RomanNumber((ushort)(n1.number * n2.number));
        else
            throw new RomanNumberException("Умножение этих чисел невозможно");
    }
    public static RomanNumber Div(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 != null && n2 != null && n1.number / n2.number > 0)
            return new RomanNumber((ushort)(n1.number / n2.number));
        else
            throw new RomanNumberException("Деление этих чисел невозможно");
    }
    public override string ToString()
    {
        if(romanNumber != "")
            return romanNumber;
        else
            throw new RomanNumberException("Число не найдено");
    }
}