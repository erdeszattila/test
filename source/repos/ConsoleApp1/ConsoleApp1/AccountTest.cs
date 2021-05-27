using NUnit.Framework;
using System;


namespace Bank
{
    [TestFixture]
    public partial class AccountTest
    {
        Account source;
        Account destination;

        [SetUp]
        public void Init()
        {
            source = new Account();
            source.Deposit(200m);

            destination = new Account();
            destination.Deposit(150m);
        }

        [Test]
        [Ignore("Test example, not mine")]
        public void TransferFunds()
        {
            source.TransferFunds(destination, 100m);

            Assert.AreEqual(250m, destination.Balance);
            Assert.AreEqual(100m, source.Balance);
        }

        [Test]
        [Ignore("Test example, not mine")]
        public void TransferWithInsufficientFunds()
        {
            Assert.That(() => source.TransferFunds(destination, 300m), 
                Throws.TypeOf<InsufficientFundsException>());
        }

        [Test]
        [Ignore("Test example, not mine")]
        public void TransferWithInsufficientFundsAtomicity()
        {
            try
            {
                source.TransferFunds(destination, 300m);
            }
            catch (InsufficientFundsException expected)
            {
            }

            Assert.AreEqual(200m, source.Balance);
            Assert.AreEqual(150m, destination.Balance);
        }

        [Test]
        public void CheckMinimumBalance()
        {
            //old assertion
            Assert.AreEqual(10m, source.MinimumBalance);
            Assert.AreEqual(10m, destination.MinimumBalance);
            //new assertion
            Assert.That(source.Balance, 
                Is.GreaterThanOrEqualTo(source.MinimumBalance));
            Assert.That(destination.Balance, 
                Is.GreaterThanOrEqualTo(destination.MinimumBalance));
        }

        [Test]
        public void NegativeDepositAmount()
        {
            Assert.That(() => source.Deposit(-10m),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void WithDraw()
        {
            Assert.That(() => source.Withdraw(-10m),
                Throws.TypeOf<InsufficientFundsException>());

            source.Withdraw(100m);
            Assert.That(source.Balance, Is.EqualTo(100m));

            // Balance can't be lower than the minimum balance amount after a withdraw
            Assert.That(() => source.Withdraw(100m),
                Throws.TypeOf<InsufficientFundsException>());
        }
    }
}
