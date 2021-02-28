using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Cobrancas.Data.Models
{
    public class CobrancaEntity
    {
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; private set; }

        public DateTime Data { get; private set; }
        public long CPF { get; private set; }
        public decimal Valor { get; private set; }

        public CobrancaEntity(Guid id, DateTime data, long cPF, decimal valor)
        {
            Id = id;
            Data = data;
            CPF = cPF;
            Valor = valor;
        }
    }
}