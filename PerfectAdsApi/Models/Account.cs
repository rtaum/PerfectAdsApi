using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;

namespace PerfectAdsApi.Models
{
    public class Account
    {
        public ObjectId Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Guid Hash { get; set; }

        public DateTime HashExpire { get; set; }

        public DateTime SignupDateTime { get; set; }

        public string SignUpIp { get; set; }

        [JsonIgnore]
        [BsonIgnore]
        public DateTime ConfirmationDateTime { get; set; }

        [JsonIgnore]
        [BsonIgnore]
        public string ConfirmationUpIp { get; set; }

        [JsonIgnore]
        [BsonIgnore]
        public string CompanyName { get; set; }

        [JsonIgnore]
        [BsonIgnore]
        public string CompanyContactPerson { get; set; }

        [JsonIgnore]
        [BsonIgnore]
        public string CompanyAddress { get; set; }

        [JsonIgnore]
        [BsonIgnore]
        public string CompanyZipCode { get; set; }

        [JsonIgnore]
        [BsonIgnore]
        public string CompanyCity { get; set; }

        [JsonIgnore]
        [BsonIgnore]
        public string CompanyCountry { get; set; }

        [JsonIgnore]
        [BsonIgnore]
        public string CompanyVatId { get; set; }

        [JsonIgnore]
        [BsonIgnore]
        public string PaymentMethod { get; set; }

        [JsonIgnore]
        [BsonIgnore]
        public decimal Balance { get; set; }
    }
}