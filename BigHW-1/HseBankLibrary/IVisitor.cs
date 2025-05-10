using System;

namespace HseBankLibrary
{
    // Интерфейс для паттерна Посетитель.
    public interface IVisitor
    {
        void VisitBankAccount(BankAccount acc);
        void VisitCategory(Category acc);
        void VisitOperation(Operation acc);
    }
}
