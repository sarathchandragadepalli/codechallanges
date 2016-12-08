using System;

public class Money
{
    public static int ReturnAmount;
    public string DispenseAmount(int amount)
    {
        DispenseFactory dispFactory = new DispenseFactory();
        dispFactory.DistributeMoney(amount);
        return (ReturnAmount == 0 ? "Thank you please visit again" : "please enter proper input");
    }

    public int CalculateLogic(int amount, int note)
    {
        int noofNotes = amount / note;
        amount = amount % note;
        Console.WriteLine("{0}*{1}", note, noofNotes);
        return amount;
    }

}

class Thousand:Money
{
    public Thousand(int amount)
    {
        ReturnAmount = CalculateLogic(amount, 1000);
        if (ReturnAmount > 0)
        {
            DispenseFactory dispenseFactory = new DispenseFactory();
            dispenseFactory.DistributeMoney(ReturnAmount);
        }

    }
       
}
class FiveHundred:Money
{
    public FiveHundred(int amount)
    {
        ReturnAmount= CalculateLogic(amount, 500);
        if (ReturnAmount > 0)
        {
            DispenseFactory dispenseFactory = new DispenseFactory();
            dispenseFactory.DistributeMoney(ReturnAmount);
        }
    }
       
}
class Hundred:Money
{
    public Hundred(int amount)
    {
        ReturnAmount= CalculateLogic(amount, 100);
    }
         
}