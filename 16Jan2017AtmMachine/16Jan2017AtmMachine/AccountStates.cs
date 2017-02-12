namespace _16Jan2017AtmMachine
{
    public class AccountStates
    {
        private AccountStates _currentState;
        void ChangeState(AccountStates newState)
        {
            _currentState = newState;
        }
    }
}
