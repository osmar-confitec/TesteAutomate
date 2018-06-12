using FileHelpers;
using System;

namespace TesteAutomate
{

    [FixedLengthRecord(FixedMode.AllowLessChars)]

    public  class Arquivo
    {

        [FieldFixedLength(2)]
        [FieldTrim(TrimMode.Both)]
        public string TipoRegistro { get; set; }

        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime DataPregao { get; set; }


        [FieldFixedLength(2)]
        [FieldTrim(TrimMode.Both)]
        public string Branco4 { get; set; }

        [FieldFixedLength(12)]
        [FieldTrim(TrimMode.Both)]
        public string CodNegociacao { get; set; }

        [FieldFixedLength(33)]
        public string Branco1 { get; set; }

        [FieldFixedLength(11)]
        [FieldConverter(ConverterKind.Decimal)]
        public decimal ValorAbertura { get; set; }

        [FieldFixedLength(41)]
        public string Branco2 { get; set; }

        [FieldFixedLength(11)]
        [FieldConverter(ConverterKind.Decimal)]
        public decimal ValorFechamento { get; set; }

        [FieldFixedLength(125)]
        public string Branco3 { get; set; }



    }
}
