namespace _16Jan2017AtmMachine
{
    public interface IAccountStates
    {
        double Deposit(double initialAmount, double depositAmount);
        double WithDraw(double initialAmount, double depositAmount);
    }
}
