using System;

namespace Encapsulation.Invoicing
{
    public class Invoice
    {
        private string _partNumber = string.Empty;
        private string _partDescription = string.Empty;
        private int _quantity;
        private double _price;

        public string PartNumber
        {
            get => _partNumber;
            set => _partNumber = value ?? string.Empty;
        }

        public string PartDescription
        {
            get => _partDescription;
            set => _partDescription = value ?? string.Empty;
        }

        public int Quantity
        {
            get => _quantity;
            set => _quantity = value < 0 ? 0 : value;
        }

        public double Price
        {
            get => _price;
            set => _price = value < 0 ? 0.0 : value;
        }

        public Invoice(string partNumber, string partDescription, int quantity, double price)
        {
            PartNumber = partNumber;
            PartDescription = partDescription;
            Quantity = quantity;
            Price = price;
        }

        public double GetInvoiceAmount() => Quantity * Price;
    }
}