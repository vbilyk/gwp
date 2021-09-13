using FileHelpers;

namespace GWPService.Model
{
    [DelimitedRecord(",")]
    public class GwpItem
    {
        public string Country { get; set; }

        public string LineOfBusiness { get; set; }
        public string VariableId { get; set; }
        public string VariableName { get; set; }

        // This list of properties is not optimal solution
        // so I would change it to something extendable
        [FieldConverter(ConverterKind.Decimal, ".")]
        public decimal Y2000 { get; set; }
        [FieldConverter(ConverterKind.Decimal, ".")]
        public decimal Y2001 { get; set; }
        [FieldConverter(ConverterKind.Decimal, ".")]
        public decimal Y2002 { get; set; }
        [FieldConverter(ConverterKind.Decimal, ".")]
        public decimal Y2003 { get; set; }
        [FieldConverter(ConverterKind.Decimal, ".")]
        public decimal Y2004 { get; set; }
        [FieldConverter(ConverterKind.Decimal, ".")]
        public decimal Y2005 { get; set; }
        [FieldConverter(ConverterKind.Decimal, ".")]
        public decimal Y2006 { get; set; }
        [FieldConverter(ConverterKind.Decimal, ".")]
        public decimal Y2007 { get; set; }
        [FieldConverter(ConverterKind.Decimal, ".")]
        public decimal Y2008 { get; set; }
        [FieldConverter(ConverterKind.Decimal, ".")]
        public decimal Y2009 { get; set; }
        [FieldConverter(ConverterKind.Decimal, ".")]
        public decimal Y2010 { get; set; }
        [FieldConverter(ConverterKind.Decimal, ".")]
        public decimal Y2011 { get; set; }
        [FieldConverter(ConverterKind.Decimal, ".")]
        public decimal Y2012 { get; set; }
        [FieldConverter(ConverterKind.Decimal, ".")]
        public decimal Y2013 { get; set; }
        [FieldConverter(ConverterKind.Decimal, ".")]
        public decimal Y2014 { get; set; }
        [FieldConverter(ConverterKind.Decimal, ".")]
        public decimal Y2015 { get; set; }

        public decimal Average()
        {
            return (this.Y2008 + this.Y2009 +
                   this.Y2010 + this.Y2011 +
                   this.Y2012 + this.Y2013 +
                   this.Y2014 + this.Y2015) / 8;
        }
    }
}
