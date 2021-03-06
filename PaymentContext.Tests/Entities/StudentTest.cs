using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.ValueObject
{
    public class StudentTest
    {
        private readonly Student _student;
        private readonly Name _name;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Email _email;
        private readonly Subscription _subscription;

        public StudentTest()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("75824187002", EDocumentType.CPF);
            _email = new Email("batman@dc.com");
            _address = new Address("Rua 1", 1234, "Bairro", "Gotham", "Arkham ", "111111");

            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);

        }
        [TestMethod]
        public void ShoudReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PaypalPayment("123789", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);

            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Valid);

        }

        [TestMethod]
        public void ShoudReturnErrorWhenHadSubscriptionHasNoPayment()
        {

            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }
        [TestMethod]
        public void ShoudReturnSuccessWhenHadAddSubscription()
        {
            var payment = new PaypalPayment("123789", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);

            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Valid);
        }
    }
}
