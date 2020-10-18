using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Data.Enums
{
    public enum BookLoanStatus
    {
        BookReserved = 1,
        BookLoanInProgress = 2,
        BookReturnDelayed = 3,
        BookReturned = 4
    }
}
