using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalFinaceHelperData
{
    public class TransactionDescriptionConverter : ConverterBase
    {
        public override object StringToField(string from)
        {
            return from;
        }
            public override string FieldToString(object fieldValue)
        {
            return (string)fieldValue;
        }



    }
}
