class DispenseFactory
{
    public Money DistributeMoney(int amount)
    {
        if (amount >= 1000)
        {
            return new Thousand(amount);
        }
        if (amount >= 500)
        {
            return new FiveHundred(amount);
        }
        if (amount >= 100)
        {
            return new Hundred(amount);
        }
        return null;
    }
}