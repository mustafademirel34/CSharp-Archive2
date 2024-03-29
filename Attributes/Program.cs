﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer=new Customer{Id = 1, LastName = "Demiroğ", Age = 32};
            CustomerDal customerDal=new CustomerDal();
            customerDal.Add(customer);
            Console.ReadLine();

            // Attribute 'lar nesne ve class'lara anlam katar.
            // if else ile kontrol etmek yerine kullanılması daha iyidir.
            // Reflection ile tespit edilir ve işlemler uygulanır.
        }
    }

    [ToTable("Customers")]
    [ToTable("TblCustomers")]
    class Customer
    {
        public int Id { get; set; }
        [RequiredProperty] // doldurulması gerekli anlamındadır
        public string FirstName { get; set; }
        [RequiredProperty]
        public string LastName { get; set; }
        [RequiredProperty]
        public int Age { get; set; }
    }

    class CustomerDal
    {
        // Bu eski bir metot anlamına gelir.
        [Obsolete("Dont use Add, instead use AddNew Method")]
        public void Add(Customer customer)
        {

            Console.WriteLine("{0},{1},{2},{3} added!",
                customer.Id,customer.FirstName,customer.LastName,customer.Age);
        }

        public void AddNew(Customer customer)
        {

            Console.WriteLine("{0},{1},{2},{3} added!",
                customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }
    }

    // Attribute'ın kullanım alanlarını belirler
    //[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = true)]// allow = birden fazla attr uyglama
    class RequiredPropertyAttribute:Attribute // Özel bir attribute oluşturulmuş
    {
        
    }

    [AttributeUsage(AttributeTargets.Class,AllowMultiple = true)] // özel attr
    class ToTableAttribute : Attribute
    {
        private string _tableName;

        public ToTableAttribute(string tableName)
        {
            _tableName = tableName;
        }
    }


}
