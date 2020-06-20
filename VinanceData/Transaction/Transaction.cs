using FileHelpers;
using PersonalFinaceHelperData;
using System;
using System.Runtime.InteropServices.ComTypes;

namespace VinanceData
{
    [DelimitedRecord(",")]
    [IgnoreFirst]
    [IgnoreEmptyLines]
    public class Transaction
    {
        public string Date;

        [FieldConverter(typeof(TransactionDescriptionConverter))]
        public string Description;

        public string OriginalDescription;

        public double? Amount;

        public string TransactionType;

        public string Category;

        public string AccountName;

        public string Labels;

        public string Notes;

        public static bool operator ==(Transaction obj1, Transaction obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(Transaction obj1, Transaction obj2)
        {
            return !(obj1.Equals(obj2));
        }

        public override bool Equals(object obj)
        {
            Transaction other = (Transaction)obj;

            return Date == other.Date
                        && OriginalDescription == other.OriginalDescription
                        && Amount == other.Amount
                        && TransactionType == other.TransactionType
                        && Category == other.Category
                        && AccountName == other.AccountName
                        && Labels == other.Labels
                        && Notes == other.Notes;
        }
        public override string ToString()
        {
            return "Date:"+Date+
                "\nDescription:" + Description+
                "\nOriginal Description:" + OriginalDescription+
                "\nAmount:" + Amount+
                "\nTransaction Type:" + TransactionType+
                "\nCategory:" + Category+
                "\nAccount Name:" + AccountName+
                "\nLabels:" + Labels+
                "\nNotes:" + Notes;
        }

        public override int GetHashCode()
        {
            return Description.Length;
        }
    }
}
