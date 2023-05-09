// See https://aka.ms/new-console-template for more information
/* Prime number checker: while loop. The loop will check the counter is less than or equal to the 
integer result of the division by 2. When this condition is met, you check whether the remainder of
the division of the number by the counter is 0. If not, the counter is incremented and continue until
the loop condition is not met.*/

Console.Write("Enter a number to check wheter its Prime: ");

var input = int.Parse(Console.ReadLine());

Console.WriteLine($"{input} is prime? {isPrime(input)}");
Console.WriteLine($"The other methods yield the result: {isPrimeWithContinue(input)} , {isPrimeWithGoTo(input)} , {isPrimeWithReturn(input)}");


static bool isPrime(int number)
{
    if (number == 0 || number == 1) return false;

    bool isPrime = true;

    int counter = 2;

    while (counter <= Math.Sqrt(number))
    {
        if (number % counter == 0)
        {
            isPrime = false;
            break;
        } 
        counter++;
    }

    return isPrime;

}


/*Prime Number Checker: continue variant. Using different keywords to check whether a number
is a prime number. In this variant we check whether the remainder is not zero, and if so, we use the
continue statement to pass the execution to the next iteration.*/

static bool isPrimeWithContinue(int number)
{
    if (number == 0 || number == 1) return false;

    bool isPrime = true;

    int counter = 2;

    while (counter <= Math.Sqrt(number))
    {
        if (number % counter != 0)
        {
            counter++;
            continue;
        } 
        isPrime = false;
        break;
    }

    return isPrime;

}

/*Prime Number checker: goto variant. The goto keyword can be used to jump to one section of the code
to another, via a label. In this case, our label will be isNotAPrime.*/

static bool isPrimeWithGoTo(int number)
{
    if (number == 0 || number == 1) return false;

    bool isPrime = true;

    int counter = 2;

    while (counter <= Math.Sqrt(number))
    {
        if (number % counter == 0)
        {
           isPrime = false;
           goto isNotAPrime;
        }
        counter++;
    }
    isNotAPrime:
    return isPrime;

}


/*Prime Number Checker: return variant. Instead of break and continue to stop the program execution,
we simply use return to break the loop execution since the result has already been found.*/

static bool isPrimeWithReturn(int number)
{
    if (number == 0 || number == 1) return false;

    bool isPrime = true;

    int counter = 2;

    while (counter <= Math.Sqrt(number))
    {
        if (number % counter == 0)
        {
            return false;
        } 
        counter++;
    }

    return true;

}