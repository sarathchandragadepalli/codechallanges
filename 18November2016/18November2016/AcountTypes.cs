using System;
using System.Collections.Generic;

public class AcountTypes:IAccountType
{

    public virtual  bool Deposit()
    {
        return false;

    }

    public virtual bool WithDraw()
    {
        return false;

    }

    public virtual bool BalanceEnquiry()
    {
        return false;

    }
}



