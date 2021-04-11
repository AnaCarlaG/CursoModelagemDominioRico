using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.ValueObject
{
    public class DocumentTest
    {
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJInvalid()
        {
            var doc = new Document("96642930000118", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFInvalid()
        {
            var doc = new Document("145", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCPFInvalid()
        {
            var doc = new Document("99901915066", EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }

    }
}
