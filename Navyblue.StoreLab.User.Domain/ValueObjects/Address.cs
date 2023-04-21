// ******************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : Address.cs
// Created          : 2023-04-11  10:03
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-11  10:03
// ******************************************************************************************************
// <copyright file="Address.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


namespace Navyblue.StoreLab.User.Domain.ValueObjects;

public record Address
{
    public Address(string country, string province, string city, string street, string zipCode, string remark)
    {
        this.Country = country;
        this.Province = province;
        this.City = city;
        this.Street = street;
        this.ZipCode = zipCode;
        this.Remark = remark;
    }

    public string Country { get; private set; }

    public string Province { get; private set; }

    public string City { get; private set; }

    public string Street { get; private set; }

    public string ZipCode { get; private set; }

    public string Remark { get; private set; }
}